using UnityEngine;

public class GettingDrinkBehaviour : Minigame, IGameScoreUpdater{
    [Header("Components")]
    [SerializeField] public Item GameRelatedItem;
    [SerializeField] IPlayerBehaviourManagable m_PlayerBehaviourManagable;
    [SerializeField] DrinkSpawner m_DrinkSpawner;


    public override void StartMinigame(){
        SetComponentReferences();
        StartComponents();
    }

    void SetComponentReferences(){
        m_PlayerBehaviourManagable = FindObjectOfType<PlayerBehaviour>().GetComponent<IPlayerBehaviourManagable>();
    }

    void StartComponents(){
        m_DrinkSpawner.StartSpawner();
        m_PlayerBehaviourManagable.InitBehaviour();
    }

    public override void RunMinigame(){
        if(IsWinned()) SendOnMinigameFinishedCall();
    }

    public override void EndMinigame(){
        m_DrinkSpawner.StopSpawner();
        m_PlayerBehaviourManagable.StopBehaviour();
    }

    public void UpdateScore(){
        GameRelatedItem.Amount++;
        UpdateUI();
    }

    public override bool IsWinned(){
        return GameRelatedItem.Amount == GameRelatedItem.MaxAmount;
    }
}
