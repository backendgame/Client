import MessageReceiving from "./MessageReceiving";
import MessageSending from "./MessageSending";
import BitUtils from "../utils/BitUtils";
import CaseCheck from "./CaseCheck";
import CMD_REALTIME from "./CMD_REALTIME";

export default class WSMoMo {
  constructor() {
    this.url = "";
    this.ws = null;
    this.sessionId = -1; //2 byte
    this.secWebSocketAccept = "";
    this.countMessageIdReceive = 0; //1 byte
    this.countMessageIdSend = 0; //1 byte

    this.isPause = false;
    this.receivingFunctions = {};
    this.listPendingFunctions = [];

    this.listCachedSend = new Array(255);
    this.lastTimeSend = 0;
    this.lastTimeReceived = 0;

    this.lastTimePing = 0;
    this.lastTimePong = 0;
    this.pingTime =0;

    this.countReconnect = 0;
    this.lastTimeReconnect = 0;
  }
  getCurrentSecond(){
    return new Date().getTime();
  }
  setReceivingFunctions(cmd, receivingFunction) {
    this.receivingFunctions[cmd] = receivingFunction;
  }
  setOnDisconnect(receivingFunction){
      this.onDisconnect = receivingFunction;
  }
  onConnectSuccess() {
    console.log("Tao ket noi thanh cong", this.sessionId);
  }

  sendConnectMessage() {
    let msgConnect = new MessageSending(-10); //goi tin dau tien
    msgConnect.writeShort(this.sessionId);
    msgConnect.writeString(this.secWebSocketAccept);
    msgConnect.writeByte(this.countMessageIdReceive);

    this.ws.send(BitUtils.toInt8Array(msgConnect));
  }

  doConnect() {
    if (this.ws != null) {
      this.ws.close();
      this.ws = null;
    }
    this.ws = new WebSocket(this.url);
    this.ws.binaryType = "arraybuffer";

    this.ws.onopen = (event) => {
      this.sendConnectMessage();
      this.onConnectSuccess();
      this.lastTimeReceived = this.getCurrentSecond();
    };
    //listening
    this.ws.onmessage = (event) => {
      this.lastTimeReceived = this.getCurrentSecond();
      let byteArray = new Int8Array(event.data);
      let msg = new MessageReceiving(byteArray, event.data.byteLength);

      if(msg.cmd==-32768){
        this.lastTimePong = this.lastTimeReceived;
        return;
      }

      if (msg.cmd === -10) {
        let caseCheck = msg.readByte();
        console.log("caseCheck: ", CaseCheck.getString(caseCheck));
        switch (caseCheck) {
          case CaseCheck.HOPLE: //first connection
            this.sessionId = msg.readShort();
            this.secWebSocketAccept = msg.readString();
            console.log(
              `${this.sessionId} ${this.validateCode} ${this.passwordSession}`
            );
            break;
          case CaseCheck.SERVER_FULL:
            console.log("Server is full!");
            this.ws.close();
            this.onDisconnect();
            break;
          case CaseCheck.CHANGE: //reconnection
            let countServerRecieve = msg.readByte();
            // console.log(`countServerRecieve: ${countServerRecieve}`);
            this.countReconnect++;
            //resend message in cached
            while (this.countMessageIdSend !== countServerRecieve) {
              countServerRecieve++;
              //let currentMsg = this.listCachedSend[countServerRecieve & 0xff];
              //send data
              // this.ws.send(BitUtils.toInt8Array(currentMsg));
            }
            break;
          default:this.ws.close();this.onDisconnect();break;
        }
      } else {
        this.countMessageIdReceive = (this.countMessageIdReceive + 1) % 256;
        console.log(
          `Reveive ${CMD_REALTIME.getCMDName(msg.cmd)}: ${
            event.data.byteLength
          } bytes`
        );

        if (this.isPause) {
          this.listPendingFunctions.push({
            func: this.receivingFunctions[msg.cmd],
            msg,
          });
        } else {
          this.receivingFunctions?.[msg.cmd]?.(msg);
        }
      }
    };

    //error
    this.ws.onerror = (event) => {
      console.log("Error: ", event.message);
    };

    //on close
    this.ws.onclose = (event) => {
      console.log("Server is closed", event);
    };
  }

  keepAlive(){
    let currentTimeSecond = this.getCurrentSecond();
    if(currentTimeSecond-this.lastTimeSend>10000){/**10 giây ping 1 lần */
      this.send(new MessageSending(-32768));
      this.lastTimePing = currentTimeSecond;
    }
  
    if(currentTimeSecond-this.lastTimeReceived>15000 && currentTimeSecond - this.lastTimeReconnect > 1000){/*Quá 15 giây không nhận được info thì đóng kết nối*/
        this.doConnect();
        this.lastTimeReconnect = currentTimeSecond;
    }

    if(this.lastTimePong>this.lastTimePing)
      this.pingTime = this.lastTimePong - this.lastTimePing;
    else
      this.pingTime = currentTimeSecond - this.lastTimePong;
  }

  send(msg) {
    this.ws.send(BitUtils.toInt8Array(msg));

    this.listCachedSend[this.countMessageIdSend] = msg;
    this.countMessageIdSend = (this.countMessageIdSend + 1) % 256;
    this.lastTimeSend = this.getCurrentSecond();
  }

  switchPause() {
    this.isPause = !this.isPause;

    if (!this.isPause) {
      this.listPendingFunctions.forEach(({ func, msg }) => {
        func?.(msg);
      });

      this.listPendingFunctions = [];
    }
  }

  onDisconnect() {
    console.log("Disconnect to the server");
  }

  onReconnect() {}
}
