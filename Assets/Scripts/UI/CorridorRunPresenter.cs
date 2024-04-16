using UnityEngine;

public class CorridorRunPresenter{
    
    private CorridorRunManager m_CorridorRunManager;
    private CorridorRunView m_View;

    public CorridorRunPresenter(CorridorRunManager manager, CorridorRunView view){
        m_CorridorRunManager = manager;
        m_View = view;
    }

    public void UpdateMeters(){
        m_View.SetMetersText(m_CorridorRunManager.Meters);
    }
}
