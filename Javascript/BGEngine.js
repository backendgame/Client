class MessageSending{
	constructor(CMD){
		this.cmd=CMD;
		this.data=[];
		this.currentWriting=0;
	}

	writeByte(byteValue){this.data[this.currentWriting++] = byteValue & 0xFF;}
	writeShort(shortValue){
		this.data[this.currentWriting++] = (shortValue>>>8) & 0xFF;
		this.data[this.currentWriting++] = shortValue & 0xFF;
	}
	writeInt(intValue){
		this.data[this.currentWriting++] = (intValue>>>24) & 0xFF;
		this.data[this.currentWriting++] = (intValue>>>16) & 0xFF;
		this.data[this.currentWriting++] = (intValue>>>8) & 0xFF;
		this.data[this.currentWriting++] = intValue & 0xFF;
	}
	writeFloat(floatValue){
		let _dataView = new DataView(new ArrayBuffer(4));
		_dataView.setFloat32(0,floatValue,true);
		this.data[this.currentWriting++] = _dataView.getInt16(0,true);
		this.data[this.currentWriting++] = _dataView.getInt16(1,true);
		this.data[this.currentWriting++] = _dataView.getInt16(2,true);
		this.data[this.currentWriting++] = _dataView.getInt16(3,true);
	}
	writeLong(longValue){
		this.data[this.currentWriting++] = (longValue>>>56) & 0xFF;
		this.data[this.currentWriting++] = (longValue>>>48) & 0xFF;
		this.data[this.currentWriting++] = (longValue>>>40) & 0xFF;
		this.data[this.currentWriting++] = (longValue>>>32) & 0xFF;
		this.data[this.currentWriting++] = (longValue>>>24) & 0xFF;
		this.data[this.currentWriting++] = (longValue>>>16) & 0xFF;
		this.data[this.currentWriting++] = (longValue>>>8) & 0xFF;
		this.data[this.currentWriting++] = longValue & 0xFF;
	}
	writeDouble(doubleValue){
		let _dataView = new DataView(new ArrayBuffer(8));
		_dataView.setFloat64(0,doubleValue,true);
		this.data[this.currentWriting++] = _dataView.getInt16(0,true);
		this.data[this.currentWriting++] = _dataView.getInt16(1,true);
		this.data[this.currentWriting++] = _dataView.getInt16(2,true);
		this.data[this.currentWriting++] = _dataView.getInt16(3,true);
		this.data[this.currentWriting++] = _dataView.getInt16(4,true);
		this.data[this.currentWriting++] = _dataView.getInt16(5,true);
		this.data[this.currentWriting++] = _dataView.getInt16(6,true);
		this.data[this.currentWriting++] = _dataView.getInt16(7,true);
	}
}
class MessageReceiving{
	constructor(dataReceiving){
		this.arrBuffer=dataReceiving;
		this.currentreading = 2;
		this.bufferDataview = new DataView(dataReceiving);
		this.cmd = this.bufferDataview.getInt16(0,true);
	}
	readByte(){
		let byteResult = this.bufferDataview.getInt8(this.currentreading,true);
		this.currentreading++;
		return byteResult;
	}
	readShort(){
		let shortResult = this.bufferDataview.getInt16(this.currentreading,true);
		this.currentreading+=2;
		return shortResult;
	}
	readInt(){
		let intResult = this.bufferDataview.getInt32(this.currentreading,true);
		this.currentreading+=4;
		return intResult;
	}
	readLong(){
		let longResult = this.bufferDataview.getBigInt64(this.currentreading,true);
		this.currentreading+=8;
		return longResult;
	}
	readString(){
		let strLength = this.bufferDataview.getUint16(this.currentreading,true);
		let _buffStr = new DataView(this.arrBuffer, this.currentreading, strLength);
		this.currentreading+=strLength;
		return new TextDecoder("utf-8").decode(_buffStr);
	}
}


