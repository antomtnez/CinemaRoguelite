using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Minigame : MonoBehaviour{
    protected MinigameState m_State;
    public MinigameState State => m_State;
    private StartCountdown m_StartCountdown;
    public StartCountdown Countdown => m_StartCountdown;
    public event Action OnMinigameFinished;
    private MinigamePresenter m_MinigamePresenter;

    public void Init(){
        m_StartCountdown = FindObjectOfType<StartCountdown>();
        m_MinigamePresenter = new MinigamePresenter(this, FindObjectOfType<MinigameView>());
        ChangeState(new EnterMinigame(this));
    }

    public void ChangeState(MinigameState newState){
        Debug.Log($"{this.name} esta en {m_State}");
        m_State = newState;
        m_State.EnterState();
    }

    public void ActiveUI(){
        m_MinigamePresenter.ShowUIScreen();
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
    public abstract void GetPrice();

    public void ReturnToCinema(){
        SceneManager.LoadScene("Cinema");
    }
}