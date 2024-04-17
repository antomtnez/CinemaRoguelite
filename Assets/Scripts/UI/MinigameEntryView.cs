using System;
using DG.Tweening;
using UnityEngine;

public class MinigameEntryView : MonoBehaviour{
    [SerializeField] SpriteRenderer EntrySprite;
    private Collider2D m_Collider2D;
    private Color m_DisableColor = Color.gray;
    private Color m_EnableColor = Color.white;

    public event Action OnPlayerEnter;
    public event Action OnPlayerExit;

    void Start(){
        m_Collider2D = GetComponent<Collider2D>();
    }

    public void EnableEntry(){
        EntrySprite.color = m_EnableColor;
        m_Collider2D.enabled = true;
    }

    public void DisableEntry(){
        EntrySprite.color = m_DisableColor;
        m_Collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            EntrySprite.transform.DOScale(Vector3.one * .1f, 0.2f);
            OnPlayerEnter?.Invoke();
        }   
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            EntrySprite.transform.DOScale(Vector3.one * .0885f, 0.2f);
            OnPlayerExit?.Invoke();
        }  
    }
}
