using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : Pool {
    public float TimeBtwSpawn;
    [SerializeField] List<GameObject> SpawnPoints = new List<GameObject>();
    private float m_CurrentTimer;
    private bool m_IsStarted = false; 

    void Update(){
        if(m_IsStarted) Spawn();
    }

    public void StartSpawner(){
        Init();
        m_IsStarted = true;
    }

    void Spawn(){
        if(m_CurrentTimer > 0){
            m_CurrentTimer -= Time.deltaTime;
        }else{
            m_CurrentTimer = TimeBtwSpawn;
            GetObject().transform.position = SetRandomPosition();
        }
    }

    public void StopSpawner(){
        m_IsStarted = false;
    }

    Vector3 SetRandomPosition(){
        int randomPosition = Random.Range(0, SpawnPoints.Count);
        return SpawnPoints[randomPosition].transform.position;
    }
}