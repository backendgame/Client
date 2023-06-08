using System;
using System.Threading;
using System.Net.Sockets;
using UnityEngine;

public class OnehitCore{
    public const short ERRORCODE_NO_MESSAGE_SENDING = 1;
    public const short ERRORCODE_CREATE_SOCKET = 2;
    public const short ERRORCODE_LENGTH_SERVER_ERROR = 3;

    public const short SOCKET_TIME_OUT_1 = 100;
    public const short SOCKET_TIME_OUT_2 = 101;
    public const short SOCKET_TIME_OUT_3 = 102;
    private bool isRunning;
    protected MessageSending messageSending;
	public int addWaitTimemili;
    
    

    protected TcpClient tcpSocket;
    private NetworkStream networkStream;
    protected void ProcessTCP() {
        isRunning=true;
        networkStream = tcpSocket.GetStream();
        ProcessNetwork();
        Thread.Sleep(3000);
        networkStream.Close();
        tcpSocket.Close();
    }

    public MessageReceiving messageReceiving;
    public Action onSuccess;
    public Action<String> onError;
    private void ProcessNetwork() {
        long timeBeginProcess = DateTimeUtil.currentUtcTimeMilliseconds;
        byte[] dataMessage = messageSending.getBytesArray();
        int length = dataMessage.Length;
        byte[] datatransfer = new byte[11+length];

        if (Wait(8))
            networkStream.Read(datatransfer, 0, 8);
        else{
            onError("SOCKET_TIME_OUT(ValidateCode)");
            return;
        }
        byte validateCode = datatransfer[3];
        datatransfer[0] = (byte)(datatransfer[0] ^ validateCode);
        datatransfer[1] = (byte)(datatransfer[1] ^ validateCode);
        datatransfer[2] = (byte)(datatransfer[2] ^ validateCode);
        datatransfer[3] = (byte)(datatransfer[4] ^ validateCode);
        datatransfer[4] = (byte)(datatransfer[5] ^ validateCode);
        datatransfer[5] = (byte)(datatransfer[6] ^ validateCode);
        datatransfer[6] = (byte)(datatransfer[7] ^ validateCode);
        
        for (short i = 0; i < length; i++)
            datatransfer[i + 11] = (byte)(dataMessage[i] ^ validateCode);        
        datatransfer[7] = (byte)(length >> 24);
        datatransfer[8] = (byte)(length >> 16);
        datatransfer[9] = (byte)(length >> 8);
        datatransfer[10]= (byte)length;
        networkStream.Write(datatransfer);
        
        
        int countWaitPing = (3000 + addWaitTimemili)/5;
        for(int i=0;i<countWaitPing;i++)
            if(isRunning==false){
                onError("SOCKET_CLOSE_BY_USER");
                return;
            }else if (tcpSocket.Available < 4)
                try{Thread.Sleep(5);}catch(Exception e){Debug.Log("Error : "+e.Message);}
            else
                break;

        if(tcpSocket.Available < 4){
            onError("ERROR(Sai giao thuc)");
            return;
        }

        networkStream.Read(datatransfer, 0, 2);
        int ch1 = datatransfer[0] & 0xFF;
        int ch2 = datatransfer[1] & 0xFF;
        length = (short)((ch1 << 8) + (ch2 << 0)); if(length<0 || length>32768){onError("LengthError");return;}
        datatransfer = new byte[length + 2];
        if (length > -1) {
            if (Wait(length)){
                networkStream.Read(datatransfer, 2, length);
                for (short i = 0; i < length; i++)
                    datatransfer[i + 2] = (byte)(datatransfer[i + 2] ^ validateCode);

                messageReceiving=new MessageReceiving(datatransfer);
                messageReceiving.cmd = messageSending.getCMD();
                messageReceiving.timeProcess = DateTimeUtil.currentUtcTimeMilliseconds-timeBeginProcess;
                // #if TEST
                // Debug.LogWarning("Onehit " + CMD_ONEHIT.getCMDName(messageSending) + " : " + messageSending.getBytesArray().Length+" byte ➜ "+length+" byte");
                // #endif
                onSuccess();
            }else
                onError("SOCKET_RECEIVE_TIMEOUT");
        }else
            onError("SOCKET_LENGTH_ERROR("+length+")");
    }
    private bool Wait(int _length) {
        for (int i = 0; i < 600; i++)
            if (isRunning == false)
                return false;
            else if (tcpSocket.Available < _length) {
                Thread.Sleep(5);
            } else
                return true;
        return false;
    }

}
