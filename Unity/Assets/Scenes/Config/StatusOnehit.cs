public class StatusOnehit{
	public const sbyte Success	= 1;
	public const sbyte AccountNotExist	= 2;
	public const sbyte AccountExisted	= 2;
	public const sbyte PasswordIncorrect	= 3;
	public const sbyte EmailCodeIncorrect	= 4;
	public const sbyte TokenError	= 5;
	public const sbyte AccessKey	= 10;
	public const sbyte ReadKey	= 11;
	public const sbyte WriteKey	= 12;
	public const sbyte Pending	= -3;
	public const sbyte EXCEPTION	= -5;
	public const sbyte INVALID	= -6;
	public const sbyte VARIABLE_INVALID	= -7;
	public const sbyte PARAMS_INVALID	= -8;
	public const sbyte Table_Not_Exist	= -9;
	public const sbyte Database_Not_Exist	= -10;
	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	/////////////////////////////////////////////////
	public static string getString(sbyte status){
		switch(status){
			case 1:return "Success";
			case 2:return "AccountNotExist";
			case 20:return "AccountExisted";
			case 3:return "PasswordIncorrect";
			case 4:return "EmailCodeIncorrect";
			case 5:return "TokenError";
			case 10:return "AccessKey";
			case 11:return "ReadKey";
			case 12:return "WriteKey";
			case -3:return "Pending";
			case -5:return "EXCEPTION";
			case -6:return "INVALID";
			case -7:return "VARIABLE_INVALID";
			case -8:return "PARAMS_INVALID";
			case -9:return "Table_Not_Exist";
			case -10:return "Database_Not_Exist";
			default:return "Status("+status+")";
		}
	}
}