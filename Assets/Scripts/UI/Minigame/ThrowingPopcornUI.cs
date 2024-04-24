using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingPopcornUI : MinigameUI {
    [SerializeField] Slider NoiseBar;
    [SerializeField] TextMeshProUGUI BulletsText;
    [SerializeField] ThrowingPopcornBehaviour DataReference;

    public override void InitUI(){
        base.InitUI();
        DataReference = FindObjectOfType<ThrowingPopcornBehaviour>();
        SetMaxSlider();
    }

    public override void UpdateUI(){
        SetSlider();
        SetBulletsText();
    }

    void SetMaxSlider(){
        NoiseBar.maxValue = DataReference.MaxNoise;
        SetSlider();
    }

    void SetSlider(){
        NoiseBar.value = DataReference.Noise;
    }

    void SetBulletsText(){
        BulletsText.SetText($"x{DataReference.GameRelatedItem.Amount}");
    }
}