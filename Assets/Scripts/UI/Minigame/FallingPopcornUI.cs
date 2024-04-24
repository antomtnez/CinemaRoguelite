using TMPro;
using UnityEngine;

public class FallingPopcornUI : MinigameUI {
    [SerializeField] TextMeshProUGUI PopcornsText;
    [SerializeField] FallingPopcornBehaviour DataReference;

    public override void InitUI(){
        base.InitUI();
        DataReference = FindObjectOfType<FallingPopcornBehaviour>();
    }

    public override void UpdateUI(){
        PopcornsText.SetText($"{DataReference.GameRelatedItem.Amount}");
    }
}