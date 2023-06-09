using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTable{
    public short DBId;
    public short TableId;

    public long AccessKey;//Can access row=userid after login
    public long ReadKey;
    public long WriteKey;

    public BGTable(){}
    public BGTable(short dbID,short tableId,long accessKey,long readKey,long writeKey){
        DBId=dbID;
        TableId=tableId;
        AccessKey=accessKey;
        ReadKey=readKey;
        WriteKey=writeKey;
    }
}
