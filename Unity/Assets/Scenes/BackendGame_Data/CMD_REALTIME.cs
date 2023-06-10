public class CMD_REALTIME{
	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	public static string getName(MessageSending messageSending){return getName(messageSending.getCMD());}
	public static string getName(MessageReceiving messageSending){return getName(messageSending.getCMD());}
	public static string getName(short cmd){
		switch(cmd){
			default:return "CMD("+cmd+")";
		}
	}
}