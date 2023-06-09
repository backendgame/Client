using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

public class LoginSceneManager : MonoBehaviour{
    public InputField inputUsername;
    public InputField inputPassword;

    public InputField inputEmail;
    public InputField inputCode;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start(){}void Update(){}


    private void onReadDataLoginSuccess(MessageReceiving messageReceiving){
        PlayerData myPlayer = LocalDataManager.instance.myPlayer;
        myPlayer.UserId = messageReceiving.readLong();
        myPlayer.status = messageReceiving.readByte();

        List<BGDescribe> listDescribe=new List<BGDescribe>();
        int numberDescribe = messageReceiving.readInt();
        for(int i=0;i<numberDescribe;i++){
            BGDescribe desTable = new BGDescribe();
            desTable.readMessage(messageReceiving);
            listDescribe.Add(desTable);
        }
        BGInfo.tableAccount.listDescribeTable=listDescribe;

        object value=null;
        for(int i=0;i<numberDescribe;i++){
            sbyte Type = listDescribe[i].Type;
            if(0<Type && Type<10)
                value = messageReceiving.readBoolean();
            else if(9<Type && Type<20)
                value = messageReceiving.readByte();
            else if(19<Type && Type<40)
                value = messageReceiving.readShort();
            else if(39<Type && Type<60)
                value = messageReceiving.readInt();
            else if(59<Type && Type<80)
                value = messageReceiving.readFloat();
            else if(79<Type && Type<90)
                value = messageReceiving.readLong();
            else if(89<Type && Type<100)
                value = messageReceiving.readDouble();
            else if(99<Type && Type<120)
                value = messageReceiving.readByteArray();
            else if(Type==DBDefine_DataType.STRING) {
                value = messageReceiving.readString();
            }else if(Type==DBDefine_DataType.IPV6)
                value = messageReceiving.readSpecialArray_WithoutLength(16);
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




    public void onLoginDeviceId(){
        Debug.Log("onLoginDeviceId");

        MessageSending mgDevice=new MessageSending(CMD_ONEHIT.LGScreen_LoginAccount_0_Device);
        mgDevice.writeShort(BGInfo.tableAccount.DBId);
        mgDevice.writeLong(BGInfo.tableAccount.AccessKey);
        mgDevice.writeString(SystemInfo.deviceUniqueIdentifier);
        Debug.Log("AccessKey : "+BGInfo.tableAccount.AccessKey);
        Debug.Log("DeviceId : "+SystemInfo.deviceUniqueIdentifier);
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

    public void onCreateAccount(){
        Debug.Log("onCreateAccount");
    }
    public void onLoginAccount(){
        Debug.Log("onLoginAccount");
    }

    public void onLoginFacebook(){
        Debug.Log("onLoginFacebook");
    }

    public void onLoginGoogle(){
        Debug.Log("onLoginGoogle");
    }
    public void onLoginAdsId(){
        Debug.Log("onLoginAdsId");
    }

    public void onLoginEmailCode(){
        Debug.Log("onLoginEmailCode");
    }
    public void onGetCode(){
        Debug.Log("onGetCode");
    }
}
