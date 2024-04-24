using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : UIPanel {
    [SerializeField] TextMeshProUGUI MessageText;
    [SerializeField] Button SkipButton;
    public override void InitUI(){
        base.InitUI();
        SetButtonFunction();
        SetTutorialText();
    }

    void SetTutorialText(){
        MessageText.SetText("You lose minigame");
    }

    void SetButtonFunction(){
        SkipButton.onClick.AddListener(()=>{
            CinemaGameManager.Instance.ReturnToCinema();
        });
    }
}