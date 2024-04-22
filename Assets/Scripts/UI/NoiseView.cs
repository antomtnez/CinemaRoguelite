using UnityEngine;
using UnityEngine.UI;

public class NoiseView : MonoBehaviour{
    [SerializeField] Slider NoiseSlider;

    public void SetMaxNoiseSlider(int maxAmount){
        NoiseSlider.maxValue = maxAmount;
        SetNoiseSlider(maxAmount);
    }

    public void SetNoiseSlider(int amount){
        NoiseSlider.value = amount;
    }
}
