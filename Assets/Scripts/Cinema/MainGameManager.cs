using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour{
    public static MainGameManager Instance;
    MainGameState m_CurrentState;
    [SerializeField] UIPanelManager m_UIPanelManager;
    [SerializeField] public int Lifes;
    private int MaxLifes = 10;
    [SerializeField] public List<Item> GameItems;
    
    void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    void Start(){
        SetStartState();
    }

    void SetStartState(){
        if(Lifes < MaxLifes){
            ChangeState(new CinemaState(this));    
        }else{
            ChangeState(new CoverState(this));
            InitGame();
        }
    }

    public void InitGame(){
        SetComponentReferences();
        ResetItems();
        Lifes = MaxLifes;
    }

    void SetComponentReferences(){
        if(m_UIPanelManager == null) m_UIPanelManager = FindObjectOfType<UIPanelManager>();
        m_UIPanelManager.Init();
    }

    public void ChangeState(MainGameState newState){
        m_CurrentState = newState;
        Debug.Log($"new state: {m_CurrentState.GetType().Name}");
        m_CurrentState.EnterState();
    }

    public void SetUIPanel(){
        m_UIPanelManager.ChangePanel(m_CurrentState.GetType().Name);
    }

    public void Skip(){
        m_CurrentState.ChangeState();
    }

    public bool PlayerHasThisItem(string itemId){
        foreach(Item gameItem in GameItems)
            if(gameItem.ID == itemId)
                if(gameItem.Amount >= 1) return true;

        return false;
    }

    public void LostLife(){
        Lifes--;
    }

    public bool IsGameLosed(){
        return Lifes <= 0;
    }

    public void ReturnToCinema(){
        SceneManager.LoadScene("Cinema");
        Skip();
    }

    public void RestartGame(){
        SetStartState();
        ResetItems();
        ReturnToCinema();
        Lifes = MaxLifes;
    }

    void ResetItems(){
        foreach(Item gameItem in GameItems) gameItem.Amount = 0;
    }
}
