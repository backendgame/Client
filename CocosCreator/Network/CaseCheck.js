var CaseCheck=cc.Class({
/** writer : richard */

  statics: {
		ERROR_LOAD_MODEL_VIN				 : -124,

		ERROR_LOAD_MODEL_BOOM				 : -122,
		ERROR_LOAD_MODEL_AIO				 : -121,
		ERROR_LOAD_HEADER					 : -120,

		TIME_NOT_ENOUGHT					 : -112,
		TIME_OUT							 : -111,
		TIME_RESET							 : -110,

		SAI_GIA_TRI_CUA_GIAO_THUC			 : -102,
		SAI_GIAO_THUC						 : -101,

		DATABASE_ERROR_ROW_DELETED			 : -89,
		DATABASE_ERROR_ROW_LENGTH			 : -88,
		DATABASE_ERROR_ROW_NOT_EXIST		 : -87,
		DATABASE_ERROR_ID_NOT_EXIST			 : -86,
		DATABASE_ERROR_FILE_NOT_FOUND		 : -85,
		DATABASE_ERROR_EXIST				 : -84,
		DATABASE_ERROR_REMOVE				 : -83,
		DATABASE_ERROR_UPDATE				 : -82,
		DATABASE_ERROR_QUERRY				 : -81,
		DATABASE_ERROR_CONNECT				 : -80,

		LOCATION_ERROR						 : -70,

		SERVERGOLD_ERROR_PROCESS			 : -61,
		SERVERGOLD_ERROR_CONNECT			 : -60,

		PLAYER_NOT_IN_TURN					 : -50,

		PLAYER_WRONG						 : -48,

		PLAYER_GOLD_INVALID					 : -46,
		PLAYER_NOT_ENOUGHT_GOLD				 : -45,
		PLAYER_LOAD_ACHIEVEMENT_ERROR		 : -44,
		PLAYER_INVALIDATE_DATA				 : -43,
		PLAYER_LOAD_ERROR					 : -42,
		PLAYER_NOT_FOUND					 : -41,
		PLAYER_ERROR						 : -40,

		VARIABLE_INVALID					 : -25,
		TOKEN_ERROR							 : -24,
		PASSWORD_ERROR						 : -23,
		SESSION_NOT_EXIST					 : -22,

		NOT_ENOUGHT							 : -20,

		EXCEPTION							 : -17,
		VALUE_SAME							 : -16,
		VALUE_POSITIVE						 : -15,
		VALUE_NEGATIVE						 : -14,
		VALUE_EXIST							 : -13,
		VALUE_NOT_EXIST						 : -12,
		VALUE_NULL							 : -11,
		VALUE_WRONG							 : -10,
		NOT_EXIST							 : -9,
		TIMEOUT								 : -8,
		EXPIRED								 : -7,
		NETWORK_ERROR						 : -6,
		SYNTAX_ERROR						 : -5,
		CANCEL								 : -4,
		CONPARE_FAIL						 : -3,
		OUT_OF_RANGE						 : -2,
		INVALID								 : -1,

		HOPLE								 : 1,
		PENDING								 : 2,
		CHANGE								 : 3,
		OLD_VALUE							 : 4,
		TEST								 : 5,
		CHECK								 : 6,
		VERIFY								 : 7,
		WAIT								 : 8,
		EXIST								 : 9,
		NO_BET								 : 10,
		WIN									 : 11,
		TIE									 : 12,
		LOSE								 : 13,
		NEW									 : 14,

		STATUS_WAIT_FOR_PLAYER				 : 20,
		STATUS_PLAYING						 : 21,
		STATUS_PROCESS_RESULT_GOLD			 : 22,
		STATUS_PROCESS_GOLD_FOR_START		 : 23,

		STATE_NONE							 : 30,
		STATE_NOT_EXIST						 : 31,
		STATE_UPDATE						 : 32,
		STATE_CHANGE_GAME					 : 33,
		STATE_GAME_PLAYING					 : 34,
		STATE_INVALIDATE					 : 35,

		STATE_PLAYER_ON_CHAIR				 : 40,
		STATE_PLAYER_NOT_ON_CHAIR			 : 41,
		STATE_PLAYER_IN_TABLE				 : 42,
		STATE_PLAYER_OUT_TABLE				 : 43,
		STATE_PLAYER_SET_BET_ERROR			 : 44,
		STATE_ERROR_GOLD					 : 45,

		CREATE								 : 60,

		INIT								 : 62,
		ADD									 : 63,
		INSERT								 : 64,
		UPDATE								 : 65,
		DELETE								 : 66,
		REMOVE								 : 67,
		DESTROY								 : 68,

		TABLE_JOIN_SUCCESS					 : 80,
		TABLE_NOT_FOUND						 : 81,
		TABLE_WRONG_PASSWORD				 : 82,
		TABLE_LAST_SESSION_EXIST			 : 83,
		TABLE_FULL_POSITION					 : 84,

		ROOM_JOIN_SUCCESS					 : 90,
		ROOM_NOT_FOUND						 : 91,
		ROOM_FULL_CREATE_PASSWORD_FAIL		 : 92,
		ROOM_PLAYNOW_FAIL					 : 93,

		SERVER_FULL							 : 100,



		getString: function(_id) {
			switch (_id) {
				case -124: return "ERROR_LOAD_MODEL_VIN(-124)";
				case -122: return "ERROR_LOAD_MODEL_BOOM(-122)";
				case -121: return "ERROR_LOAD_MODEL_AIO(-121)";
				case -120: return "ERROR_LOAD_HEADER(-120)";
				case -112: return "TIME_NOT_ENOUGHT(-112)";
				case -111: return "TIME_OUT(-111)";
				case -110: return "TIME_RESET(-110)";
				case -102: return "SAI_GIA_TRI_CUA_GIAO_THUC(-102)";
				case -101: return "SAI_GIAO_THUC(-101)";
				case -89: return "DATABASE_ERROR_ROW_DELETED(-89)";
				case -88: return "DATABASE_ERROR_ROW_LENGTH(-88)";
				case -87: return "DATABASE_ERROR_ROW_NOT_EXIST(-87)";
				case -86: return "DATABASE_ERROR_ID_NOT_EXIST(-86)";
				case -85: return "DATABASE_ERROR_FILE_NOT_FOUND(-85)";
				case -84: return "DATABASE_ERROR_EXIST(-84)";
				case -83: return "DATABASE_ERROR_REMOVE(-83)";
				case -82: return "DATABASE_ERROR_UPDATE(-82)";
				case -81: return "DATABASE_ERROR_QUERRY(-81)";
				case -80: return "DATABASE_ERROR_CONNECT(-80)";
				case -70: return "LOCATION_ERROR(-70)";
				case -61: return "SERVERGOLD_ERROR_PROCESS(-61)";
				case -60: return "SERVERGOLD_ERROR_CONNECT(-60)";
				case -50: return "PLAYER_NOT_IN_TURN(-50)";
				case -48: return "PLAYER_WRONG(-48)";
				case -46: return "PLAYER_GOLD_INVALID(-46)";
				case -45: return "PLAYER_NOT_ENOUGHT_GOLD(-45)";
				case -44: return "PLAYER_LOAD_ACHIEVEMENT_ERROR(-44)";
				case -43: return "PLAYER_INVALIDATE_DATA(-43)";
				case -42: return "PLAYER_LOAD_ERROR(-42)";
				case -41: return "PLAYER_NOT_FOUND(-41)";
				case -40: return "PLAYER_ERROR(-40)";
				case -25: return "VARIABLE_INVALID(-25)";
				case -24: return "TOKEN_ERROR(-24)";
				case -23: return "PASSWORD_ERROR(-23)";
				case -22: return "SESSION_NOT_EXIST(-22)";
				case -20: return "NOT_ENOUGHT(-20)";
				case -17: return "EXCEPTION(-17)";
				case -16: return "VALUE_SAME(-16)";
				case -15: return "VALUE_POSITIVE(-15)";
				case -14: return "VALUE_NEGATIVE(-14)";
				case -13: return "VALUE_EXIST(-13)";
				case -12: return "VALUE_NOT_EXIST(-12)";
				case -11: return "VALUE_NULL(-11)";
				case -10: return "VALUE_WRONG(-10)";
				case -9: return "NOT_EXIST(-9)";
				case -8: return "TIMEOUT(-8)";
				case -7: return "EXPIRED(-7)";
				case -6: return "NETWORK_ERROR(-6)";
				case -5: return "SYNTAX_ERROR(-5)";
				case -4: return "CANCEL(-4)";
				case -3: return "CONPARE_FAIL(-3)";
				case -2: return "OUT_OF_RANGE(-2)";
				case -1: return "INVALID(-1)";
				case 1: return "HOPLE(1)";
				case 2: return "PENDING(2)";
				case 3: return "CHANGE(3)";
				case 4: return "OLD_VALUE(4)";
				case 5: return "TEST(5)";
				case 6: return "CHECK(6)";
				case 7: return "VERIFY(7)";
				case 8: return "WAIT(8)";
				case 9: return "EXIST(9)";
				case 10: return "NO_BET(10)";
				case 11: return "WIN(11)";
				case 12: return "TIE(12)";
				case 13: return "LOSE(13)";
				case 14: return "NEW(14)";
				case 20: return "STATUS_WAIT_FOR_PLAYER(20)";
				case 21: return "STATUS_PLAYING(21)";
				case 22: return "STATUS_PROCESS_RESULT_GOLD(22)";
				case 23: return "STATUS_PROCESS_GOLD_FOR_START(23)";
				case 30: return "STATE_NONE(30)";
				case 31: return "STATE_NOT_EXIST(31)";
				case 32: return "STATE_UPDATE(32)";
				case 33: return "STATE_CHANGE_GAME(33)";
				case 34: return "STATE_GAME_PLAYING(34)";
				case 35: return "STATE_INVALIDATE(35)";
				case 40: return "STATE_PLAYER_ON_CHAIR(40)";
				case 41: return "STATE_PLAYER_NOT_ON_CHAIR(41)";
				case 42: return "STATE_PLAYER_IN_TABLE(42)";
				case 43: return "STATE_PLAYER_OUT_TABLE(43)";
				case 44: return "STATE_PLAYER_SET_BET_ERROR(44)";
				case 45: return "STATE_ERROR_GOLD(45)";
				case 60: return "CREATE(60)";
				case 62: return "INIT(62)";
				case 63: return "ADD(63)";
				case 64: return "INSERT(64)";
				case 65: return "UPDATE(65)";
				case 66: return "DELETE(66)";
				case 67: return "REMOVE(67)";
				case 68: return "DESTROY(68)";
				case 80: return "TABLE_JOIN_SUCCESS(80)";
				case 81: return "TABLE_NOT_FOUND(81)";
				case 82: return "TABLE_WRONG_PASSWORD(82)";
				case 83: return "TABLE_LAST_SESSION_EXIST(83)";
				case 84: return "TABLE_FULL_POSITION(84)";
				case 90: return "ROOM_JOIN_SUCCESS(90)";
				case 91: return "ROOM_NOT_FOUND(91)";
				case 92: return "ROOM_FULL_CREATE_PASSWORD_FAIL(92)";
				case 93: return "ROOM_PLAYNOW_FAIL(93)";
				case 100: return "SERVER_FULL(100)";
				default:return null;
			}
		}
	}
});
