using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerDetail{
    public string ipv4,ipv6;
    public int portOnehit;
    public int portRealtime;
    public int portRestAPI;
    public int portWebsocket;

    public ServerDetail SetIp(string ip){
        if (ip.Contains(":") || ip.Contains("v6"))
            ipv6=ip;
        else
            ipv4=ip;
        return this;
    }
    public ServerDetail SetIpv4(string _ipv4){
        ipv4=_ipv4;
        return this;
    }
    public ServerDetail SetIpv6(string _ipv6){
        ipv6=_ipv6;
        return this;
    }
    public ServerDetail SetOnehit(int _portOnehit){
        portOnehit=_portOnehit;
        return this;
    }
    public ServerDetail SetRealtime(int _portRealtime){
        portRealtime=_portRealtime;
        return this;
    }
    public ServerDetail SetRestAPI(int _portRestAPI){
        portRestAPI=_portRestAPI;
        return this;
    }
    public ServerDetail SetWebsocket(int _portWebsocket){
        portWebsocket=_portWebsocket;
        return this;
    }

    public string getTraceOnehit(){
        if(!string.IsNullOrEmpty(ipv4))
            return ipv4+":"+portOnehit;
        else
            return ipv6+":"+portOnehit;
    }
}
