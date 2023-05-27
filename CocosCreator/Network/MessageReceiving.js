// import MessageSending from "./MessageSending";
import BitUtils from '../utils/BitUtils';

export default class MessageReceiving {
  constructor(DATA, _dataLength) {
    /*Phần này của realtime*/
    //		CMD=cmd;
    this.dataLength = BitUtils.toShort(_dataLength);
    this.currentReading = 0;
    this.buffer = DATA;
    this.isMessageCorrect = true;
    this.cmd = this.readShort();
  }

  avaiable() {
    return this.dataLength - this.currentReading;
  }
  getEndByte() {
    let lengClone = this.dataLength - this.currentReading;
    if (lengClone < 1) {
      return null;
    }
    let dataClone = new ArrayBuffer(lengClone);
    for (let i = 0; i < lengClone; i++) {
      dataClone[i] = this.buffer[i + this.currentReading];
    }
    return dataClone;
  }
  cloneSending(_cmd_) {
    let mgClone = new MessageSending(_cmd_);
    mgClone.writeCopyData(this.buffer, 0, this.dataLength);
    return mgClone;
  }

  startBeginRead() {
    this.currentReading = 0;
  }
  validate() {
    return this.isMessageCorrect && this.dataLength - this.currentReading == 0;
  }
  isCorrect() {
    return this.isMessageCorrect;
  }
  reSet() {
    this.currentReading = 0;
    this.isMessageCorrect = true;
  }
  discoveryByte() {
    return this.buffer[this.currentReading];
  }

  readBoolean() {
    if (this.currentReading + 1 > this.dataLength) {
      this.isMessageCorrect = false;
      return false;
    } else return this.buffer[this.currentReading++] != 0;
  }

  readByte() {
    if (this.currentReading + 1 > this.dataLength) {
      this.isMessageCorrect = false;
      return 0;
    } else return this.buffer[this.currentReading++];
  }

  readShort() {
    if (this.currentReading + 2 > this.dataLength) {
      this.isMessageCorrect = false;
      return 0;
    } else {
      let ch1 = this.buffer[this.currentReading] & 0xff;
      let ch2 = this.buffer[this.currentReading + 1] & 0xff;
      this.currentReading += 2;
      return BitUtils.toShort((ch1 << 8) + (ch2 << 0));
    }
  }

  readInt() {
    if (this.currentReading + 4 > this.dataLength) {
      this.isMessageCorrect = false;
      return 0;
    } else {
      let ch1 = this.buffer[this.currentReading] & 0xff;
      let ch2 = this.buffer[this.currentReading + 1] & 0xff;
      let ch3 = this.buffer[this.currentReading + 2] & 0xff;
      let ch4 = this.buffer[this.currentReading + 3] & 0xff;
      this.currentReading += 4;
      return (ch1 << 24) + (ch2 << 16) + (ch3 << 8) + (ch4 << 0);
    }
  }

  readLong() { 
    if (this.currentReading + 8 > this.dataLength) {
      this.isMessageCorrect = false;
      return 0;
    } else {
      let l0 = this.buffer[this.currentReading] & 0xff;
      let l1 = this.buffer[this.currentReading + 1] & 0xff;
      let l2 = this.buffer[this.currentReading + 2] & 0xff;
      let l3 = this.buffer[this.currentReading + 3] & 0xff;
      let l4 = this.buffer[this.currentReading + 4] & 0xff;
      let l5 = this.buffer[this.currentReading + 5] & 0xff;
      let l6 = this.buffer[this.currentReading + 6] & 0xff;
      let l7 = this.buffer[this.currentReading + 7] & 0xff;
      this.currentReading += 8;

      let r0 = l0 << 56;        //will be overflow
      let r1 = l1 << 48;
      let r2 = l2 << 40;
      let r3 = l3 << 32;
      let r4 = l4 << 24;
      let r5 = l5 << 16;
      let r6 = l6 << 8;
      let r7 = l7;
      let ans = r0 + r1 + r2 + r3 + r4 + r5 + r6 + r7;
      return (ans > 0) ? ans : ans + 1;
    }
  }

