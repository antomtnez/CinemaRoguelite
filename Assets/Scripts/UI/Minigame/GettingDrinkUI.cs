using TMPro;
using UnityEngine;

public class GettingDrinkUI : MinigameUI {
    [SerializeField] TextMeshProUGUI PopcornsText;
    [SerializeField] GettingDrinkBehaviour DataReference;

    public override void InitUI(){
        base.InitUI();
        DataReference = FindObjectOfType<GettingDrinkBehaviour>();
    }

    public override void UpdateUI(){
        PopcornsText.SetText($"{DataReference.GameRelatedItem.Amount}");
    }
}