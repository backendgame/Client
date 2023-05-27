var CMD_ONEHIT=cc.Class({
/** writer : richard */

  statics: {
		SplashScreen_GetList_OneHit			 : 1,
		SplashScreen_GetList_ServerGame_Name : 2,
		SplashScreen_GetList_ServerGame_IP	 : 3,
		SplashScreen_GetList_ServerGame_Data : 4,

		SplashScreen_InfoGame_Android		 : 40,
		SplashScreen_InfoGame_IOS			 : 41,

		InAppPurchase_Info_AiOGold_Android	 : 50,
		InAppPurchase_Info_AiOGold_Ios		 : 51,

		InAppPurchase_Info_BoomDiamond_Android : 60,
		InAppPurchase_Info_BoomDiamond_Ios	 : 61,

		NGOCMANH_Forward_SET_LIST_DATA		 : 150,
		NGOCMANH_GET_LIST_DATA				 : 151,
		NGOCMANH_Forward_Commit_Click		 : 152,

		NGOCMANH_Insert_Row					 : 160,
		NGOCMANH_Update_Row					 : 161,
		NGOCMANH_Delete_Row					 : 162,
		NGOCMANH_Get_List_Rows				 : 163,
		NGOCMANH_Get_Row_By_Id				 : 164,

		LGScreen_LoginAccount_0_Device		 : 200,
		LGScreen_LoginAccount_1_System		 : 201,
		LGScreen_LoginAccount_2_Facebook	 : 202,
		LGScreen_LoginAccount_3_Google		 : 203,
		LGScreen_LoginAccount_4_VinFacebook	 : 204,
		LGScreen_LoginAccount_5_Apple		 : 205,
		LGScreen_LoginAccount_6_China		 : 206,

		LGScreen_RegisterAccount			 : 220,

		LGScreen_ResetPassword				 : 229,

		HomeDB_ChangePassword				 : 500,
		HomeDB_GetEmailSecurity				 : 501,
		HomeDB_SetEmailSecurity				 : 502,

		HomeDB_Change_Avatarid				 : 505,

		AiOHome_GetTopGold					 : 800,

		AiOHome_FirstLogin_FullData			 : 1000,
		AiOHome_Get_Gold_By_AiOid			 : 1001,

		AiOHome_Get_Subsidy					 : 1100,
		AiOHome_Get_DailyBonus				 : 1101,

		AiOHome_Get_Header_By_aioId			 : 1150,

		InappPurchase_Android				 : 1200,

		InappPurchase_Ios					 : 1220,
		Test_InappPurchase_Ios				 : 1221,

		GameDatabase_GetPurchaseGoldPrice	 : 1250,

		AiORoomTable_GetListTable_By_gameid	 : 2901,
		AiORoomTable_GetSmartTable_By_gameid : 2902,

		AiORoomTable_GetListViewer_in_table	 : 2905,

		Game_House_Get_Version				 : 2950,

		GameTowerDefense_Get_Data			 : 3001,
		GameTowerDefense_Update_Data		 : 3002,

		BoomHome_FirstLogin_HeaderGold_FullData : 3200,

		BoomHome_Update_Data				 : 3205,

		BoomHome_Unlock_ThanhTuu			 : 3220,
		BoomHome_Commit_NhiemVu				 : 3221,

		BoomHome_Get_DailyBonus				 : 3250,
		BoomHome_Get_Free_By_VideoReward	 : 3251,

		BoomHome_Get_Shop_Data				 : 3280,
		BoomHome_Shop_Character				 : 3281,
		BoomHome_Shop_Item					 : 3282,
		BoomHome_Shop_Skill					 : 3283,

		VIN_Update_Android					 : 6000,
		VIN_Update_IOS						 : 6001,
		VIN_IAP_Android						 : 6002,
		VIN_IAP_IOS							 : 6003,

		VinHome_FirstLogin_FullData			 : 6100,
		VinHome_Add_GOLD					 : 6101,
		VinHome_Add_DIAMOND					 : 6102,
		VinHome_Add_Egg						 : 6103,
		VinHome_Add_Pet						 : 6104,
		VinHome_Add_Spin					 : 6105,

		VinHome_Add_Medal					 : 6120,
		VinHome_Remove_Medal				 : 6121,

		VinHome_Bonus_Daily					 : 6200,

		VinHome_Use_Spin					 : 6202,
		VinHome_Break_Egg					 : 6203,

		Game_Global_Get_BasePlayerInfo_BySessionid : 9002,
		Game_Global_Get_BasePlayerInfo_And_1_Achievement_ByUserid : 9003,

		Game_Global_Get_BasePlayerInfo_And_FullAchievement_ByUserid : 9005,

		Game_BetToWin_NoAchievement			 : 9200,

		MySQL_DataCache_NgocManhBanner		 : 20100,
		MySQL_DataCache_NgocManhKeyAds		 : 20101,
		MySQL_DataCache_NgocManhUpdate		 : 20102,

		MySQL_DataCache_InappAndroid_Purchase : 20200,

		MySQL_DataCache_InappIos_Purchase	 : 20205,
		MySQL_DataCache_InappIos_ShareSecret : 20206,

		MySQL_DataCache_ShopGold_Package	 : 20250,
		MySQL_DataCache_ShopDiamond_Package	 : 20251,

		MySQL_DataCache_UpdateAndroid		 : 20300,
		MySQL_DataCache_UpdateIos			 : 20301,

		MySQL_DataCache_ServerGame			 : 20500,
		MySQL_DataCache_ServerIp			 : 20501,
		MySQL_DataCache_ServerRoom			 : 20502,
		MySQL_DataCache_ServerOnehit		 : 20503,

		Admin_GetHeader_ByList_Offset		 : 30010,
		Admin_GetHeader_ByList_HeaderId		 : 30011,

		Admin_GetHeader_ByList_VinId		 : 30020,



		getCMDName: function(_id) {
			switch (_id) {
				case 1: return "SplashScreen_GetList_OneHit(1)";
				case 2: return "SplashScreen_GetList_ServerGame_Name(2)";
				case 3: return "SplashScreen_GetList_ServerGame_IP(3)";
				case 4: return "SplashScreen_GetList_ServerGame_Data(4)";
				case 40: return "SplashScreen_InfoGame_Android(40)";
				case 41: return "SplashScreen_InfoGame_IOS(41)";
				case 50: return "InAppPurchase_Info_AiOGold_Android(50)";
				case 51: return "InAppPurchase_Info_AiOGold_Ios(51)";
				case 60: return "InAppPurchase_Info_BoomDiamond_Android(60)";
				case 61: return "InAppPurchase_Info_BoomDiamond_Ios(61)";
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
				case 204: return "LGScreen_LoginAccount_4_VinFacebook(204)";
				case 205: return "LGScreen_LoginAccount_5_Apple(205)";
				case 206: return "LGScreen_LoginAccount_6_China(206)";
				case 220: return "LGScreen_RegisterAccount(220)";
				case 229: return "LGScreen_ResetPassword(229)";
				case 500: return "HomeDB_ChangePassword(500)";
				case 501: return "HomeDB_GetEmailSecurity(501)";
				case 502: return "HomeDB_SetEmailSecurity(502)";
				case 505: return "HomeDB_Change_Avatarid(505)";
				case 800: return "AiOHome_GetTopGold(800)";
				case 1000: return "AiOHome_FirstLogin_FullData(1000)";
				case 1001: return "AiOHome_Get_Gold_By_AiOid(1001)";
				case 1100: return "AiOHome_Get_Subsidy(1100)";
				case 1101: return "AiOHome_Get_DailyBonus(1101)";
				case 1150: return "AiOHome_Get_Header_By_aioId(1150)";
				case 1200: return "InappPurchase_Android(1200)";
				case 1220: return "InappPurchase_Ios(1220)";
				case 1221: return "Test_InappPurchase_Ios(1221)";
				case 1250: return "GameDatabase_GetPurchaseGoldPrice(1250)";
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
				case 9002: return "Game_Global_Get_BasePlayerInfo_BySessionid(9002)";
				case 9003: return "Game_Global_Get_BasePlayerInfo_And_1_Achievement_ByUserid(9003)";
				case 9005: return "Game_Global_Get_BasePlayerInfo_And_FullAchievement_ByUserid(9005)";
				case 9200: return "Game_BetToWin_NoAchievement(9200)";
				case 20100: return "MySQL_DataCache_NgocManhBanner(20100)";
				case 20101: return "MySQL_DataCache_NgocManhKeyAds(20101)";
				case 20102: return "MySQL_DataCache_NgocManhUpdate(20102)";
				case 20200: return "MySQL_DataCache_InappAndroid_Purchase(20200)";
				case 20205: return "MySQL_DataCache_InappIos_Purchase(20205)";
				case 20206: return "MySQL_DataCache_InappIos_ShareSecret(20206)";
				case 20250: return "MySQL_DataCache_ShopGold_Package(20250)";
				case 20251: return "MySQL_DataCache_ShopDiamond_Package(20251)";
				case 20300: return "MySQL_DataCache_UpdateAndroid(20300)";
				case 20301: return "MySQL_DataCache_UpdateIos(20301)";
				case 20500: return "MySQL_DataCache_ServerGame(20500)";
				case 20501: return "MySQL_DataCache_ServerIp(20501)";
				case 20502: return "MySQL_DataCache_ServerRoom(20502)";
				case 20503: return "MySQL_DataCache_ServerOnehit(20503)";
				case 30010: return "Admin_GetHeader_ByList_Offset(30010)";
				case 30011: return "Admin_GetHeader_ByList_HeaderId(30011)";
				case 30020: return "Admin_GetHeader_ByList_VinId(30020)";
				default:return null;
			}
		}
	}
});
