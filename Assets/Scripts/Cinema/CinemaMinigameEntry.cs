using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemaMinigameEntry : MonoBehaviour{
    public bool Unlocked = false;
    public bool IsPlayerOnEntry = false;
    [SerializeField] string ItemIDToUnlockEntry;
    [SerializeField] string MinigameSceneName;

    private MinigameEntryPresenter m_MinigameEntryPresenter;

    void Start(){
        m_MinigameEntryPresenter = new MinigameEntryPresenter(this, GetComponentInChildren<MinigameEntryView>());
        if(!ItemIDToUnlockEntry.Equals("")) UnlockEntry();
    }

    void Update(){
        if(Unlocked && IsPlayerOnEntry)
            if(Input.GetKeyDown(KeyCode.Space)) EntryMinigame();
    }

    void UnlockEntry(){
        Unlocked = CinemaGameManager.Instance.PlayerHasThisItem(ItemIDToUnlockEntry);
        m_MinigameEntryPresenter.IsEntryUnlocked();
    }

    void EntryMinigame(){
        SceneManager.LoadScene(MinigameSceneName);
    }
}
