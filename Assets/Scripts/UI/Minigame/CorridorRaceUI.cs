using UnityEngine;
using UnityEngine.UI;

public class CorridorRaceUI : MinigameUI {
    [SerializeField] Slider LengthMarkBar;
    [SerializeField] CorridorRaceBehaviour DataReference;

    public override void InitUI(){
        base.InitUI();
        DataReference = FindObjectOfType<CorridorRaceBehaviour>();
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