import BitUtils from '../utils/BitUtils';
import MessageReceiving from './MessageReceiving';

export default class MessageSending {
  constructor(CMD_) {
    this.CMD = BitUtils.toShort(CMD_);
    this.currentWriter = BitUtils.toShort(0);
    this.dataLength = BitUtils.toShort(0);
    this.data = null;
    this.writeShort(this.CMD);
  }

  reNew() {
    this.currentWriter = 0;
  }
  getDangerData() {
    return this.data;
  }
  avaiable() {
    return this.currentWriter;
  }
  seekEnd() {
    this.currentWriter = this.dataLength;
  }

  editBYTE(location, value) {
    this.data[location] = value;
  }
  editSHORT(location, value) {
    this.data[location] = BitUtils.toByte(value >>> 8);
    this.data[location + 1] = BitUtils.toByte(value);
  }
  editINT(location, value) {
    this.data[location] = BitUtils.toByte(value >>> 24);
    this.data[location + 1] = BitUtils.toByte(value >>> 16);
    this.data[location + 2] = BitUtils.toByte(value >>> 8);
    this.data[location + 3] = BitUtils.toByte(value);
  }
  editLONG(location, value) {
    this.data[location] = BitUtils.toByte(value >>> 56);
    this.data[location + 1] = BitUtils.toByte(value >>> 48);
    this.data[location + 2] = BitUtils.toByte(value >>> 40);
    this.data[location + 3] = BitUtils.toByte(value >>> 32);
    this.data[location + 4] = BitUtils.toByte(value >>> 24);
    this.data[location + 5] = BitUtils.toByte(value >>> 16);
    this.data[location + 6] = BitUtils.toByte(value >>> 8);
    this.data[location + 7] = BitUtils.toByte(value >>> 0);
  }
  skip(numberByte) {
    if (this.currentWriter + numberByte > this.dataLength) {
      this.dataLength = BitUtils.toShort(
        this.currentWriter + numberByte
      );
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      this.data = temp;
      this.currentWriter = this.dataLength;
    } else {
      this.currentWriter += numberByte;
    }
  }
  initBuffer(length) {
    if (this.currentWriter + length > this.dataLength) {
      this.dataLength = BitUtils.toShort(this.currentWriter + length);
      let temp = new ArrayBuffer(dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      this.data = temp;
    }
  }

  writeBoolean(value) {
    if (this.currentWriter + 1 > this.dataLength) {
      this.dataLength = BitUtils.toShort(this.currentWriter + 1);
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }

      if (value) {
        temp[this.currentWriter] = 1;
      } else {
        temp[this.currentWriter] = 0;
      }

      this.currentWriter = this.dataLength;
      this.data = temp;
    } else {
      if (value) {
        this.data[this.currentWriter] = 1;
      } else {
        this.data[this.currentWriter] = 0;
      }
      this.currentWriter++;
    }
  }

