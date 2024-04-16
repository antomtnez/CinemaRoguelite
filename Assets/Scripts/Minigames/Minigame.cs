using System;
using UnityEngine;

public abstract class Minigame : MonoBehaviour{
    protected MinigameState m_State;
    private StartCountdown m_StartCountdown;
    public StartCountdown Countdown => m_StartCountdown;
    public event Action OnMinigameFinished;

    void Start(){
        m_State = new EnterMinigame(this);
        m_StartCountdown = FindObjectOfType<StartCountdown>();
    }

    public void ChangeState(MinigameState newState){
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

public abstract class MinigameState {
    protected Minigame m_Minigame;
    protected MinigameState m_NextState;

    public MinigameState(Minigame minigame){
        m_Minigame = minigame;
    }

    public abstract void EnterState();
    public virtual void UpdateState(){}
    public virtual void ChangeState(){
        m_Minigame.ChangeState(m_NextState);
    }
}

public class EnterMinigame : MinigameState{
    public EnterMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = new TutorialMinigame(m_Minigame);
        ChangeState();
    }
}

public class TutorialMinigame : MinigameState{
    public TutorialMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = new CowntdownToStartMinigame(m_Minigame);
    }
}

public class CowntdownToStartMinigame : MinigameState{
    public CowntdownToStartMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = new PlayingMinigame(m_Minigame);
        m_Minigame.StartCountdown();
        m_Minigame.Countdown.onCountdownFinished += ChangeState;
    }

    public override void ChangeState(){
        m_Minigame.Countdown.onCountdownFinished -= ChangeState;
        base.ChangeState();
    }
}

public class PlayingMinigame : MinigameState{
    public PlayingMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = new FinishMinigame(m_Minigame);
        m_Minigame.StartMinigame();
        m_Minigame.OnMinigameFinished += ChangeState;
    }

    public override void ChangeState(){
        m_Minigame.OnMinigameFinished -= ChangeState;
        base.ChangeState();
    }
}

public class FinishMinigame : MinigameState{
    public FinishMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = m_Minigame.IsGameWinned() ? new WinMinigame(m_Minigame) : new LoseMinigame(m_Minigame); 
        ChangeState();
    }
}

public class WinMinigame : MinigameState{
    public WinMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
    }
}

public class LoseMinigame : MinigameState{
    public LoseMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
    }
}

