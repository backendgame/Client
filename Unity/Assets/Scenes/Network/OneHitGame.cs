using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using UnityEngine;

 
public class OneHitGame : OnehitCore {
    private List<string> listIpConnect;
    public string currentIP;

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
        long TIME_OUT = 3000;
        for (int i = 0; i < listIpConnect.Count; i++) {
            currentIP=listIpConnect[i];
            if (currentIP.Contains(":") || currentIP.Contains("v6"))
                tcpSocket = new TcpClient(AddressFamily.InterNetworkV6);
            else
                tcpSocket = new TcpClient(AddressFamily.InterNetwork);

            for(int k=0;k<TIME_OUT/5;k++)
                if (tcpSocket.Connected){
                    ProcessTCP();
                    return;
                }else
                    Thread.Sleep(5);
            tcpSocket.Close();
        }

        for (int i = 0; i < listIpConnect.Count; i++)
            Debug.LogError("TCP Socket Error ➞ "+listIpConnect[i]+" → "+BGConfig.portOnehit);
        if(onError!=null)
            onError("Network error : "+CMD_ONEHIT.getCMDName(messageSending.getCMD()));

    }
}
