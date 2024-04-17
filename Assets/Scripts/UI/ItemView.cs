using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour{
    [SerializeField] Image BackgroundIcon;
    [SerializeField] Image ItemIcon;
    [SerializeField] Slider AmountItemSlider;

    public void SetItemIcon(Sprite icon){
        BackgroundIcon.sprite = icon;
        ItemIcon.sprite = icon;
    }

    public void SetItemAmount(int amount){
        int realAmount = Mathf.Min((int)AmountItemSlider.value + amount, (int)AmountItemSlider.maxValue);
        AmountItemSlider.value += realAmount;

        AmountItemSlider.gameObject.SetActive(AmountItemSlider.value > 0);
    }

    public void SetItemMaxAmount(int maxAmount){
        AmountItemSlider.maxValue = maxAmount;
    }
}
