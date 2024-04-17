using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIScreen{
    public GameObject Panel;
    public string StateName;
}

public class MinigameView : MonoBehaviour{
    [SerializeField] List<UIScreen> Screens = new List<UIScreen>();

    public void ActivePanel(string stateName){
        foreach(UIScreen screen in Screens)
            screen.Panel.SetActive(screen.StateName == stateName);
    }
}
