using UnityEngine;

public class Spawner : Pool{
    public float TimeBtwSpawn;
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
            GetObject();
        }
    }

    public void StopSpawner(){
        m_IsStarted = false;
    }
}
