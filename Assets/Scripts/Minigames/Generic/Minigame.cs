using System;
using UnityEngine;

public abstract class Minigame : MonoBehaviour{
    protected MinigameState m_State;
    private StartCountdown m_StartCountdown;
    public StartCountdown Countdown => m_StartCountdown;
    public event Action OnMinigameFinished;

    public void Init(){
        ChangeState(new EnterMinigame(this));
        m_StartCountdown = FindObjectOfType<StartCountdown>();
    }

    public void ChangeState(MinigameState newState){
        Debug.Log($"{this.name} esta en {m_State}");
        m_State = newState;
        m_State.EnterState();
    }

    public void StartCountdown(){
        m_StartCountdown.Init();
    }

    public void SkipTutorial(){
        m_State.ChangeState();
    }

    public abstract void StartMinigame();
    public virtual void EndMinigame(){
        OnMinigameFinished?.Invoke();
    }

    public abstract bool IsGameWinned();
}