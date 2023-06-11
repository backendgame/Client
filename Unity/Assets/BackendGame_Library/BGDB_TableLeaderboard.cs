using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDB_TableLeaderboard : BGDB_BaseTable{
    public BGDB_TableLeaderboard(short _DBId,short _TableId,long _AccessKey,long _ReadKey,long _WriteKey){
        Init(_DBId,_TableId,_AccessKey,_ReadKey,_WriteKey);
    }
}
