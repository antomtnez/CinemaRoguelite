using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour {
    [SerializeField] Image ItemIcon;
    [SerializeField] TextMeshProUGUI ItemAmountText;

    public void SetItem(Item item){
        if(item != null && item.Amount > 0){
            ItemIcon.sprite = item.Icon;
            ItemAmountText.SetText($"x{item.Amount}");
            ItemIcon.gameObject.SetActive(true);
        }else{
            ItemIcon.gameObject.SetActive(false);
        }
    }
}