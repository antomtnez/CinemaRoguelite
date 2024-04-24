using UnityEngine;

public class FallingPopcornBehaviour : Minigame, IGameScoreUpdater{
    [Header("Components")]
    [SerializeField] public Item GameRelatedItem;
    [SerializeField] IPlayerBehaviourManagable m_PlayerBehaviourManagable;
    [SerializeField] Spawner m_BadPopcornSpawner;
    [SerializeField] Spawner m_GoodPopcornSpawner;

    public override void StartMinigame(){
        SetComponentReferences();
        StartComponents();
    }

    void SetComponentReferences(){
        m_PlayerBehaviourManagable = FindObjectOfType<PlayerBehaviour>().GetComponent<IPlayerBehaviourManagable>();
    }

    void StartComponents(){
        m_BadPopcornSpawner.StartSpawner();
        m_GoodPopcornSpawner.StartSpawner();
        m_PlayerBehaviourManagable.InitBehaviour();
    }

    public override void RunMinigame(){
        if(IsWinned()) SendOnMinigameFinishedCall();
    }

    public override void EndMinigame(){
        m_BadPopcornSpawner.StopSpawner();
        m_GoodPopcornSpawner.StopSpawner();
        m_PlayerBehaviourManagable.StopBehaviour();
    }

    public void UpdateScore(){
        GameRelatedItem.Amount++;
        UpdateUI();
        if(GameRelatedItem.Amount > 0 && GameRelatedItem.Amount % 2 == 0) AddDifficult();
    }

    void AddDifficult(){
        m_BadPopcornSpawner.TimeBtwSpawn -= 0.2f;
    }

    public override bool IsWinned(){
        return GameRelatedItem.Amount == GameRelatedItem.MaxAmount;
    }
}