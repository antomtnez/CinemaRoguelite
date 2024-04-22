public class FallingPopcornPresenter{
    private FallingPopcornManager m_FallingPopcornManager;
    private MinigameScoreView m_View;

    public FallingPopcornPresenter(FallingPopcornManager manager, MinigameScoreView view){
        m_FallingPopcornManager = manager;
        m_View = view;
    }

    public void UpdatePoints(){
        m_View.SetScoreText($"{m_FallingPopcornManager.Points}");
    }
}
