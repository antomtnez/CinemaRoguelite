using UnityEngine;

public class CorridorRaceBehaviour : Minigame, IGameScoreUpdater{
    [Header("Components")]
    [SerializeField] Item GameRelatedItem;
    [SerializeField] IPlayerBehaviourManagable m_PlayerBehaviourManagable;
    [SerializeField] Spawner m_ObstacleSpawner;
    [SerializeField] GameObject m_FinishDoor;

    [Header("Behaviour Variables")]
    private float m_LengthWalked;
    [SerializeField] float m_TotalLengthToWalk;
    [SerializeField] float TimeBtwMeters;
    private float m_CounterTime;
    public float LengthWalked => m_LengthWalked;
    public float TotalLengthToWalk => m_TotalLengthToWalk;

    public override void StartMinigame(){
        SetComponentReferences();
        StartComponents();
    }

    void SetComponentReferences(){
        m_PlayerBehaviourManagable = FindObjectOfType<PlayerBehaviour>().GetComponent<IPlayerBehaviourManagable>();
    }

    void StartComponents(){
        m_LengthWalked = 0;
        m_ObstacleSpawner.StartSpawner();
        m_PlayerBehaviourManagable.InitBehaviour();
    }

    public override void RunMinigame(){
        if(m_LengthWalked < m_TotalLengthToWalk) MoveForward();
        if(m_LengthWalked >= m_TotalLengthToWalk - 2) m_ObstacleSpawner.StopSpawner();
        if(m_LengthWalked >= m_TotalLengthToWalk - 1) SpawnFinishDoor();
    }

    void MoveForward(){
        m_CounterTime -= Time.deltaTime;

        if(m_CounterTime <= 0){
            m_CounterTime = TimeBtwMeters;
            m_LengthWalked++;
            UpdateUI();
        }
    }

    void SpawnFinishDoor(){
        m_FinishDoor.SetActive(true);
    }

    public override void EndMinigame(){
        m_ObstacleSpawner.StopSpawner();
        m_PlayerBehaviourManagable.StopBehaviour();
    }

    public void UpdateScore(){
        GameRelatedItem.Amount--;
        UpdateUI();
    }

    public override bool IsWinned(){
        return m_LengthWalked >= m_TotalLengthToWalk;
    }
}