  writeByte(value) {
    if (this.currentWriter + 1 > this.dataLength) {
      this.dataLength = BitUtils.toShort(this.currentWriter + 1);
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) temp[i] = this.data[i];
      temp[this.currentWriter] = value;
      this.currentWriter = this.dataLength;
      this.data = temp;
    } else {
      this.data[this.currentWriter] = value;
      this.currentWriter++;
    }
  }
  writeShort(value) {
    if (this.currentWriter + 2 > this.dataLength) {
      this.dataLength = this.currentWriter + 2;
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      temp[this.currentWriter] = BitUtils.toByte(value >>> 8);
      temp[this.currentWriter + 1] = BitUtils.toByte(value);
      this.currentWriter = this.dataLength;
      this.data = temp;
    } else {
      this.data[this.currentWriter] = BitUtils.toByte(value >>> 8);
      this.data[this.currentWriter + 1] = BitUtils.toByte(value);
      this.currentWriter += 2;
    }
  }
  writeInt(value) {
    if (this.currentWriter + 4 > this.dataLength) {
      this.dataLength = BitUtils.toShort(this.currentWriter + 4);
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      temp[this.currentWriter] = BitUtils.toByte(value >>> 24);
      temp[this.currentWriter + 1] = BitUtils.toByte(value >>> 16);
      temp[this.currentWriter + 2] = BitUtils.toByte(value >>> 8);
      temp[this.currentWriter + 3] = BitUtils.toByte(value);
      this.currentWriter = this.dataLength;
      this.data = temp;
    } else {
      this.data[this.currentWriter] = BitUtils.toByte(value >>> 24);
      this.data[this.currentWriter + 1] = BitUtils.toByte(
        value >>> 16
      );
      this.data[this.currentWriter + 2] = BitUtils.toByte(
        value >>> 8
      );
      this.data[this.currentWriter + 3] = BitUtils.toByte(value);
      this.currentWriter += 4;
    }
  }
  writeLong(v) {
    if (this.currentWriter + 8 > this.dataLength) {
      this.dataLength = BitUtils.toShort(this.currentWriter + 8);
      let temp = new Int8Array(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      for (let i = 7; i >= 0; i--) {
        temp[this.currentWriter + i] = (Math.abs(v) < 1 && v < 0) ? BitUtils.toByte(-1) : BitUtils.toByte(v);
        v = (v > 0) ? Math.trunc(v / 256) : (Math.trunc(v / 256) - (v / 256 - Math.trunc(v / 256) !== 0));
      }
      this.currentWriter = this.dataLength;
      this.data = temp;
    } else {
      for (let i = 7; i >= 0; i--) {
        temp[this.currentWriter + i] = (Math.abs(v) < 1 && v < 0) ? BitUtils.toByte(-1) : BitUtils.toByte(v);
        v = (v > 0) ? Math.trunc(v / 256) : (Math.trunc(v / 256) - (v / 256 - Math.trunc(v / 256) !== 0));
      }
      this.currentWriter += 8;
    }
  }

  writeFloat(f) {
    var buf = new ArrayBuffer(4);
    (new Float32Array(buf))[0] = f;
    let tmpArr = (new Int32Array(buf))[0];
    
    this.writeInt(tmpArr);
  }
  //writeDouble(double v) {writeLong(Double.doubleToLongBits(v));}

  writeByteArrayWithLength(arr) {
    if (arr == null || arr.length == 0) this.writeInt(0);
    else {
      let lengthArr = arr.length;
      if (this.currentWriter + lengthArr + 4 > this.dataLength) {
        this.dataLength = BitUtils.toShort(
          this.currentWriter + lengthArr + 4
        );
        let temp = new ArrayBuffer(this.dataLength);
        for (let i = 0; i < this.currentWriter; i++) temp[i] = this.data[i];
        let value = lengthArr;
        temp[this.currentWriter] = BitUtils.toByte(value >>> 24);
        temp[this.currentWriter + 1] = BitUtils.toByte(value >>> 16);
        temp[this.currentWriter + 2] = BitUtils.toByte(value >>> 8);
        temp[this.currentWriter + 3] = BitUtils.toByte(value);
        this.currentWriter += 4;
        for (let i = 0; i < lengthArr; i++)
          temp[i + this.currentWriter] = arr[i];
        this.currentWriter = this.dataLength;
        this.data = temp;
      } else {
        let value = lengthArr;
        this.data[this.currentWriter] = BitUtils.toByte(value >>> 24);
        this.data[this.currentWriter + 1] = BitUtils.toByte(
          value >>> 16
        );
        this.data[this.currentWriter + 2] = BitUtils.toByte(
          value >>> 8
        );
        this.data[this.currentWriter + 3] = BitUtils.toByte(value);
        this.currentWriter += 4;
        for (let i = 0; i < lengthArr; i++) {
          this.data[i + this.currentWriter] = arr[i];
        }
        this.currentWriter += lengthArr;
      }
    }
  }

  writeCopyData(copyData) {
    let lengthCopy = copyData.length;
    if (this.currentWriter + lengthCopy > this.dataLength) {
      this.dataLength = BitUtils.toShort(
        this.currentWriter + lengthCopy
      );
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      for (let i = 0; i < lengthCopy; i++) {
        temp[i + this.currentWriter] = copyData[i];
      }
      this.data = temp;
      this.currentWriter = this.dataLength;
    } else {
      for (let i = 0; i < lengthCopy; i++)
        this.data[i + this.currentWriter] = copyData[i];
      this.currentWriter += lengthCopy;
    }
  }

  writeCopyData(copyData, skip, length) {
    if (this.currentWriter + length > this.dataLength) {
      this.dataLength = BitUtils.toShort(this.currentWriter + length);
      let temp = new ArrayBuffer(this.dataLength);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      for (let i = 0; i < length; i++)
        temp[i + this.currentWriter] = copyData[skip + i];
      this.data = temp;
      this.currentWriter = this.dataLength;
    } else {
      for (let i = 0; i < length; i++)
        this.data[i + this.currentWriter] = copyData[skip + i];
      this.currentWriter += length;
    }
  }

  writeMiniByte(bs) {
    if (bs == null) {
      this.writeByte(BitUtils.toByte(0));
    } else {
      this.writeByte(BitUtils.toByte(bs.length));
      this.writeCopyData(bs);
    }
  }

  writeString(value) {
    if (value == null) {
      this.writeShort(BitUtils.toShort(0));
      return;
    }
    let stringLenth = value.length;
    let j = 0;
    let k;
    for (let n = 0; n < stringLenth; n++) {
      k = value.charCodeAt(n);
      if (k >= 1 && k <= 127) {
        j++;
      } else if (k > 2047) {
        j += 3;
      } else {
        j += 2;
      }
    }

    //		if (j > 65535) {
    //			throw new UTFDataFormatException("encoded string too long: " + j + " bytes");
    //		}

    let arrayOfString = new Int8Array(j * 2 + 2);
    arrayOfString[0] = (BitUtils.toByte(j >>> 8 & 0xFF));
    arrayOfString[1] = (BitUtils.toByte(j >>> 0 & 0xFF));
    let count = 2;
    let i1 = 0;
    for (i1 = 0; i1 < stringLenth; i1++) {
      k = value.charCodeAt(i1);
      if (k < 1 || k > 127) {
        break;
      }
      arrayOfString[count++] = BitUtils.toByte(k);
    }
    while (i1 < stringLenth) {
      k = value.charCodeAt(i1);
      if (k >= 1 && k <= 127) {
        arrayOfString[count++] = BitUtils.toByte(k);
      } else if (k > 2047) {
        arrayOfString[count++] = BitUtils.toByte(
          0xe0 | ((k >> 12) & 0xf)
        );
        arrayOfString[count++] = BitUtils.toByte(
          0x80 | ((k >> 6) & 0x3f)
        );
        arrayOfString[count++] = BitUtils.toByte(
          byte(0x80 | ((k >> 0) & 0x3f))
        );
      } else {
        arrayOfString[count++] = BitUtils.toByte(
          0xc0 | ((k >> 6) & 0x1f)
        );
        arrayOfString[count++] = BitUtils.toByte(
          0x80 | ((k >> 0) & 0x3f)
        );
      }
      i1++;
    }

    let lengString = j + 2;
    if (this.currentWriter + lengString <= this.dataLength) {
      for (let i = 0; i < lengString; i++) {
        this.data[i + this.currentWriter] = arrayOfString[i];
      }
      this.currentWriter = BitUtils.toShort(
        this.currentWriter + lengString
      );
    } else {
      let temp = new Int8Array(this.currentWriter + lengString);
      for (let i = 0; i < this.currentWriter; i++) {
        temp[i] = this.data[i];
      }
      for (let i = 0; i < lengString; i++) {
        temp[i + this.currentWriter] = arrayOfString[i];
      }
      this.currentWriter = BitUtils.toShort(
        this.currentWriter + lengString
      );
      this.dataLength = this.currentWriter;
      this.data = temp;
    }
    return j + 2;
  }
}
