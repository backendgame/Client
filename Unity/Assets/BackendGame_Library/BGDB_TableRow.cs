using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDB_TableRow : BGDB_BaseTable
{
    public List<BGDB_Describe> listDescribeTable;
    public BGDB_TableRow(short _DBId,short _TableId,long _AccessKey,long _ReadKey,long _WriteKey){
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
