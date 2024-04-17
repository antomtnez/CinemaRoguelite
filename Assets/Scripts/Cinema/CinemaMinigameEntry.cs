using UnityEngine;

public class CinemaMinigameEntry : MonoBehaviour{
    private bool Unlocked = false;
    [SerializeField] Item ItemToUnlockEntry;

    void Start(){
        if(ItemToUnlockEntry != null) UnlockEntry();
    }

    void UnlockEntry(){
        Unlocked = CinemaGameManager.Instance.PlayerGetsThisItem(ItemToUnlockEntry);
    }
}
