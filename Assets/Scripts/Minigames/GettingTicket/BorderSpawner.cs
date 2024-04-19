using UnityEngine;

public class BorderSpawner : Pool{
    [SerializeField] float TimeBtwSpawn;
    private float m_Counter = 0;
    private bool m_IsStarted = false;
    private float m_NextBorderRotation = 0f;
    private GameObject m_LastBorderSpawned;


    void Update(){
        if(m_IsStarted){
            if(m_LastBorderSpawned == null || IsOnScreen(m_LastBorderSpawned.transform)){
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

    public void StartSpawner(){
        Init();
        m_IsStarted = true;
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
        m_LastBorderSpawned.GetComponent<BorderBehaviour>().SetBorderHeight(xPos);
        m_LastBorderSpawned.GetComponent<BorderBehaviour>().CloseBorderHeight(m_NextBorderRotation);
    }

    void AddDifficult(){
        m_NextBorderRotation += 3f;
    }

    bool IsOnScreen(Transform transform){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.y < 1;
    }

    public void StopSpawner(){
        m_IsStarted = false;
    }
}
