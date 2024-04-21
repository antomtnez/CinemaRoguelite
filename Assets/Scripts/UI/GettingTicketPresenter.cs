public class GettingTicketPresenter{
    private GettingTicketManager m_GettingTicketManager;
    private MinigameScoreView m_View;

    public GettingTicketPresenter(GettingTicketManager manager, MinigameScoreView view) {
        m_GettingTicketManager = manager;
        m_View = view;
    }

    public void UpdateMeters(){
        m_View.SetScoreText($"{m_GettingTicketManager.Meters}");
    }
}
