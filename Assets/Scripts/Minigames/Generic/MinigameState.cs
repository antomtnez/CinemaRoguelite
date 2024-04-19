using System;
using UnityEngine;

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
        Debug.Log($"Entro a {this.GetType().Name}");
        m_NextState = new TutorialMinigame(m_Minigame);
        ChangeState();
    }
}

public class TutorialMinigame : MinigameState{
    public TutorialMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        Debug.Log($"Entro a {this.GetType().Name}");
        m_Minigame.ActiveUI();
        m_NextState = new CountdownToStartMinigame(m_Minigame);
    }
}

public class CountdownToStartMinigame : MinigameState{
    public CountdownToStartMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        Debug.Log($"Entro a {this.GetType().Name}");
        m_Minigame.ActiveUI();
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
        Debug.Log($"Entro a {this.GetType().Name}");
        m_Minigame.ActiveUI();
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
        Debug.Log($"Entro a {this.GetType().Name}");
        m_Minigame.ActiveUI();
        
        TryToLostLife();
        
        m_NextState = m_Minigame.IsGameWinned() ? new WinMinigame(m_Minigame) : new LoseMinigame(m_Minigame); 
        ChangeState();
    }

    void TryToLostLife(){
        try{
            CinemaGameManager.Instance.LostLife();
        }catch(Exception e){
            Debug.LogWarning(e);
        }
    }
}

public class WinMinigame : MinigameState{
    public WinMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        Debug.Log($"Entro a {this.GetType().Name}");
        m_Minigame.GetPrice();
    }
}

public class LoseMinigame : MinigameState{
    public LoseMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        Debug.Log($"Entro a {this.GetType().Name}");
    }
}
