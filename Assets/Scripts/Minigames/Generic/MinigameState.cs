using System;
using UnityEngine;

public abstract class MinigameState {
    protected Minigame m_Minigame;
    protected MinigameState m_NextState;

    public MinigameState(Minigame minigame){
        m_Minigame = minigame;
    }

    public virtual void EnterState(){
        m_Minigame.SetUIPanel();
    }
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
        m_NextState = new CountdownToStartMinigame(m_Minigame);
        base.EnterState();
    }
}

public class CountdownToStartMinigame : MinigameState{
    public CountdownToStartMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = new PlayingMinigame(m_Minigame);
        base.EnterState();
        m_Minigame.StartCountdown.Init();
        m_Minigame.StartCountdown.OnCountdownFinished += ChangeState;
    }

    public override void ChangeState(){
        m_Minigame.StartCountdown.OnCountdownFinished -= ChangeState;
        base.ChangeState();
    }
}

public class PlayingMinigame : MinigameState{
    public PlayingMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_NextState = new FinishMinigame(m_Minigame);
        m_Minigame.StartMinigame();
        base.EnterState();
        m_Minigame.OnMinigameFinished += ChangeState;
    }

    public override void UpdateState(){
        m_Minigame.RunMinigame();
    }

    public override void ChangeState(){
        m_Minigame.OnMinigameFinished -= ChangeState;
        base.ChangeState();
    }
}

public class FinishMinigame : MinigameState{
    public FinishMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_Minigame.EndMinigame();
        TryToLostLife();
        
        m_NextState = m_Minigame.IsWinned() ? new WinMinigame(m_Minigame) : new LoseMinigame(m_Minigame); 
        ChangeState();
    }

    void TryToLostLife(){
        try{
            MainGameManager.Instance.LostLife();
        }catch(Exception e){
            Debug.LogWarning(e);
        }
    }
}

public class WinMinigame : MinigameState{
    public WinMinigame(Minigame minigame) : base(minigame){}

    public override void EnterState(){
        m_Minigame.GivePrice();
        base.EnterState();
    }
}

public class LoseMinigame : MinigameState{
    public LoseMinigame(Minigame minigame) : base(minigame){}
}
