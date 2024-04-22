using UnityEngine;

public class ThrowingPopcornsManager : Minigame{
    public static ThrowingPopcornsManager Instance;
    [SerializeField] int m_Noise;
    public int Noise => m_Noise;
    [SerializeField] int m_MaxNoise;
    
    [Space(3)]
    [SerializeField] PeopleSpawner m_BadsSpawner;

    private ThrowingPopcornPresenter m_ThrowingPopcornPresenter;
    private ThrowerPlayerBehaviour m_PlayerBehaviour;
    

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }

        Init();
    }

    void Start(){
        m_Noise = m_MaxNoise;
        m_ThrowingPopcornPresenter = new ThrowingPopcornPresenter(this, FindObjectOfType<NoiseView>());     
        m_PlayerBehaviour = FindObjectOfType<ThrowerPlayerBehaviour>();
    }

    public override void StartMinigame(){
        m_BadsSpawner.StartSpawner();
        m_PlayerBehaviour.EnableMove();
    }

    public override void EndMinigame(){
        base.EndMinigame();
        m_BadsSpawner.StopSpawner();
    }

    public override bool IsGameWinned(){
        return m_Noise <= 0;
    }

    public void RemoveNoise(){
        m_Noise--;

        //if(m_Noise > 0 && m_Noise % 2 == 0) AddDifficult();

        m_ThrowingPopcornPresenter.UpdateNoise();

        if(IsGameWinned()) EndMinigame();
    }

    public override void GetPrice(){}

    void AddDifficult(){
        m_BadsSpawner.TimeBtwSpawn -= 0.2f;
    }
}
