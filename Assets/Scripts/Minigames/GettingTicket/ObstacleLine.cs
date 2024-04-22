using UnityEngine;

public enum ObstacleSide { Right, Left, Random }

public class ObstacleLine : MonoBehaviour{
    [SerializeField] GameObject RightObstacleSpawnPoint;
    [SerializeField] GameObject LeftObstacleSpawnPoint;
    [SerializeField] GameObject m_ObstacleInLine;

    public ObstacleSide SpawnObstacle(ObstacleSide obstacleSide){

        if(obstacleSide == ObstacleSide.Right) SpawnRightSide();
        if(obstacleSide == ObstacleSide.Left) SpawnLeftSide();
        if(obstacleSide == ObstacleSide.Random) {
            float probability = Random.Range(0f, 9f);
        
            if(probability < 4f){
                SpawnRightSide();
                return ObstacleSide.Right;
            }else{
                SpawnLeftSide();
                return ObstacleSide.Left;
            }
        }

        return obstacleSide;
    }

    void SpawnRightSide(){
        m_ObstacleInLine.transform.position = RightObstacleSpawnPoint.transform.position;
        m_ObstacleInLine.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void SpawnLeftSide(){
        m_ObstacleInLine.transform.position = LeftObstacleSpawnPoint.transform.position;
        m_ObstacleInLine.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
    }
}
