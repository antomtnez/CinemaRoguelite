public class MinigameEntryPresenter{
    private CinemaMinigameEntry m_CinemaMinigameEntry;
    private MinigameEntryView m_MinigameEntryView;

    public MinigameEntryPresenter(CinemaMinigameEntry cinemaMinigameEntry, MinigameEntryView minigameEntryView){
        m_CinemaMinigameEntry = cinemaMinigameEntry;
        m_MinigameEntryView = minigameEntryView;
        m_MinigameEntryView.OnPlayerEnter += OnPlayerEnter;
        m_MinigameEntryView.OnPlayerExit += OnPlayerExit;
    }

    public void IsEntryUnlocked(){
        if(m_CinemaMinigameEntry.Unlocked){
            m_MinigameEntryView.EnableEntry();
        }else{
            m_MinigameEntryView.DisableEntry();
        }
    }

    void OnPlayerEnter(){
        m_CinemaMinigameEntry.IsPlayerOnEntry = true;
    }

    void OnPlayerExit(){
        m_CinemaMinigameEntry.IsPlayerOnEntry = false;
    }
}
