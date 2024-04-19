using UnityEngine;

public class ObstacleLine : MonoBehaviour{
    [SerializeField] GameObject RightObstacleSpawnPoint;
    [SerializeField] GameObject LeftObstacleSpawnPoint;
    [SerializeField] GameObject m_ObstacleInLine;

    public void SpawnObstacle(){
        float probability = Random.Range(0f, 9f);
        
        if(probability < 4f){
            m_ObstacleInLine.transform.position = RightObstacleSpawnPoint.transform.position;
            m_ObstacleInLine.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }else{
            m_ObstacleInLine.transform.position = LeftObstacleSpawnPoint.transform.position;
            m_ObstacleInLine.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
