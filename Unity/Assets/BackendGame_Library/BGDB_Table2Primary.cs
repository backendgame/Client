using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDB_Table2Primary : BGDB_BaseTable{
    public string HashName,RangeName;

    public List<BGDB_Describe> listDescribeTable;
    public BGDB_Table2Primary(short _DBId,short _TableId,string _HashName,string _RangeName,long _AccessKey,long _ReadKey,long _WriteKey){
        HashName=_HashName;
        RangeName=_RangeName;
        listDescribeTable=new List<BGDB_Describe>();
        Init(_DBId,_TableId,_AccessKey,_ReadKey,_WriteKey);
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
