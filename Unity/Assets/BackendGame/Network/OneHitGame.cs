using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using UnityEngine;

 
public class OneHitGame : OnehitCore {
    private List<ServerDetail> listServer;
    public ServerDetail currentServer;

    public OneHitGame(string ip, int port, MessageSending _messageSending, int _addWaitTimemili=0) {
        listServer=new List<ServerDetail>();
        listServer.Add(new ServerDetail().SetIp(ip).SetOnehit(port));
        messageSending = _messageSending;
        addWaitTimemili = _addWaitTimemili;
    }
    public OneHitGame(List<ServerDetail> _listSV, MessageSending _messageSending, int _addWaitTimemili=0) {
        if(_listSV==null || _listSV.Count==0){
            listServer=new List<ServerDetail>();
            listServer.Add(new ServerDetail().SetIp(BGConfig.IP).SetOnehit(BGConfig.portOnehit));
        }else
            listServer = _listSV;
        messageSending = _messageSending;
        addWaitTimemili = _addWaitTimemili;
    }

    public void RunNetwork(){
        long TIME_OUT = 3000;
        for (int i = 0; i < listServer.Count; i++) {
            currentServer=listServer[i];
            if(!string.IsNullOrEmpty(currentServer.ipv6)){
                tcpSocket = new TcpClient(AddressFamily.InterNetworkV6);
                try{tcpSocket.BeginConnect(currentServer.ipv6, currentServer.portOnehit, null, null);}catch(SocketException scE){Debug.LogWarning(scE.Message.ToString());}
                for(int k=0;k<TIME_OUT/5;k++)
                    if (tcpSocket.Connected){
                        ProcessTCP();
                        return;
                    }else
                        Thread.Sleep(5);
                tcpSocket.Close();
            }
            if(!string.IsNullOrEmpty(currentServer.ipv4)){
                tcpSocket = new TcpClient(AddressFamily.InterNetwork);
                try{tcpSocket.BeginConnect(currentServer.ipv4, currentServer.portOnehit, null, null);}catch(SocketException scE){Debug.LogWarning(scE.Message.ToString());}
                for(int k=0;k<TIME_OUT/5;k++)
                    if (tcpSocket.Connected){
                        ProcessTCP();
                        return;
                    }else
                        Thread.Sleep(5);
                tcpSocket.Close();
            }
        }

        for (int i = 0; i < listServer.Count; i++)
            Debug.LogError("TCP Socket Error ➞ "+listServer[i].ipv4+"("+listServer[i].portOnehit+")    "+listServer[i].ipv6+"("+listServer[i].portOnehit+")");
        if(onError!=null)
            onError("Network error : "+CMD_ONEHIT.getCMDName(messageSending.getCMD()));

    }
}
