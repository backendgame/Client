using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashSceneManager : MonoBehaviour{
    public InputField inputIPAddress;
    public InputField inputPort;


    void Start(){
        NetworkGlobal.instance.StartOnehit(new MessageSending(1),(messageReceiving,isError)=>{
            messageReceiving.readByte();
            SceneManager.LoadScene("LoginScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSetIPAddress() {
        BGConfig.IP = inputIPAddress.text.ToString();
        BGConfig.portOnehit = int.Parse(inputPort.text.ToString());
        SceneManager.LoadScene("LoginScene");
    }
}
