using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemaGameManager : MonoBehaviour{
    public static CinemaGameManager Instance;
    [SerializeField] int Lifes;
    [SerializeField] public List<Item> GameItems;
    
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
        }else{
            Destroy(this);
        }
    }


    public void AddItem(string itemId, int amount){
        foreach(Item gameItem in GameItems){
            if(gameItem.ID == itemId){
                int realAmount = Mathf.Max(gameItem.Amount + amount, gameItem.MaxAmount);
                gameItem.Amount = realAmount;
            }
        }
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

    public void ReturnToCinema(){
        SceneManager.LoadScene("Cinema");
    }
}
