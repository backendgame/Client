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
        length = length - 2;
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
            onError("ERROR(Protocol)");
            return;
        }

        networkStream.Read(datatransfer, 0, 4);
        int ch1 = datatransfer[0] & 0xFF;
        int ch2 = datatransfer[1] & 0xFF;
        int ch3 = datatransfer[2] & 0xFF;
        int ch4 = datatransfer[3] & 0xFF;
        length = ((ch1 << 24) + (ch2 << 16) + (ch3 << 8) + (ch4 << 0));
        if(length==0){
            onSuccess();
            return;
        }else if(length==-7){
            onError("ERROR(CMD not found)");
            return;
        }else if (length < 0){
            onError("Server SOCKET_LENGTH_ERROR("+length+")");
            return;
        }

        if(length+4>NetworkGlobal.SOCKET_BUFFER){
            datatransfer = new byte[length+2];
            int count = NetworkGlobal.SOCKET_BUFFER - 4;
            if(Wait(count)){
                networkStream.Read(datatransfer, 0, count);
                networkStream.WriteByte(0);
            }else{
                onError("SOCKET_RECEIVE_TIMEOUT");
                return;
            }

            while(count+NetworkGlobal.SOCKET_BUFFER<length)
                if(Wait(NetworkGlobal.SOCKET_BUFFER)){
                    networkStream.Read(datatransfer, count, NetworkGlobal.SOCKET_BUFFER);
                    networkStream.WriteByte(0);
                    count+=NetworkGlobal.SOCKET_BUFFER;
                }else{
                    onError("SOCKET_RECEIVE_TIMEOUT");
                    return;
                }

            if(Wait(length-count)){
                networkStream.Read(datatransfer, count, length-count);
            }else{
                onError("SOCKET_RECEIVE_TIMEOUT");
                return;
            }

            for(int i=length-1;i>=0;i--)
                datatransfer[i+2]=(byte)(datatransfer[i]^validateCode);

            messageReceiving=new MessageReceiving(datatransfer);
            messageReceiving.cmd = messageSending.getCMD();
            messageReceiving.timeProcess = DateTimeUtil.currentUtcTimeMilliseconds-timeBeginProcess;
            onSuccess();
        }else{
            datatransfer = new byte[length+2];
            if (Wait(length)){
                networkStream.Read(datatransfer, 2, length);
                for (short i = 0; i < length; i++)
                    datatransfer[i + 2] = (byte)(datatransfer[i + 2] ^ validateCode);

                messageReceiving=new MessageReceiving(datatransfer);
                messageReceiving.cmd = messageSending.getCMD();
                messageReceiving.timeProcess = DateTimeUtil.currentUtcTimeMilliseconds-timeBeginProcess;
                onSuccess();
            }else{
                onError("SOCKET_RECEIVE_TIMEOUT");
                return;
            }
        }



        // datatransfer = new byte[length + 2];
        // if (length > -1) {
        //     if (Wait(length)){
        //         networkStream.Read(datatransfer, 2, length);
        //         for (short i = 0; i < length; i++)
        //             datatransfer[i + 2] = (byte)(datatransfer[i + 2] ^ validateCode);
        //         messageReceiving=new MessageReceiving(datatransfer);
        //         messageReceiving.cmd = messageSending.getCMD();
        //         messageReceiving.timeProcess = DateTimeUtil.currentUtcTimeMilliseconds-timeBeginProcess;
        //         onSuccess();
        //     }else
        //         onError("SOCKET_RECEIVE_TIMEOUT");
        // }else
        //     onError("Server SOCKET_LENGTH_ERROR("+length+")");
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