class BGWebsocket{
	#websocket;
	constructor(){
		this.isRunning=false;
		this.isPause=false;
		this.onConnectSuccess = function(){};
		this.onDisconnect = function (){};
	}
	start(_ip,_port){
		this.#websocket = new WebSocket("ws://"+_ip+":"+_port);
		this.#websocket.binaryType = "arraybuffer";
		this.#websocket.onopen = function(e) {if(this.onConnectSuccess)this.onConnectSuccess();};
		this.#websocket.onclose = function(event) {if(this.onDisconnect)this.onDisconnect();};
		
		this.#websocket.onmessage = function(event) {//
			gameEngine.lastTimeWebsocket = Date.now();
			let _data = event.data;
			if (_data instanceof ArrayBuffer) {// binary frame
				let messageReceiving = new MessageReceiving(_data);
				if(gameEngine.onWSBinary[messageReceiving.cmd])
					gameEngine.onWSBinary[messageReceiving.cmd](messageReceiving);
			}else{// text frame
				

			}
		};
		
		
		this.#websocket.onerror = function(error) {
			alert(`[error]`);
		};
	}
	setReceiver(CMD,funReceive){

	}
	send(message){}
	stop(){this.#websocket.close();}
}





/*tạo ra sự chuyển đổi giữa các màn hình*/
class GameScene {constructor(_sceneName){this.sceneName = _sceneName;}onInit(){}onUpdate(){}onRelease(){}}

class BGEngine{//Lớp cha chứa vòng lặp game
	#ctxMain;
	#canvasBuffer;
	#timeFPS;
	#countFPS;
	constructor(){
		this.onWSBinary = [];
		this.onWSString = [];
		this.gameloop = new GameScene("SceneDefault");
		this.#timeFPS = Date.now();
		this.#countFPS=0;
		this.FPS=0;
	}
	changeScene(_scene){
		let _old = this.gameloop;
		_scene.onInit();
		this.gameloop = _scene;
		_old.onRelease();
		_scene.ctx=this.ctx;
		console.log("Change Scene "+_old.sceneName+" → "+_scene.sceneName);
	}
	tickGameLoop(){
		this.ctx.fillStyle = "black";
		this.ctx.fillRect(0, 0, this.WIDTH, this.HEIGHT);
		this.gameloop.onUpdate();
		this.#ctxMain.drawImage(this.#canvasBuffer, 0, 0);//draw buffer to Main Canvas
		
		if(Date.now()-this.#timeFPS>1000){
			this.#timeFPS = Date.now();
			this.FPS = this.#countFPS;
			this.#countFPS=0;
		}else
			this.#countFPS++;
	}
	initCanvas(canvasMain){
		this.WIDTH = canvasMain.width;
		this.HEIGHT = canvasMain.height;
		///////////////////////////////Tạo ra DoubleBuffer
		if(this.#canvasBuffer)
			this.#canvasBuffer.remove();				
		this.#canvasBuffer = document.createElement('canvas');;
		this.#canvasBuffer.width = canvasMain.width;
		this.#canvasBuffer.height = canvasMain.height;
		///////////////////////////////Sử dụng context để vẽ
		this.#ctxMain = canvasMain.getContext('2d');
		this.ctx = this.#canvasBuffer.getContext('2d');
	}

	
	startRealtime(_ip,_port){
		this.websocket = new WebSocket("ws://"+_ip+":"+_port);
		this.websocket.onopen = function(e) {
			alert("[open] Connection established");
			alert("Sending to server");
			socket.send("My name is John");
		};
		this.websocket.binaryType = "arraybuffer";
		
		this.websocket.onmessage = function(event) {
			alert(`[message] Data received from server: ${event.data}`);
		};
		
		this.websocket.onclose = function(event) {
			if (event.wasClean) {
				alert(`[close] Connection closed cleanly, code=${event.code} reason=${event.reason}`);
			} else {
				// e.g. server process killed or network down
				// event.code is usually 1006 in this case
				alert('[close] Connection died');
			}
		};
		
		this.websocket.onerror = function(error) {
			alert(`[error]`);
		};
	}
	send(messageSending){
		if(this.websocket)
			if(this.websocket.readyState==WebSocket.OPEN){
				
			}else
				alert("Websocket is "+this.websocket.readyState);//CONNECTING(0) - OPEN(1) - CLOSING(2) - CLOSED(3)
		else
			alert("Websocket is not init");
	}
}

const gameEngine = new BGEngine();
const loopId = setInterval(function(){gameEngine.tickGameLoop();}, 1);//Vòng lặp game gọi mỗi 1ms
//clearInterval(gameLoop);