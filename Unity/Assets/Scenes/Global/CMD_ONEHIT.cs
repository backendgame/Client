public class CMD_ONEHIT{
	public const short SplashGlobal_GetList_OneHit		=1;
	public const short SplashGlobal_GetList_ServerGame_Name=2;
	public const short SplashGlobal_GetList_ServerGame_IP=3;
	public const short SplashGlobal_GetList_ServerGame_Data=4;

	public const short SplashAiO_InfoGame_Android		=40;
	public const short SplashAiO_InfoGame_IOS			=41;

	public const short SplashAiO_IAPGold_Android			=50;
	public const short SplashAiO_IAPGold_IOS				=51;
	public const short SplashAiO_IAPDiamond_Android		=52;
	public const short SplashAiO_IAPDiamond_IOS			=53;

	public const short SplashAiO_IAPInfo_Android			=80;
	public const short SplashAiO_IAPInfo_IOS				=81;

	public const short NGOCMANH_Forward_SET_LIST_DATA=150;
	public const short NGOCMANH_GET_LIST_DATA			=151;
	public const short NGOCMANH_Forward_Commit_Click		=152;

	public const short NGOCMANH_Insert_Row				=160;
	public const short NGOCMANH_Update_Row				=161;
	public const short NGOCMANH_Delete_Row				=162;
	public const short NGOCMANH_Get_List_Rows			=163;
	public const short NGOCMANH_Get_Row_By_Id			=164;

	public const short LGScreen_LoginAccount_0_Device=200;
	public const short LGScreen_LoginAccount_1_System=201;
	public const short LGScreen_LoginAccount_2_Facebook=202;
	public const short LGScreen_LoginAccount_3_Google=203;
	public const short LGScreen_LoginAccount_4_Email		=204;
	public const short LGScreen_LoginAccount_5_Apple		=205;
	public const short LGScreen_LoginAccount_6_PhoneNumber=206;

	public const short LGScreen_RegisterAccount			=220;

	public const short LGScreen_ResetPassword			=222;

	public const short LGScreen_LoginToken_0_Device		=300;
	public const short LGScreen_LoginToken_1_System		=301;
	public const short LGScreen_LoginToken_2_Facebook=302;
	public const short LGScreen_LoginToken_3_Google		=303;
	public const short LGScreen_LoginToken_4_Email		=304;
	public const short LGScreen_LoginToken_5_Apple		=305;
	public const short LGScreen_LoginToken_6_PhoneNumber=306;

	public const short HomeDB_ChangePassword				=500;
	public const short HomeDB_GetEmailSecurity			=501;
	public const short HomeDB_SetEmailSecurity			=502;

	public const short HomeDB_Change_Avatarid			=505;

	public const short HomeDB_LoginToken					=598;
	public const short HomeDB_RefreshToken				=599;

	public const short AiOHome_GetTopGold				=800;
	public const short AiOHome_GetTopDiamond				=801;
	public const short AiOHome_GetTopGoldDiamond			=802;

	public const short FirstLogin_FullData_AIO			=1000;
	public const short FirstLogin_FullData_AIO_Boom		=1001;
	public const short FirstLogin_FullData_AIO_TowerDefense=1002;
	public const short FirstLogin_FullData_AIO_Boom_TowerDefense=1003;

	public const short AiOHome_Get_Gold_By_AiOid			=1020;

	public const short AiOHome_Get_Subsidy				=1100;
	public const short AiOHome_Get_DailyBonus			=1101;

	public const short AiOHome_Get_Header_By_aioId		=1150;

	public const short AiOShop_BuyInappPurchase_Android=1200;

	public const short AiOShop_BuyInappPurchase_Ios		=1220;
	public const short AiOShop_BuyInappPurchase_Ios_test=1221;

	public const short AiOHome__GetPurchaseGoldPrice		=1250;

	public const short AiORoomTable_GetListTable_By_gameid=2901;
	public const short AiORoomTable_GetSmartTable_By_gameid=2902;

	public const short AiORoomTable_GetListViewer_in_table=2905;

	public const short Game_House_Get_Version			=2950;

	public const short GameTowerDefense_Get_Data			=3001;
	public const short GameTowerDefense_Update_Data		=3002;

	public const short BoomHome_FirstLogin_HeaderGold_FullData=3200;

	public const short BoomHome_Update_Data				=3205;

	public const short BoomHome_Unlock_ThanhTuu			=3220;
	public const short BoomHome_Commit_NhiemVu			=3221;

	public const short BoomHome_Get_DailyBonus			=3250;
	public const short BoomHome_Get_Free_By_VideoReward=3251;

	public const short BoomHome_Get_Shop_Data			=3280;
	public const short BoomHome_Shop_Character			=3281;
	public const short BoomHome_Shop_Item				=3282;
	public const short BoomHome_Shop_Skill				=3283;

	public const short VIN_Update_Android				=6000;
	public const short VIN_Update_IOS					=6001;
	public const short VIN_IAP_Android					=6002;
	public const short VIN_IAP_IOS						=6003;

	public const short VinHome_FirstLogin_FullData		=6100;
	public const short VinHome_Add_GOLD					=6101;
	public const short VinHome_Add_DIAMOND				=6102;
	public const short VinHome_Add_Egg					=6103;
	public const short VinHome_Add_Pet					=6104;
	public const short VinHome_Add_Spin					=6105;

	public const short VinHome_Add_Medal					=6120;
	public const short VinHome_Remove_Medal				=6121;

	public const short VinHome_Bonus_Daily				=6200;

	public const short VinHome_Use_Spin					=6202;
	public const short VinHome_Break_Egg					=6203;

	public const short VinHome_Create_PrivateRoom		=6800;

	public const short VinHome_Bet_Casino				=6999;

	public const short Game_Global_Get_BasePlayerInfo_BySessionid=9002;
	public const short Game_Global_Get_BasePlayerInfo_And_1_Achievement_ByUserid=9003;

	public const short Game_Global_Get_BasePlayerInfo_And_FullAchievement_ByUserid=9005;

	public const short Game_BetToWin_NoAchievement		=9200;

	public const short MySQL_DataCache_NgocManhBanner=20100;

	public const short Admin_ReloadDatabase				=30000;



	public static string getCMDName(short cmd){
		switch(cmd){
			#if TEST
			case 1: return "SplashGlobal_GetList_OneHit(1)";
			case 2: return "SplashGlobal_GetList_ServerGame_Name(2)";
			case 3: return "SplashGlobal_GetList_ServerGame_IP(3)";
			case 4: return "SplashGlobal_GetList_ServerGame_Data(4)";
			case 40: return "SplashAiO_InfoGame_Android(40)";
			case 41: return "SplashAiO_InfoGame_IOS(41)";
			case 50: return "SplashAiO_IAPGold_Android(50)";
			case 51: return "SplashAiO_IAPGold_IOS(51)";
			case 52: return "SplashAiO_IAPDiamond_Android(52)";
			case 53: return "SplashAiO_IAPDiamond_IOS(53)";
			case 80: return "SplashAiO_IAPInfo_Android(80)";
			case 81: return "SplashAiO_IAPInfo_IOS(81)";
			case 150: return "NGOCMANH_Forward_SET_LIST_DATA(150)";
			case 151: return "NGOCMANH_GET_LIST_DATA(151)";
			case 152: return "NGOCMANH_Forward_Commit_Click(152)";
			case 160: return "NGOCMANH_Insert_Row(160)";
			case 161: return "NGOCMANH_Update_Row(161)";
			case 162: return "NGOCMANH_Delete_Row(162)";
			case 163: return "NGOCMANH_Get_List_Rows(163)";
			case 164: return "NGOCMANH_Get_Row_By_Id(164)";
			case 200: return "LGScreen_LoginAccount_0_Device(200)";
			case 201: return "LGScreen_LoginAccount_1_System(201)";
			case 202: return "LGScreen_LoginAccount_2_Facebook(202)";
			case 203: return "LGScreen_LoginAccount_3_Google(203)";
			case 204: return "LGScreen_LoginAccount_4_Email(204)";
			case 205: return "LGScreen_LoginAccount_5_Apple(205)";
			case 206: return "LGScreen_LoginAccount_6_PhoneNumber(206)";
			case 220: return "LGScreen_RegisterAccount(220)";
			case 222: return "LGScreen_ResetPassword(222)";
			case 300: return "LGScreen_LoginToken_0_Device(300)";
			case 301: return "LGScreen_LoginToken_1_System(301)";
			case 302: return "LGScreen_LoginToken_2_Facebook(302)";
			case 303: return "LGScreen_LoginToken_3_Google(303)";
			case 304: return "LGScreen_LoginToken_4_Email(304)";
			case 305: return "LGScreen_LoginToken_5_Apple(305)";
			case 306: return "LGScreen_LoginToken_6_PhoneNumber(306)";
			case 500: return "HomeDB_ChangePassword(500)";
			case 501: return "HomeDB_GetEmailSecurity(501)";
			case 502: return "HomeDB_SetEmailSecurity(502)";
			case 505: return "HomeDB_Change_Avatarid(505)";
			case 598: return "HomeDB_LoginToken(598)";
			case 599: return "HomeDB_RefreshToken(599)";
			case 800: return "AiOHome_GetTopGold(800)";
			case 801: return "AiOHome_GetTopDiamond(801)";
			case 802: return "AiOHome_GetTopGoldDiamond(802)";
			case 1000: return "FirstLogin_FullData_AIO(1000)";
			case 1001: return "FirstLogin_FullData_AIO_Boom(1001)";
			case 1002: return "FirstLogin_FullData_AIO_TowerDefense(1002)";
			case 1003: return "FirstLogin_FullData_AIO_Boom_TowerDefense(1003)";
			case 1020: return "AiOHome_Get_Gold_By_AiOid(1020)";
			case 1100: return "AiOHome_Get_Subsidy(1100)";
			case 1101: return "AiOHome_Get_DailyBonus(1101)";
			case 1150: return "AiOHome_Get_Header_By_aioId(1150)";
			case 1200: return "AiOShop_BuyInappPurchase_Android(1200)";
			case 1220: return "AiOShop_BuyInappPurchase_Ios(1220)";
			case 1221: return "AiOShop_BuyInappPurchase_Ios_test(1221)";
			case 1250: return "AiOHome__GetPurchaseGoldPrice(1250)";
			case 2901: return "AiORoomTable_GetListTable_By_gameid(2901)";
			case 2902: return "AiORoomTable_GetSmartTable_By_gameid(2902)";
			case 2905: return "AiORoomTable_GetListViewer_in_table(2905)";
			case 2950: return "Game_House_Get_Version(2950)";
			case 3001: return "GameTowerDefense_Get_Data(3001)";
			case 3002: return "GameTowerDefense_Update_Data(3002)";
			case 3200: return "BoomHome_FirstLogin_HeaderGold_FullData(3200)";
			case 3205: return "BoomHome_Update_Data(3205)";
			case 3220: return "BoomHome_Unlock_ThanhTuu(3220)";
			case 3221: return "BoomHome_Commit_NhiemVu(3221)";
			case 3250: return "BoomHome_Get_DailyBonus(3250)";
			case 3251: return "BoomHome_Get_Free_By_VideoReward(3251)";
			case 3280: return "BoomHome_Get_Shop_Data(3280)";
			case 3281: return "BoomHome_Shop_Character(3281)";
			case 3282: return "BoomHome_Shop_Item(3282)";
			case 3283: return "BoomHome_Shop_Skill(3283)";
			case 6000: return "VIN_Update_Android(6000)";
			case 6001: return "VIN_Update_IOS(6001)";
			case 6002: return "VIN_IAP_Android(6002)";
			case 6003: return "VIN_IAP_IOS(6003)";
			case 6100: return "VinHome_FirstLogin_FullData(6100)";
			case 6101: return "VinHome_Add_GOLD(6101)";
			case 6102: return "VinHome_Add_DIAMOND(6102)";
			case 6103: return "VinHome_Add_Egg(6103)";
			case 6104: return "VinHome_Add_Pet(6104)";
			case 6105: return "VinHome_Add_Spin(6105)";
			case 6120: return "VinHome_Add_Medal(6120)";
			case 6121: return "VinHome_Remove_Medal(6121)";
			case 6200: return "VinHome_Bonus_Daily(6200)";
			case 6202: return "VinHome_Use_Spin(6202)";
			case 6203: return "VinHome_Break_Egg(6203)";
			case 6800: return "VinHome_Create_PrivateRoom(6800)";
			case 6999: return "VinHome_Bet_Casino(6999)";
			case 9002: return "Game_Global_Get_BasePlayerInfo_BySessionid(9002)";
			case 9003: return "Game_Global_Get_BasePlayerInfo_And_1_Achievement_ByUserid(9003)";
			case 9005: return "Game_Global_Get_BasePlayerInfo_And_FullAchievement_ByUserid(9005)";
			case 9200: return "Game_BetToWin_NoAchievement(9200)";
			case 20100: return "MySQL_DataCache_NgocManhBanner(20100)";
			case 30000: return "Admin_ReloadDatabase(30000)";
			#endif
			default : return cmd+"";
		}
	}
	public static string getCMDName(MessageSending messageSending){return getCMDName(messageSending.getCMD());}
	public static string getCMDName(MessageReceiving messageSending){return getCMDName(messageSending.getCMD());}
}