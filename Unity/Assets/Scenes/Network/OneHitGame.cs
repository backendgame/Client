using System.Net.Sockets;
using System.Collections.Generic;
using UnityEngine;

 
public class OneHitGame : OnehitCore {
    private List<string> listIpConnect;
    public string currentIPDetail;

    public OneHitGame(string ip, MessageSending _messageSending, int _addWaitTimemili=0) {
        listIpConnect=new List<string>();
        listIpConnect.Add(ip);
        messageSending = _messageSending;
        addWaitTimemili = _addWaitTimemili;
    }
    public OneHitGame(List<string> _listIp, MessageSending _messageSending, int _addWaitTimemili=0) {
        if(_listIp==null || _listIp.Count==0){
            listIpConnect=new List<string>();
            listIpConnect.Add(BGConfig.IP);
        }else
            listIpConnect = _listIp;
        messageSending = _messageSending;
        addWaitTimemili = _addWaitTimemili;
    }
    public void RunNetwork(){
        TcpClient _tcpClient = null;
        for (int i = 0; i < listIpConnect.Count; i++) {
            _tcpClient = ConnectIp(listIpConnect[i],BGConfig.portOnehit,1268);
            if(_tcpClient==null){
                // #if TEST
                // Debug.LogWarning("--->Onehit error connect : "+currentIPDetail.ip+"("+currentIPDetail.port_onehit+")");
                // #endif
            }else{
                // #if TEST
                // Debug.LogWarning("Tạo kết nối thành công đến : "+currentIPDetail.ip+"("+currentIPDetail.port_onehit+")");
                // #endif                
                break;
            }
        }
        if (_tcpClient == null){
            #if TEST
            for (int i = 0; i < listIpConnect.Count; i++)
                Debug.LogError("TCP Socket Error ➞ "+listIpConnect[i].ip+":"+listIpConnect[i].port_onehit);
            #endif
            if(onError!=null)
                onError("Network error : "+CMD_ONEHIT.getCMDName(messageSending.getCMD()));
        }else
            ProcessTCP(_tcpClient);
    }
}
