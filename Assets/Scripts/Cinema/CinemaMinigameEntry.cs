using UnityEngine;

public class CinemaMinigameEntry : MonoBehaviour{
    [SerializeField] bool Unlocked = false;
    [SerializeField] string ItemIDToUnlockEntry;

    void Start(){
        if(ItemIDToUnlockEntry != null) UnlockEntry();
    }

    void UnlockEntry(){
        Unlocked = CinemaGameManager.Instance.PlayerHasThisItem(ItemIDToUnlockEntry);
    }
}
