using System.Collections.Generic;
public class BGDB_Database{
    public short DBId;
    public string DatabaseName;
    public string Description;
    public int ViewId;
    

    public BGDB_TableAccountLogin tableAccountLogin;
    private List<BGDB_BaseTable> listTable;

    public BGDB_Database(){
        init(0,null,null,0);
    }
    public BGDB_Database(short _DBId,string _DatabaseName,string _Description,int _ViewId){
        init(_DBId,_DatabaseName,_Description,_ViewId);
    }

    private void init(short _DBId,string _DatabaseName,string _Description,int _ViewId){
        DBId=_DBId;
        DatabaseName=_DatabaseName;
        Description=_Description;
        ViewId=_ViewId;

        tableAccountLogin=null;
        listTable=new List<BGDB_BaseTable>();
    }

    public void Add(BGDB_BaseTable table){
        listTable.Add(table);
    }
}