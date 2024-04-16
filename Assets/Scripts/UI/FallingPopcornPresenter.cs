using UnityEngine;

public class FallingPopcornPresenter{
    private FallingPopcornManager m_FallingPopcornManager;
    private FallingPopcornView m_View;

    public FallingPopcornPresenter(FallingPopcornManager manager, FallingPopcornView view){
        m_FallingPopcornManager = manager;
        m_View = view;
    }

    public void UpdateText(){
        m_View.SetPointsText(m_FallingPopcornManager.Points);
    }
}
