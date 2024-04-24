using UnityEngine;

public class ThrowingPopcornBehaviour : Minigame, IGameScoreUpdater{
    [Header("Components")]
    [SerializeField] public Item GameRelatedItem;
    [SerializeField] IPlayerBehaviourManagable m_PlayerBehaviourManagable;
    [SerializeField] PeopleSpawner m_PeopleSpawner;
    
    [Header("Behaviour Variables")]
    private float m_Noise;
    [SerializeField] float m_MaxNoise;
    public float Noise => m_Noise;
    public float MaxNoise => m_MaxNoise;

    public override void StartMinigame(){
        SetComponentReferences();
        StartComponents();
    }

    void SetComponentReferences(){
        m_PlayerBehaviourManagable = FindObjectOfType<PlayerBehaviour>().GetComponent<IPlayerBehaviourManagable>();
    }

    void StartComponents(){
        m_Noise = m_MaxNoise;
        m_PeopleSpawner.StartSpawner();
        m_PlayerBehaviourManagable.InitBehaviour();
    }

    public override void RunMinigame(){
        if(IsWinned() || IsOutOfBullets()) SendOnMinigameFinishedCall();
    }

    public override void EndMinigame(){
        m_PeopleSpawner.StopSpawner();
        m_PlayerBehaviourManagable.StopBehaviour();
    }

    public void UpdateScore(){
        m_Noise--;
        UpdateUI();
        AddDifficult();
    }

    void AddDifficult(){
        m_PeopleSpawner.TimeBtwSpawn -= .2f;
    }

    public override bool IsWinned(){
        return m_Noise <= 0;
    }

    bool IsOutOfBullets(){
        return GameRelatedItem.Amount <= 0;
    }
}