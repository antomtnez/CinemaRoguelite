using TMPro;
using UnityEngine;

public class CorridorRunView : MonoBehaviour{
    [SerializeField] TextMeshProUGUI MetersText;

    public void SetMetersText(int meters){
        MetersText.SetText($"{meters.ToString()} m");
    }
}
