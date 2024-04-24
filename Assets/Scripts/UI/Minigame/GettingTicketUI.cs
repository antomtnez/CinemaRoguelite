using UnityEngine;
using UnityEngine.UI;

public class GettingTicketUI : MinigameUI {
    [SerializeField] Slider LengthMarkBar;
    [SerializeField] GettingTicketBehaviour DataReference;

    public override void InitUI(){
        base.InitUI();
        DataReference = FindObjectOfType< GettingTicketBehaviour>();
        SetMaxSlider();
    }

    public override void UpdateUI(){
        SetSlider();
    }

    void SetMaxSlider(){
        LengthMarkBar.maxValue = DataReference.TotalLengthToWalk;
        SetSlider();
    }

    void SetSlider(){
        LengthMarkBar.value = DataReference.LengthWalked;
    }
}