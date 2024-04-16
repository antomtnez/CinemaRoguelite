using System.Collections.Generic;
using UnityEngine;

public class PopcornSpawner : MonoBehaviour{
    [SerializeField] GameObject BadPopcorn;
    [SerializeField] int PoolSize = 0;
    [SerializeField] List<GameObject> PoolList = new List<GameObject>();
    [SerializeField] float TimeBtwSpawn;
    private float m_CurrentTimer;

    void Start(){
        Init();
    }

    void Update(){
        Spawn();
    }

    void Init(){
        for(int i = 0; i < PoolSize; i++){
            GameObject go = CreateObject();
            go.SetActive(false);
        }
    }

    GameObject CreateObject(){
        GameObject go = Instantiate(BadPopcorn, this.transform);
        PoolList.Add(go);
        return go;
    }

    void Spawn(){
        if(m_CurrentTimer > 0){
            m_CurrentTimer -= Time.deltaTime;
        }else{
            m_CurrentTimer = TimeBtwSpawn;
            GameObject go = GetObject();
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

    
}
