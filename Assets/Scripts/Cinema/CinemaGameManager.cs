using System.Collections.Generic;
using UnityEngine;

public class CinemaGameManager : MonoBehaviour{
    public static CinemaGameManager Instance;
    [SerializeField] int Lifes;
    [SerializeField] public List<Item> GameItems;

    private ItemsPresenter m_ItemsPresenter;
    
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
        }else{
            Destroy(this);
        }
    }

    void Start(){
        m_ItemsPresenter = new ItemsPresenter(new List<ItemView>(FindObjectsOfType<ItemView>()));
    }

    public void AddItem(string itemId, int amount){
        foreach(Item gameItem in GameItems){
            if(gameItem.ID == itemId){
                int realAmount = Mathf.Max(gameItem.Amount + amount, gameItem.MaxAmount);
                gameItem.Amount = realAmount;
            }
        }

        m_ItemsPresenter.UpdateItemsAmount();
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
}
