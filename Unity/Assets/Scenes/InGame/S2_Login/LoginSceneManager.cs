using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginSceneManager : MonoBehaviour{
    public InputField inputUsername;
    public InputField inputPassword;

    public InputField inputEmail;
    public InputField inputCode;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Start(){}void Update(){}

    public void onLoginDeviceId(){
        Debug.Log("onLoginDeviceId");

        MessageSending mgDevice=new MessageSending(CMD_ONEHIT.LGScreen_LoginAccount_0_Device);
        mgDevice.writeshort(BGInfo.tableAccount.DBId);
        mgDevice.writeLong(BGInfo.tableAccount.AccessKey);
        mgDevice.writeString(SystemInfo.deviceUniqueIdentifier);
        Debug.Log("AccessKey : "+BGInfo.tableAccount.AccessKey);
        Debug.Log("DeviceId : "+SystemInfo.deviceUniqueIdentifier);
        NetworkGlobal.instance.StartOnehit(mgDevice,(messageReceiving,isError)=>{
            if(messageReceiving!=null){
                sbyte status = messageReceiving.readByte();
                if(status==StatusOnehit.Success){
                    Debug.Log("Login Success");
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
