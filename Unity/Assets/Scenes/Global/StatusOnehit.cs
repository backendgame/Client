public class StatusOnehit{
	public const sbyte Success=1;
	public const sbyte Failure=2;

	public static string getString(sbyte cmd){
		switch(cmd){
			case Success: return "Success";
			case Failure: return "Failure";
			default : return cmd+"";
		}
	}

}
