using UnityEngine;

public class FallingPopcornManager : Minigame{
    public static FallingPopcornManager Instance;
    [SerializeField] int m_Points;
    public int Points => m_Points;
    [SerializeField] int m_PointsToWin;
    
    [Space(3)]
    [SerializeField] Spawner m_BadsSpawner;
    [SerializeField] Spawner m_GoodsSpawner;

    private FallingPopcornPresenter m_FallingPopcornPresenter;
    private PlayerBehaviour m_PlayerBehaviour;
    

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }

        Init();
    }

    void Start(){
        m_FallingPopcornPresenter = new FallingPopcornPresenter(this, FindObjectOfType<FallingPopcornView>());     
        m_PlayerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    public override void StartMinigame(){
        m_Points = 0;
        m_BadsSpawner.StartSpawner();
        m_GoodsSpawner.StartSpawner();
        m_PlayerBehaviour.EnableMove();
    }

    public override void EndMinigame(){
        base.EndMinigame();
        m_BadsSpawner.StopSpawner();
        m_GoodsSpawner.StopSpawner();
    }

    public override bool IsGameWinned(){
        return m_Points >= m_PointsToWin;
    }

    public void AddPoints(int points){
        m_Points += points;
        m_FallingPopcornPresenter.UpdatePoints();

        if(IsGameWinned()) EndMinigame();
    }
}