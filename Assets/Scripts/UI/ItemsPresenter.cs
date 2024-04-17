using System.Collections.Generic;

public class ItemsPresenter{
    private CinemaGameManager m_CinemaGameManager;
    private List<ItemView> m_itemViews;

    public ItemsPresenter (List<ItemView> itemViews){
        m_CinemaGameManager = CinemaGameManager.Instance;
        m_itemViews = itemViews;
        InitViews();
    }

    void InitViews(){
        for(int i = 0; i < m_CinemaGameManager.GameItems.Count; i++){
            m_itemViews[i].SetItemIcon(m_CinemaGameManager.GameItems[i].Icon);
            m_itemViews[i].SetItemMaxAmount(m_CinemaGameManager.GameItems[i].MaxAmount);
            m_itemViews[i].SetItemAmount(0);
        }
    }

    public void UpdateItemsAmount(){
        for(int i = 0; i < m_CinemaGameManager.GameItems.Count; i++)
            m_itemViews[i].SetItemAmount(m_CinemaGameManager.GameItems[i].Amount);
    }
}
