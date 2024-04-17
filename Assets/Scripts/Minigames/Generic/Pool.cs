using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour{
    [SerializeField] GameObject Object;
    [SerializeField] int PoolSize = 0;
    [SerializeField] List<GameObject> PoolList = new List<GameObject>();

    protected void Init(){
        for(int i = 0; i < PoolSize; i++){
            GameObject go = CreateObject();
            go.SetActive(false);
        }
    }

    public GameObject GetObject(){
        foreach(GameObject go in PoolList){
            if(!go.activeSelf){
                go.SetActive(true);
                return go;
            }
        }

        return CreateObject();
    }

    GameObject CreateObject(){
        GameObject go = Instantiate(Object, transform);
        PoolList.Add(go);
        return go;
    }
}