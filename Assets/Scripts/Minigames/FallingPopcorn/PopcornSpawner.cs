using System.Collections.Generic;
using UnityEngine;

public class PopcornSpawner : MonoBehaviour{
    [SerializeField] GameObject Popcorn;
    [SerializeField] int PoolSize = 0;
    [SerializeField] List<GameObject> PoolList = new List<GameObject>();
    [SerializeField] float TimeBtwSpawn;
    private float m_CurrentTimer;
    private bool m_IsStarted = false; 

    void Update(){
        if(m_IsStarted) Spawn();
    }

    public void StartSpawner(){
        for(int i = 0; i < PoolSize; i++){
            GameObject go = CreateObject();
            go.SetActive(false);
        }

        m_IsStarted = true;
    }

    GameObject CreateObject(){
        GameObject go = Instantiate(Popcorn, this.transform);
        PoolList.Add(go);
        return go;
    }

    void Spawn(){
        if(m_CurrentTimer > 0){
            m_CurrentTimer -= Time.deltaTime;
        }else{
            m_CurrentTimer = TimeBtwSpawn;
            GetObject();
        }
    }

    public void StopSpawner(){
        m_IsStarted = false;
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
}