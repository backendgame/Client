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
        database.tableAccountLogin = new BGDB_TableAccountLogin();
        //database.tableAccountLogin.setupAddDescribe();

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
