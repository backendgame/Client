using System.Collections.Generic;
public class BGTable{
    public short DBId;
    public short TableId;

    public long AccessKey;//Can access row=userid after login
    public long ReadKey;
    public long WriteKey;

    public List<BGDB_Describe> listDescribeTable;

    public BGTable(){}
    public BGTable(short dbID,short tableId,long accessKey,long readKey,long writeKey){
        DBId=dbID;
        TableId=tableId;
        AccessKey=accessKey;
        ReadKey=readKey;
        WriteKey=writeKey;
    }
}
