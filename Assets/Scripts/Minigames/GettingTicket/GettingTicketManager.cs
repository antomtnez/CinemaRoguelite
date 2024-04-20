using UnityEngine;

public class GettingTicketManager : Minigame{
    public static GettingTicketManager Instance;
    [SerializeField] int m_Meters;
    public int Meters => m_Meters;
    [SerializeField] int m_MaxMeters;
    [SerializeField] float TimeBtwMeters;
    
    [Space(3)]
    [SerializeField] BorderSpawner m_BordersSpawner;
    [SerializeField] GameObject m_FinishLine;

    private GettingTicketPresenter m_GettingTicketPresenter;
    private GettingTicketPlayerBehaviour m_PlayerBehaviour;
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

    public override void Init(){
        base.Init();
        m_GettingTicketPresenter = new GettingTicketPresenter(this, FindObjectOfType<GettingTicketView>());     
        m_PlayerBehaviour = FindObjectOfType<GettingTicketPlayerBehaviour>();
        m_Meters = m_MaxMeters;
    }
    
    void Update(){
        if(m_IsStarted && m_Meters > 0) MoveForward();
        if(m_Meters <= 3) m_BordersSpawner.StopSpawner();
        if(m_Meters <= 0 && !m_FinishLine.activeInHierarchy) SpawnFinishLine();
    }

    public override void StartMinigame(){
        m_BordersSpawner.StartSpawner();
        Invoke("StartPlayerMove", 4f);
        m_IsStarted = true;
    }

    void StartPlayerMove(){
        m_PlayerBehaviour.EnableMove();
    }

    public void MoveForward(){
        m_CounterTime -= Time.deltaTime;

        if(m_CounterTime <= 0){
            m_CounterTime = TimeBtwMeters;
            m_Meters--;
            m_GettingTicketPresenter.UpdateMeters();
        }
    }

    public override void EndMinigame(){
        base.EndMinigame();
        m_BordersSpawner.StopSpawner();
        m_BordersSpawner.StopBorderMove();
        m_IsStarted = false;
    }

    void SpawnFinishLine(){
        m_FinishLine.SetActive(true);
    }

    public override void GetPrice(){
        CinemaGameManager.Instance.AddItem("ticket", 1);
    }

    public override bool IsGameWinned(){
        return false;
    }
}
