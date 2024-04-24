using TMPro;
using UnityEngine;

public class LoseGameUI : UIPanel {
    [SerializeField] TextMeshProUGUI LoseText;

    public override void InitUI(){
        base.InitUI();
        SetLoseText();
    }

    void SetLoseText(){
        LoseText.SetText("Oh! Im so sorry but you have to wait until next season");
    }
}