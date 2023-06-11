using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDB_BaseTable{
    public short DBId;
    public short TableId;

    public long AccessKey;//Can access row=userid after login
    public long ReadKey;
    public long WriteKey;


    public void Init(short _DBId,short _TableId,long _AccessKey,long _ReadKey,long _WriteKey){
        DBId=_DBId;
        TableId=_TableId;
        AccessKey=_AccessKey;
        ReadKey=_ReadKey;
        WriteKey=_WriteKey;
    }
}
