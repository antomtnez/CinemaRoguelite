using UnityEngine;

public class CorridorRunManager : Minigame{
    public static CorridorRunManager Instance;
    [SerializeField] int m_Meters;
    public int Meters => m_Meters;
    [SerializeField] int m_MaxMeters;
    [SerializeField] float TimeBtwMeters;
    
    [Space(3)]
    [SerializeField] Spawner m_BadsSpawner;
    [SerializeField] GameObject m_FinishDoor;

    private CorridorRunPresenter m_CorridorRunPresenter;
    private CorridorPlayerBehaviour m_CorridorPlayerBehaviour;
    private float m_CounterTime;
    private bool m_IsStarted = false;
    

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }

        Init();
    }

    void Start(){
        m_CorridorRunPresenter = new CorridorRunPresenter(this, FindObjectOfType<MinigameScoreView>());     
        m_CorridorPlayerBehaviour = FindObjectOfType<CorridorPlayerBehaviour>();
        m_Meters = m_MaxMeters;
    }
    
    void Update(){
        if(m_IsStarted && m_Meters > 0) MoveForward();
        if(m_Meters <= 1) m_BadsSpawner.StopSpawner();
        if(m_Meters <= 0 && !m_FinishDoor.activeInHierarchy) SpawnFinishDoor();
    }

    public override void StartMinigame(){
        m_Meters = m_MaxMeters;
        m_IsStarted = true;
        m_BadsSpawner.StartSpawner();
        m_CorridorPlayerBehaviour.EnableMove();
    }

    public override void EndMinigame(){
        base.EndMinigame();
        m_IsStarted = false;
        m_BadsSpawner.StopSpawner();
        m_CorridorPlayerBehaviour.StopMove();
    }

    void SpawnFinishDoor(){
        m_FinishDoor.SetActive(true);
    }

    public override bool IsGameWinned(){
        return m_Meters <= 0;
    }

    public void MoveForward(){
        m_CounterTime -= Time.deltaTime;

        if(m_CounterTime <= 0){
            m_CounterTime = TimeBtwMeters;
            m_Meters--;
            m_CorridorRunPresenter.UpdateMeters();
        }
    }

    public override void GetPrice(){}
}
