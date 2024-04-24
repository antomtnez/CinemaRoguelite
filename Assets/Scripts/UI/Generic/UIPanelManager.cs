using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager : MonoBehaviour {
    UIPanel m_CurrentPanel;
    List<UIPanel> m_UIPanelsList = new List<UIPanel>();

    public void Init(){
        SetComponentReferences();
    }

    void SetComponentReferences(){
        m_UIPanelsList = new List<UIPanel>(GetComponentsInChildren<UIPanel>());
    }

    public void ChangePanel(string stateName){
        foreach(UIPanel screen in m_UIPanelsList){
            screen.CloseUI();
            if(screen.StateRelated == stateName) {
                m_CurrentPanel = screen;
                InitUI();
            }
        }
    }

    public void InitUI(){
        m_CurrentPanel.InitUI();
    }

    public void UpdateUI(){
        m_CurrentPanel.UpdateUI();
    }

    public void CloseUI(){
        m_CurrentPanel.CloseUI();
    }
}

public abstract class UIPanel : MonoBehaviour{
    protected UIPanelManager m_UIPanelManager;
    [SerializeField] protected string m_StateRelated;
    [SerializeField] GameObject UIPanelGO;
    public string StateRelated => m_StateRelated;
    public virtual void InitUI(){
        UIPanelGO.SetActive(true);
    }
    public virtual void UpdateUI(){}
    public virtual void CloseUI(){
        UIPanelGO.SetActive(false);
    }
}