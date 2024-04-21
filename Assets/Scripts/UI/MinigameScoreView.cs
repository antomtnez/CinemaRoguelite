using TMPro;
using UnityEngine;

public class MinigameScoreView : MonoBehaviour{
    [SerializeField] TextMeshProUGUI ScoreText;

    public void SetScoreText(string scoreInText){
        ScoreText.SetText(scoreInText);
    }
}
