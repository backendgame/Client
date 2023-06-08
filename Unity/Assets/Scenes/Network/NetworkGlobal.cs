using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NetworkGlobal : MonoBehaviour{
    private System.Object syncLock;
    private Action actionUpdateUI;
    public void setUpdateUI(Action _action){
        new Thread(new ThreadStart(()=>{
            lock(syncLock){
                while(actionUpdateUI!=null)
                    Thread.Sleep(1);
                actionUpdateUI=_action;
            }
        })).Start();
    }
    IEnumerator doActionUIGame(Action _action) { _action(); yield break; }

    // Start is called before the first frame update
    void Start(){
        syncLock = new System.Object();
    }

    // Update is called once per frame
    void Update(){
        if(actionUpdateUI!=null){
            StartCoroutine(doActionUIGame(actionUpdateUI));
            actionUpdateUI=null;
        }
    }







    private static NetworkGlobal ins = null;
    public static NetworkGlobal instance{
        get{
            if (ins == null){
                GameObject go = new GameObject();
                ins = go.AddComponent<NetworkGlobal>();
                go.name = ins.GetType().Name;
                DontDestroyOnLoad(ins);
            }
            return ins;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region One Hit
    public void StartOnehit(MessageSending _messageSending, Action<MessageReceiving, bool> _onFinished, int _addSleepWait = 0){
        List<ServerDetail> _listServer=new List<ServerDetail>();
        _listServer.Add(new ServerDetail().SetIp(BGConfig.IP).SetOnehit(BGConfig.portOnehit));
        StartOnehit(_messageSending, _listServer,_onFinished,_addSleepWait);
    }
    public void StartOnehit(MessageSending _messageSending, string ip, int port, Action<MessageReceiving, bool> _onFinished, int _addSleepWait = 0){
        List<ServerDetail> _listServer=new List<ServerDetail>();
        _listServer.Add(new ServerDetail().SetIp(ip).SetOnehit(port));
        StartOnehit(_messageSending,_listServer,_onFinished,_addSleepWait);
    }
    public void StartOnehit(MessageSending _messageSending, List<ServerDetail> _listServer, Action<MessageReceiving, bool> _onFinished,int _addSleepWait = 0){
        OneHitGame clientOnehit = new OneHitGame(_listServer, _messageSending, _addSleepWait);
        clientOnehit.onError = (n) => {
            Debug.LogError("Onehit Error : "+CMD_ONEHIT.getCMDName(_messageSending)+"➜"+n);
            if(_onFinished != null)
                setUpdateUI(()=>{
                    _onFinished(null,true); 
                });           
        };
        clientOnehit.onSuccess = ()=>{
            Debug.LogWarning("Onehit : " + CMD_ONEHIT.getCMDName(_messageSending.getCMD()) + " " + _messageSending.avaiable() + " byte " + (clientOnehit.messageReceiving == null ? "" : ("➜ " + clientOnehit.messageReceiving.avaiable() + " byte")) + "   " + clientOnehit.currentServer.getTraceOnehit()+" ("+clientOnehit.messageReceiving.timeProcess+" ms)");
            if(_onFinished != null)
                setUpdateUI(()=>{
                    _onFinished(clientOnehit.messageReceiving,false);
                    if(clientOnehit.messageReceiving.validate()==false)
                        Debug.LogError("Onehit MessageReceiving : "+clientOnehit.messageReceiving.avaiable()+" byte("+CMD_ONEHIT.getCMDName(_messageSending)+"➜"+clientOnehit.messageReceiving.lengthReceive()+")");
                });
        };
        new Thread(new ThreadStart(clientOnehit.RunNetwork)).Start();
    }
	#endregion
}
