using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGDB_BaseTable{
    public short DBId;
    public short TableId;

    public long AccessKey;//Can access row=userid after login
    public long ReadKey;
    public long WriteKey;
}
