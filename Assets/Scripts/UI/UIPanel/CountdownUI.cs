using TMPro;
using UnityEngine;

public class CountdownUI : UIPanel {
    [SerializeField] TextMeshProUGUI CountText;
    private Countdown m_Countdown;
    public override void InitUI(){
        base.InitUI();
        SetComponentReferences();

        m_Countdown.OnCountdownDecreased += UpdateUI;
    }

    void SetComponentReferences(){
        m_Countdown = FindObjectOfType<Countdown>();
    }

    public override void UpdateUI(){
        CountText.SetText($"{m_Countdown.TimeLeft}");
    }
}