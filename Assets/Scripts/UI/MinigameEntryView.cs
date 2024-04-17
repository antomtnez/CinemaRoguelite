using UnityEngine;
using UnityEngine.UI;


public class MinigameEntryView : MonoBehaviour{
    [SerializeField] Image EntrySprite;
    private Color m_DisableColor = Color.gray;
    private Color m_EnableColor = Color.white;

    public void EnableEntry(){
        EntrySprite.color = m_EnableColor;
    }

    public void DisableEntry(){
        EntrySprite.color = m_DisableColor;
    }

    void OnPlayerTriggerAnimation(){
    }
}
