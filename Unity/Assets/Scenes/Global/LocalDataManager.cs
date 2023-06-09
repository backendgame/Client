using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalDataManager : MonoBehaviour{
    public PlayerData myPlayer;

    private void init(){
        myPlayer=new PlayerData();

    }



    private static LocalDataManager ins = null;
    public static LocalDataManager instance { get {
            if(ins==null){
                GameObject go = new GameObject();
                ins = go.AddComponent<LocalDataManager>();
                ins.init();
                go.name = ins.GetType().Name;
                DontDestroyOnLoad(ins);
            }
            return ins;
        }
    }
}
