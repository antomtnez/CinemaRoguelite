using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CinemaUI : UIPanel {
    [SerializeField] TextMeshProUGUI LifesText;
    [SerializeField] List<ItemView> ItemsViewList = new List<ItemView>();

    public override void InitUI(){
        base.InitUI();
        SetLifesText();
        SetItemsAmount();
    }

    void SetItemsAmount(){
        for(int i=0; i < MainGameManager.Instance.GameItems.Count; i++)
            ItemsViewList[i].SetItem(MainGameManager.Instance.GameItems[i]);
    }

    void SetLifesText(){
        LifesText.SetText($"20:{60 - MainGameManager.Instance.Lifes}");
    }
}