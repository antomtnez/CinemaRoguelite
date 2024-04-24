using TMPro;
using UnityEngine;

public class FinishGameUI : UIPanel {
    [SerializeField] TextMeshProUGUI WinText;

    public override void InitUI(){
        base.InitUI();
        SetWinText();
    }

    void SetWinText(){
        WinText.SetText("Congratulations! You watched the best film in the world during this week");
    }
}