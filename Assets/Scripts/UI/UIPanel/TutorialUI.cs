using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : UIPanel {
    [SerializeField] TextMeshProUGUI TutorialText;
    [SerializeField] Button SkipButton;
    public override void InitUI(){
        base.InitUI();
        SetButtonFunction();
        SetTutorialText();
    }

    void SetTutorialText(){
        TutorialText.SetText("A tutorial about minigame");
    }

    void SetButtonFunction(){
        SkipButton.onClick.AddListener(()=>{
            Minigame.Instance.Skip();
        });
    }
}