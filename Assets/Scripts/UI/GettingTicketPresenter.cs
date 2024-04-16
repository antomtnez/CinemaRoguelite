
using UnityEngine;

public class GettingTicketPresenter{
    private GettingTicketManager m_GettingTicketManager;
    private GettingTicketView m_View;

    public GettingTicketPresenter(GettingTicketManager manager, GettingTicketView view) {
        m_GettingTicketManager = manager;
        m_View = view;
    }

    public void UpdateMeters(){
        m_View.SetMetersText(m_GettingTicketManager.Meters);
    }
}
