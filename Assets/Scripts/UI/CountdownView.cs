using TMPro;
using UnityEngine;

public class CountdownView : MonoBehaviour{
    [SerializeField] TextMeshProUGUI CountdownText;

    public void SetCountdownText(string count){
        CountdownText.SetText(count);
    }
}