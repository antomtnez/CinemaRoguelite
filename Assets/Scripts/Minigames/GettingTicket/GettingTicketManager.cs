using UnityEngine;

public class GettingTicketManager : Minigame{
    public static GettingTicketManager Instance;
    [SerializeField] int m_Meters;
    public int Meters => m_Meters;
    [SerializeField] int m_MaxMeters;
    [SerializeField] float TimeBtwMeters;
    
    [Space(3)]
    [SerializeField] Spawner m_BadsSpawner;

    private GettingTicketPresenter m_GettingTicketPresenter;
    private PlayerBehaviour m_PlayerBehaviour;
    private float m_CounterTime;
    

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }

        Init();
    }

    void Start(){
        m_GettingTicketPresenter = new GettingTicketPresenter(this, FindObjectOfType<GettingTicketView>());     
        m_PlayerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }
    
    void Update(){
        MoveForward();
    }

    public override void StartMinigame(){
        m_Meters = m_MaxMeters;
        m_BadsSpawner.StartSpawner();
        m_PlayerBehaviour.EnableMove();
    }

    public override void EndMinigame(){
        base.EndMinigame();
        m_BadsSpawner.StopSpawner();
    }

    public override bool IsGameWinned(){
        return m_Meters <= 0;
    }

    public void MoveForward(){
        m_CounterTime -= Time.deltaTime;

        if(m_CounterTime <= 0){
            m_CounterTime = TimeBtwMeters;
            m_Meters--;
            m_GettingTicketPresenter.UpdateMeters();
        }
        
        if(IsGameWinned()) EndMinigame();
    }
}
