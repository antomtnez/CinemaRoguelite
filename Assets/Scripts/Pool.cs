using System.Collections.Generic;
using UnityEngine;

public abstract class Pool : MonoBehaviour, IPool{
    [SerializeField] GameObject Object;
    [SerializeField] int PoolSize = 0;
    [SerializeField] List<GameObject> PoolList = new List<GameObject>();

    void Init(){
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

    public void ReturnObject(GameObject go){}

    GameObject CreateObject(){
        GameObject go = Instantiate(Object);
        PoolList.Add(go);
        return go;
    }
}