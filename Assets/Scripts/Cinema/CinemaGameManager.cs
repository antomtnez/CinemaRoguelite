using System.Collections.Generic;
using UnityEngine;

public class CinemaGameManager : MonoBehaviour{
    public static CinemaGameManager Instance;
    [SerializeField] int Lifes;
    [SerializeField] List<Item> GameItems;
    
    void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this);
        }
    }

    public bool PlayerGetsThisItem(Item item){
        foreach(Item playerItem in GameItems)
            if(playerItem.ID == item.ID) return true;
            
        return false;
    }
}
