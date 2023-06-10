using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;

public class LoginScreenOnehit{

    private static void onReadDataLoginSuccess(MessageReceiving messageReceiving){
        PlayerData myPlayer = LocalDataManager.instance.myPlayer;
        myPlayer.UserId = messageReceiving.readLong();
        myPlayer.status = messageReceiving.readByte();
        myPlayer.logoutId = messageReceiving.readByte();

        List<BGDescribe> listDescribe=new List<BGDescribe>();
        int numberDescribe = messageReceiving.readInt();
        for(int i=0;i<numberDescribe;i++){
            BGDescribe desTable = new BGDescribe();
            desTable.readMessage(messageReceiving);
            listDescribe.Add(desTable);
        }
        BGInfo.tableAccount.listDescribeTable=listDescribe;

        for(int i=0;i<numberDescribe;i++){
            object value=messageReceiving.readType(listDescribe[i].Type);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Read every column here
            if(string.Equals(listDescribe[i].ColumnName, BGInfo.ColumnName_NameShow))//Column name in database or use "indexDescribe" : 0,1,2,....
                myPlayer.nameShow = (string)value;

            if(string.Equals(listDescribe[i].ColumnName, BGInfo.ColumnName_AvatarId))
                myPlayer.avatarId = (sbyte)value;

            if(string.Equals(listDescribe[i].ColumnName, BGInfo.ColumnName_DeviceType))
                myPlayer.deviceType = (sbyte)value;

            if(string.Equals(listDescribe[i].ColumnName, BGInfo.ColumnName_Gold))
                myPlayer.gold = (long)value;
        }
        Debug.Log(JsonConvert.SerializeObject(myPlayer));
    }

    public static void LoginDevice(){
        Debug.Log("DBId("+BGInfo.tableAccount.DBId+")   AccessKey("+BGInfo.tableAccount.AccessKey+"  DeviceId("+SystemInfo.deviceUniqueIdentifier+")");
        MessageSending mgDevice=new MessageSending(CMD_ONEHIT.LGScreen_LoginAccount_0_Device);
        mgDevice.writeShort(BGInfo.tableAccount.DBId);
        mgDevice.writeLong(BGInfo.tableAccount.AccessKey);
        mgDevice.writeString(SystemInfo.deviceUniqueIdentifier);
        NetworkGlobal.instance.StartOnehit(mgDevice,(messageReceiving,isError)=>{
            if(messageReceiving!=null){
                sbyte status = messageReceiving.readByte();
                if(status==StatusOnehit.Success){
                    Debug.Log("Login Success");
                    onReadDataLoginSuccess(messageReceiving);
                    SceneManager.LoadScene("HomeScene");
                }else
                    Debug.Log("Login fail : "+StatusOnehit.getString(status));
            }
        });
    }

    public static void LoginAccount(string username,string password){
        Debug.Log("DBId("+BGInfo.tableAccount.DBId+")   AccessKey("+BGInfo.tableAccount.AccessKey+"  Username("+username+")   Password("+password+")");
        MessageSending mgDevice=new MessageSending(CMD_ONEHIT.LGScreen_LoginAccount_1_System);
        mgDevice.writeShort(BGInfo.tableAccount.DBId);
        mgDevice.writeLong(BGInfo.tableAccount.AccessKey);
        mgDevice.writeString(username);
        mgDevice.writeString(password);
        NetworkGlobal.instance.StartOnehit(mgDevice,(messageReceiving,isError)=>{
            if(messageReceiving!=null){
                sbyte status = messageReceiving.readByte();
                if(status==StatusOnehit.Success){
                    Debug.Log("Login Success");
                    onReadDataLoginSuccess(messageReceiving);
                    SceneManager.LoadScene("HomeScene");
                }else
                    Debug.Log("Login fail : "+StatusOnehit.getString(status));
            }
        });
    }

    public static void CreateAccount(string username,string password){

    }


    public static IEnumerator parseGoogleCode_and_SendLogin(string googleCode) {
        Debug.Log("Begin parse Google Code -> ");
        WWWForm form = new WWWForm();
        form.AddField("code", string.IsNullOrEmpty(googleCode)? GUIUtility.systemCopyBuffer : googleCode);
        form.AddField("client_id", BGConfig.LoginGoogle_Client_ID);
        form.AddField("client_secret", BGConfig.LoginGoogle_Client_secret);
        form.AddField("redirect_uri", BGConfig.LoginGoogle_Authorised_redirect_URIs);
        form.AddField("grant_type", "authorization_code");

        UnityWebRequest www = UnityWebRequest.Post("https://oauth2.googleapis.com/token", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success){
            Debug.LogError(www.error);
        }else{
            JObject jsonResult = JObject.Parse(www.downloadHandler.text);
            Debug.Log("Login success : " + www.downloadHandler.text);
            string id_token = jsonResult["id_token"].ToString();
            string access_token = jsonResult["access_token"].ToString();

            Application.OpenURL("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token="+id_token);
            Debug.Log("id_token=<color=orange>"+id_token+"</color> → send to server");
            LoginGoogle(id_token);
        }
    }
    public static void LoginGoogle(string id_token){

    }
}
