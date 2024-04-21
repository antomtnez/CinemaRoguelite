using UnityEngine;

public class GettingDrinksManager : Minigame{
    public static GettingDrinksManager Instance;
    [SerializeField] int m_Drinks;
    public int Drinks => m_Drinks;
    [SerializeField] int m_MaxDrinks;
    
    [Space(3)]
    [SerializeField] Spawner m_BadsSpawner;

    private GettingDrinksPresenter m_GettingDrinksPresenter;
    private SquarePlayerBehaviour m_SquarePlayerBehaviour;
    

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }

        Init();
    }

    void Start(){
        m_GettingDrinksPresenter = new GettingDrinksPresenter(this, FindObjectOfType<MinigameScoreView>());     
        m_SquarePlayerBehaviour = FindObjectOfType<SquarePlayerBehaviour>();
    }

    public override void StartMinigame(){
        m_BadsSpawner.StartSpawner();
        m_SquarePlayerBehaviour.EnableMove();
    }

    public override void EndMinigame(){
        base.EndMinigame();
        m_BadsSpawner.StopSpawner();
    }

    public override bool IsGameWinned(){
        return m_Drinks == m_MaxDrinks;
    }

    public void AddPoints(int drink){
        m_Drinks += drink;

        m_GettingDrinksPresenter.UpdateDrinks();

        if(IsGameWinned()) EndMinigame();
    }

    public override void GetPrice(){}
}
