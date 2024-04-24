public abstract class MainGameState{
    protected MainGameManager m_MainGame;
    protected MainGameState m_NextState;

    public MainGameState(MainGameManager mainGame){
        m_MainGame = mainGame;
    }

    public virtual void EnterState(){
        m_MainGame.SetUIPanel();
    }

    public virtual void UpdateState(){}
    public virtual void ChangeState(){
        m_MainGame.ChangeState(m_NextState);
    }
}

public class CoverState : MainGameState{
    public CoverState(MainGameManager mainGame) : base(mainGame){}
    public override void EnterState(){
        base.EnterState();
        m_NextState = new CinemaState(m_MainGame);
    }
}

public class CinemaState : MainGameState{
    public CinemaState(MainGameManager mainGame) : base(mainGame){}
    public override void EnterState(){
        base.EnterState();
        m_NextState = new PlayingMinigameState(m_MainGame);
    }
}

public class PlayingMinigameState : MainGameState
{
    public PlayingMinigameState(MainGameManager mainGame) : base(mainGame){}
    public override void EnterState(){
        m_NextState = m_MainGame.IsGameLosed() ? new LoseGameState(m_MainGame) : new CinemaState(m_MainGame);
    }
}

public class FinishGameState : MainGameState{
    public FinishGameState(MainGameManager mainGame) : base(mainGame){}
}

public class LoseGameState : MainGameState{
    public LoseGameState(MainGameManager mainGame) : base(mainGame){}
}
