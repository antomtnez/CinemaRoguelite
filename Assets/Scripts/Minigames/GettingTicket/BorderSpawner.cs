using System.Collections.Generic;
using UnityEngine;

public class BorderSpawner : Pool{
    [SerializeField] float TimeBtwSpawn;
    private float m_Counter = 0;
    private bool m_IsStarted = false;
    private float m_NextBorderRotation = 0f;
    private GameObject m_LastBorderSpawned;
    private List<ObstacleSide> m_ObstacleSideHistory = new List<ObstacleSide>();

    public void StartSpawner(){
        Init();
        m_IsStarted = true;
    }

    void Update(){
        if(m_IsStarted){
            if(m_LastBorderSpawned == null || EnterOnScreen(m_LastBorderSpawned.transform)){
                if(m_Counter < 3){
                    m_Counter++;
                }else{
                    m_Counter = 0;
                    AddDifficult();
                }
                Spawn();
                m_NextBorderRotation = 0f;
            }
        }
    }

    void Spawn(){
        float yPos = 6f;
        float xPos = 5f;
        if(m_LastBorderSpawned != null){ 
            yPos = m_LastBorderSpawned.GetComponent<BorderBehaviour>().RightEndPoint.transform.position.y;
            xPos = m_LastBorderSpawned.GetComponent<BorderBehaviour>().RightEndPoint.transform.position.x;;
        } 

        m_LastBorderSpawned = GetObject();
        m_LastBorderSpawned.transform.position = new Vector2(m_LastBorderSpawned.transform.position.x, yPos);

        BorderBehaviour newSpawnedBorderBehaviour = m_LastBorderSpawned.GetComponent<BorderBehaviour>();
        newSpawnedBorderBehaviour.SetBorderHeight(xPos);
        newSpawnedBorderBehaviour.CloseBorderHeight(m_NextBorderRotation);

        AddObstacleSideEnter(newSpawnedBorderBehaviour.SpawnTopObstacle(ChooseNextObstacleSide()));
        AddObstacleSideEnter(newSpawnedBorderBehaviour.SpawnBottomObstacle(ChooseNextObstacleSide()));
    }

    void AddDifficult(){
        m_NextBorderRotation += 3f;
    }

    bool EnterOnScreen(Transform transform){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.y < 1;
    }

    public void StopSpawner(){
        m_IsStarted = false;
    }

    public void StopBorderMove(){
        foreach(GameObject gameObject in PoolList){
            if(gameObject.activeInHierarchy) gameObject.GetComponent<BorderBehaviour>().StopBorder();
        }
    }

    void AddObstacleSideEnter(ObstacleSide obstacleSideEnter){
        if(m_ObstacleSideHistory.Count == 2)
            m_ObstacleSideHistory.Remove(m_ObstacleSideHistory[0]);

        m_ObstacleSideHistory.Add(obstacleSideEnter);
    }

    ObstacleSide ChooseNextObstacleSide(){
        if(m_ObstacleSideHistory.Count == 2 && m_ObstacleSideHistory[0] == m_ObstacleSideHistory[1])
            return m_ObstacleSideHistory[0] == ObstacleSide.Right ? ObstacleSide.Left : ObstacleSide.Right; 

        return ObstacleSide.Random;
    }
}