  readFloat(){
    if (this.currentReading + 4 > this.dataLength){
      this.isMessageCorrect = false;
      return 0;
    }
    let arr = new ArrayBuffer(4);
    const view = new DataView(arr);
    for(let i = 0; i < 4; i++){
      console.log(i, this.buffer[this.currentReading + i]);
      view.setInt8(i, this.buffer[this.currentReading + i]);
    }
    
    //move currentReading
    this.currentReading+=4;
    return view.getFloat32(0);

  }

  // public final double readDouble() {return Double.longBitsToDouble(readLong());}
  readArrayByte(numberByte) {
    if (numberByte < 1) return null;
    else if (this.currentReading + numberByte > this.dataLength) {
      this.isMessageCorrect = false;
      return null;
    } else {
      let result = new ArrayBuffer(numberByte);
      for (let i = 0; i < numberByte; i++) {
        result[i] = this.buffer[this.currentReading + i];
      }
      this.currentReading += numberByte;
      return result;
    }
  }
  readString() {
    if (this.dataLength - this.currentReading < 2) {
      this.isMessageCorrect = false;
      return "";
    }
    let utflen =
      ((this.buffer[this.currentReading] & 0xff) << 8) |
      (this.buffer[this.currentReading + 1] & 0xff);
    if (this.dataLength - this.currentReading < utflen + 2) {
      this.isMessageCorrect = false;
      return "";
    }
    let bytearr = null;
    let chararr = null;
    //		if(data.length<utflen){
    bytearr = new ArrayBuffer(utflen * 2);
    chararr = new ArrayBuffer(utflen * 2);
    //		}

    let c, char2, char3;
    let count = 0;
    let chararr_count = 0;

    for (let i = 0; i < utflen; i++) {
      bytearr[i] = this.buffer[i + this.currentReading + 2];
    }

    this.currentReading = BitUtils.toShort(
      this.currentReading + utflen + 2
    );

    while (count < utflen) {
      c = parseInt(bytearr[count] & 0xff);
      if (c > 127) break;
      count++;
      chararr[chararr_count++] = String.fromCharCode(c);
    }

    while (count < utflen) {
      c = parseInt(bytearr[count] & 0xff);
      switch (c >> 4) {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
          /* 0xxxxxxx*/
          count++;
          chararr[chararr_count++] = String.fromCharCode(c);
          break;
        case 12:
        case 13:
          /* 110x xxxx   10xx xxxx*/
          count += 2;
          if (count > utflen) {
            //						throw new UTFDataFormatException("malformed input: partial character at end");
            return "";
          }
          char2 = parseInt(bytearr[count - 1]);
          if ((char2 & 0xc0) != 0x80) {
            //						throw new UTFDataFormatException("malformed input around byte " + count);
            return "";
          }
          chararr[chararr_count++] = String.fromCharCode(
            ((c & 0x1f) << 6) | (char2 & 0x3f)
          );
          break;
        case 14:
          /* 1110 xxxx  10xx xxxx  10xx xxxx */
          count += 3;
          if (count > utflen) {
            //						throw new UTFDataFormatException("malformed input: partial character at end");
            return "";
          }
          char2 = parseInt(bytearr[count - 2]);
          char3 = parseInt(bytearr[count - 1]);
          if ((char2 & 0xc0) != 0x80 || (char3 & 0xc0) != 0x80) {
            //						throw new UTFDataFormatException("malformed input around byte " + (count-1));
            return "";
          }
          chararr[chararr_count++] = String.fromCharCode(
            ((c & 0x0f) << 12) | ((char2 & 0x3f) << 6) | ((char3 & 0x3f) << 0)
          );
          break;
        default:
          /* 10xx xxxx,  1111 xxxx */
          //					throw new UTFDataFormatException("malformed input around byte " + count);
          return "";
      }
    }
    // The number of chars produced may be less than utflen
    let str = "";
    for (let i = 0; i < chararr_count; i++) {
      str += chararr[i];
    }

    return str;
  }
}
