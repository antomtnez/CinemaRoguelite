using System;
using UnityEngine;

public interface IGameScoreUpdater{
    public void UpdateScore();
}

public abstract class Minigame : MonoBehaviour {
    public static Minigame Instance;
    MinigameState m_CurrentState;
    UIPanelManager m_UIPanelManager;
    [SerializeField] Countdown m_StartCountdown;
    public Countdown StartCountdown => m_StartCountdown;

    public event Action OnMinigameFinished;

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    void Start(){
        SetComponentReferences();
        SetInitState();
    }

    void SetComponentReferences(){
        m_UIPanelManager = FindObjectOfType<UIPanelManager>();
    }

    void SetInitState(){
        ChangeState(new EnterMinigame(this));
    }

    public void ChangeState(MinigameState newState){
        m_CurrentState = newState;
        Debug.Log($"new state: {m_CurrentState.GetType().Name}");
        m_CurrentState.EnterState();
    }

    void Update(){
        m_CurrentState.UpdateState();
    }

    public void Skip(){
        m_CurrentState.ChangeState();
    }

    public void SetUIPanel(){
        m_UIPanelManager.ChangePanel(m_CurrentState.GetType().Name);
    }

    public void UpdateUI(){
        Debug.Log("update minigame UI");
        m_UIPanelManager.UpdateUI();
    }

    public abstract void StartMinigame();
    public abstract void RunMinigame();
    public abstract void EndMinigame();
    public abstract bool IsWinned();
    public virtual void GivePrice(){}
    public void SendOnMinigameFinishedCall(){
        OnMinigameFinished?.Invoke();
    }
}