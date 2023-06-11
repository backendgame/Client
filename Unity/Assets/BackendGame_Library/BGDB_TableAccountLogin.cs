using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDB_TableAccountLogin{
    public short DBId;

    public long AccessKey;//Can access row=userid after login
    public long ReadKey;
    public long WriteKey;
    public List<BGDB_Describe> listDescribeTable;
    public BGDB_TableAccountLogin(short _DBId,long _AccessKey,long _ReadKey,long _WriteKey){
        Init(_DBId,_AccessKey,_ReadKey,_WriteKey);
    }

    private void Init(short _DBId,long _AccessKey,long _ReadKey,long _WriteKey){
        DBId=_DBId;
        AccessKey=_AccessKey;
        ReadKey=_ReadKey;
        WriteKey=_WriteKey;
        listDescribeTable=new List<BGDB_Describe>();
    }


    public void AddDescribe(string ColumnName,int ViewId,bool Indexing,sbyte Properties,int Size,sbyte Type,object DefaultValue){
        BGDB_Describe des = new BGDB_Describe();
        des.ColumnName=ColumnName;
        des.ViewId=ViewId;
        des.Indexing=Indexing;
        des.Properties=Properties;
        des.Size=Size;
        des.Type=Type;
        des.DefaultValue=DefaultValue;
        listDescribeTable.Add(des);
    }
}
