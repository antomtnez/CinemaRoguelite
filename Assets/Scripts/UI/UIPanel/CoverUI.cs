using UnityEngine;
using UnityEngine.UI;

public class CoverUI : UIPanel {
    [SerializeField] Button StartButton;

    public override void InitUI(){
        base.InitUI();
        SetButtonFunction();
    }

    void SetButtonFunction(){
        StartButton.onClick.AddListener(()=>{
            MainGameManager.Instance.Skip();
        });
    }
}