public class BGDescribe{
	public string ColumnName;
	public int ViewId;
	public bool Indexing;
	public sbyte Properties;
	public int Size;
	public sbyte Type;
	public object DefaultValue;

    public void readMessage(MessageReceiving messageReceiving){
        ColumnName=messageReceiving.readString();
        ViewId=messageReceiving.readInt();
        Indexing=messageReceiving.readBoolean();
        Properties=messageReceiving.readByte();
        Size=messageReceiving.readInt();
        Type=messageReceiving.readByte();
		if(0<Type && Type<10)
			DefaultValue = messageReceiving.readBoolean();
		else if(9<Type && Type<20)
			DefaultValue = messageReceiving.readByte();
		else if(19<Type && Type<40)
			DefaultValue = messageReceiving.readShort();
		else if(39<Type && Type<60)
			DefaultValue = messageReceiving.readInt();
		else if(59<Type && Type<80)
			DefaultValue = messageReceiving.readFloat();
		else if(79<Type && Type<90)
			DefaultValue = messageReceiving.readLong();
		else if(89<Type && Type<100)
			DefaultValue = messageReceiving.readDouble();
		else if(99<Type && Type<120)
			DefaultValue = messageReceiving.readByteArray();
		else if(Type==DBDefine_DataType.STRING) {
			DefaultValue = messageReceiving.readString();
		}else if(Type==DBDefine_DataType.IPV6)
			DefaultValue = messageReceiving.readSpecialArray_WithoutLength(16);
    }

	public void writeMessage(MessageSending messageSending) {
		messageSending.writeString(ColumnName);
		messageSending.writeInt(ViewId);
		messageSending.writeBoolean(Indexing);
		messageSending.writeByte(Properties);
		messageSending.writeInt(Size);
		messageSending.writeByte(Type);
		if(0<Type && Type<10)
			messageSending.writeBoolean((bool) DefaultValue);
		else if(9<Type && Type<20)
			messageSending.writeByte((byte) DefaultValue);
		else if(19<Type && Type<40)
			messageSending.writeShort((short) DefaultValue);
		else if(39<Type && Type<60)
			messageSending.writeInt((int) DefaultValue);
		else if(59<Type && Type<80)
			messageSending.writeFloat((float) DefaultValue);
		else if(79<Type && Type<90)
			messageSending.writeLong((long) DefaultValue);
		else if(89<Type && Type<100)
			messageSending.writeDouble((double) DefaultValue);
		else if(99<Type && Type<120)
			messageSending.writeByteArray((byte[]) DefaultValue);
		else if(Type==DBDefine_DataType.STRING) {
			messageSending.writeString((string) DefaultValue);
		}else if(Type==DBDefine_DataType.IPV6)
			messageSending.writeSpecialArray_WithoutLength((byte[]) DefaultValue);
	}
}
