using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour{
    
    [SerializeField] TextMeshProUGUI ScoreText;

    public void SetCountdownText(string scoreInText){
        ScoreText.SetText(scoreInText);
    }
}
