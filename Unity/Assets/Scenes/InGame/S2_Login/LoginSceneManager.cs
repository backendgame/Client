using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;

public class LoginSceneManager : MonoBehaviour{
    public InputField inputUsername;
    public InputField inputPassword;
    public InputField inputFacebookToken;
    public InputField inputGoogleCode;
    public InputField inputEmail;
    public InputField inputCode;
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////void Start(){}void Update(){}
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void onLoginDeviceId(){
        Debug.Log("onLoginDeviceId");
        LoginScreenOnehit.LoginDevice();
    }

    public void onCreateAccount(){
        Debug.Log("onCreateAccount");
        LoginScreenOnehit.CreateAccount(inputUsername.text,inputPassword.text);
    }
    public void onLoginAccount(){
        Debug.Log("onLoginAccount");
        LoginScreenOnehit.LoginAccount(inputUsername.text,inputPassword.text);
    }

    public void onLoginFacebook(){
        Debug.Log("onLoginFacebook");
        /*
            Login with Facebook SDK
            1/ Create Application : https://developers.facebook.com
            2/ Add this Application to a Business (organization) → token_for_business
            3/ install facebook sdk on Unity
            4/ Login with facebook
        */
        LoginScreenOnehit.LoginFacebook(inputFacebookToken.text);
    }
    public void onGetFacebookToken(){
        Application.OpenURL("https://developers.facebook.com/tools/explorer/");
        Debug.Log("or : https://developers.facebook.com/tools/accesstoken/?app_id= + AppId");
    }

    public void onGetGoogleCode(){Application.OpenURL("https://accounts.google.com/o/oauth2/v2/auth?response_type=code&scope=profile%20email&redirect_uri=" + BGConfig.LoginGoogle_Authorised_redirect_URIs + "&client_id=" + BGConfig.LoginGoogle_Client_ID);}
    public void onLoginGoogle(){
        Debug.Log("onLoginGoogle");
        /*
            Login Google in Unity Editor:
            1/ Create Project : https://console.cloud.google.com/
            2/ "APIs and services" → "OAuth consent screen" : setup screen (https://console.cloud.google.com/apis/credentials/consent)
            3/ "APIs and services" → "Credentials" → Create "OAuth Client ID" → "Application Type" = "Web Application" (https://console.cloud.google.com/apis/credentials)
                    Authorised redirect URIs = https://backendgame.com/GoogleSignIn.html
            4/ Get Code → https://accounts.google.com/o/oauth2/v2/auth?response_type=code&scope=profile%20email&redirect_uri=" + redirect_uri + "&client_id=" + webClientId
            5/ Convert Code → id_token
            6/ Send token to server (https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=)
        */
		#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            StartCoroutine(LoginScreenOnehit.parseGoogleCode_and_SendLogin(inputGoogleCode.text));
		#else
        /*
            1/ Setup
                https://github.com/googlesamples/google-signin-unity
                https://github.com/googlesamples/google-signin-unity/releases
            2/ Login → id_token
            3/  
        */
            Debug.log("Wait for : Devloper setup");
		#endif
    }


    public void onLoginAdsId(){
        Debug.Log("onLoginAdsId");
		Application.RequestAdvertisingIdentifierAsync((string advertisingId, bool trackingEnabled, string error) =>{
            Debug.Log("advertisingId("+advertisingId+") trackingEnabled("+trackingEnabled+")    error("+error+")");
			
		});
    }

    public void onLoginEmailCode(){
        Debug.Log("onLoginEmailCode");
    }
    public void onGetEmailCode(){
        Debug.Log("onGetCode");
    }
}
