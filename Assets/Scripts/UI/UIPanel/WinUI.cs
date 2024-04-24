using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : UIPanel {
    [SerializeField] TextMeshProUGUI MessageText;
    [SerializeField] Button SkipButton;
    public override void InitUI(){
        base.InitUI();
        SetButtonFunction();
        SetTutorialText();
    }

    void SetTutorialText(){
        MessageText.SetText("You win minigame");
    }

    void SetButtonFunction(){
        SkipButton.onClick.AddListener(()=>{
            CinemaGameManager.Instance.ReturnToCinema();
        });
    }
}