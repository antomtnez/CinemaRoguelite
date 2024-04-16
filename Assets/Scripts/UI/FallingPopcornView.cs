using TMPro;
using UnityEngine;

public class FallingPopcornView : MonoBehaviour{
    [SerializeField] TextMeshProUGUI PointsText;

    public void SetPointsText(int points){
        PointsText.SetText(points.ToString());
    }
}
