using UnityEngine;

public class GettingTicketBehaviour : Minigame{
    [Header("Components")]
    [SerializeField] Item GameRelatedItem;
    [SerializeField] IPlayerBehaviourManagable m_PlayerBehaviourManagable;
    [SerializeField] BorderSpawner m_BorderSpawner;
    [SerializeField] GameObject m_FinishLine;

    [Header("Behaviour Variables")]
    private float m_LengthWalked;
    [SerializeField] float m_TotalLengthToWalk;
    [SerializeField] float TimeBtwMeters;
    private float m_CounterTime;
    public float LengthWalked => m_LengthWalked;
    public float TotalLengthToWalk => m_TotalLengthToWalk;

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    public override void StartMinigame(){
        SetComponentReferences();
        StartComponents();
    }

    void SetComponentReferences(){
        m_PlayerBehaviourManagable = FindObjectOfType<PlayerBehaviour>().GetComponent<IPlayerBehaviourManagable>();
    }

    void StartComponents(){
        m_LengthWalked = 0;
        m_BorderSpawner.StartSpawner();
        Invoke("DelayedInitPlayerBehaviour", 4f);
    }

    void DelayedInitPlayerBehaviour(){
        m_PlayerBehaviourManagable.InitBehaviour();
    }

    public override void RunMinigame(){
        if(m_LengthWalked < m_TotalLengthToWalk) MoveForward();
        if(m_LengthWalked >= m_TotalLengthToWalk - 4) m_BorderSpawner.StopSpawner();
        if(m_LengthWalked >= m_TotalLengthToWalk - 1) SpawnFinishLine();
    }

    void MoveForward(){
        m_CounterTime -= Time.deltaTime;

        if(m_CounterTime <= 0){
            m_CounterTime = TimeBtwMeters;
            m_LengthWalked++;
            UpdateUI();
        }
    }

    void SpawnFinishLine(){
        m_FinishLine.SetActive(true);
    }

    public override void EndMinigame(){
        m_BorderSpawner.StopSpawner();
        m_PlayerBehaviourManagable.StopBehaviour();
    }

    public override bool IsWinned(){
        return m_LengthWalked >= m_TotalLengthToWalk;
    }

    public override void GivePrice(){
        GameRelatedItem.Amount = GameRelatedItem.MaxAmount;
    }
}
