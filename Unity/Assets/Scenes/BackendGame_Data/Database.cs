using System.Collections.Generic;
public class Database{
    public List<BGDB_Database> listDatabase;
    private Database(){
        BGDB_Database database;
        BGDB_Table1Primary table1Primary;
        BGDB_Table2Primary table2Primary;
        BGDB_TableRow tableRow;
        BGDB_TableLineNode tableLineNode;
        BGDB_TableLeaderboard tableLeaderboard;
        listDatabase=new List<BGDB_Database>();

        database=new BGDB_Database(1,"AAA","BBB",234);
        database.tableAccountLogin = new BGDB_TableAccountLogin(database.DBId,123,4456,789);
        database.tableAccountLogin.AddDescribe("AvatarId",123,false,0,1,BG_DataType.AVARTAR,1);
        listDatabase.Add(database);

        table1Primary=new BGDB_Table1Primary(database.DBId,0,"PrimaryName",123,4456,789);
        table1Primary.AddDescribe("AvatarId",123,false,0,1,BG_DataType.AVARTAR,1);
        database.Add(table1Primary);

        table2Primary=new BGDB_Table2Primary(database.DBId,0,"HashName","RangeName",123,4456,789);
        table2Primary.AddDescribe("AvatarId",123,false,0,1,BG_DataType.AVARTAR,1);
        database.Add(table2Primary);

        tableRow = new BGDB_TableRow(database.DBId,11,123,4456,789);
        tableRow.AddDescribe("AvatarId",123,false,0,1,BG_DataType.AVARTAR,1);
        database.Add(tableRow);

        tableLineNode = new BGDB_TableLineNode(database.DBId,11,123,4456,789);
        database.Add(tableRow);

        tableLeaderboard = new BGDB_TableLeaderboard(database.DBId,11,123,4456,789);
        database.Add(tableRow);





		database=new BGDB_Database(1,"Test AAA","BBBB",123);
		database.tableAccountLogin = new BGDB_TableAccountLogin(1,0,0,0);
		database.tableAccountLogin.AddDescribe("NameShow",0,false,0,17,126,User can change);
		database.tableAccountLogin.AddDescribe("AvatarId",0,false,0,1,10,null);
		database.tableAccountLogin.AddDescribe("DeviceType",0,false,0,1,10,null);
		database.tableAccountLogin.AddDescribe("Gold",0,false,0,8,80,null);
		listDatabase.Add(database);
    }

    

    private static Database ins = null;
    public static Database instance{
        get{
            if (ins == null){
                ins = new Database();
            }
            return ins;
        }
    }
}
