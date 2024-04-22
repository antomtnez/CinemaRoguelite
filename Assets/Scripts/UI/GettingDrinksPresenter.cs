public class GettingDrinksPresenter{
    private GettingDrinksManager m_GettingDrinkManager;
    private MinigameScoreView m_View;

    public GettingDrinksPresenter(GettingDrinksManager manager, MinigameScoreView view){
        m_GettingDrinkManager = manager;
        m_View = view;
    }

    public void UpdateDrinks(){
        m_View.SetScoreText($"{m_GettingDrinkManager.Drinks}");
    }
}
