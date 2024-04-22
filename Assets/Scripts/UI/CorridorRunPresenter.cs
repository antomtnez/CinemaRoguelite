using UnityEngine;

public class CorridorRunPresenter{
    
    private CorridorRunManager m_CorridorRunManager;
    private MinigameScoreView m_View;

    public CorridorRunPresenter(CorridorRunManager manager, MinigameScoreView view){
        m_CorridorRunManager = manager;
        m_View = view;
    }

    public void UpdateMeters(){
        m_View.SetScoreText($"{m_CorridorRunManager.Meters} m");
    }
}
