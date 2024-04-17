using UnityEngine;

public class MinigamePresenter{
    private Minigame m_MinigameManager;
    private MinigameView m_MinigameView;

    public MinigamePresenter(Minigame minigame, MinigameView minigameView){
        m_MinigameManager = minigame;
        m_MinigameView = minigameView;
    }

    public void ShowUIScreen(){
        m_MinigameView.ActivePanel(m_MinigameManager.State.ToString());
    }
}
