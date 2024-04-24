using UnityEngine;

public class ThrowerPlayerBehaviour : PlayerBehaviour{
    [SerializeField] Pool m_PopcornShots;
    [SerializeField] ThrowerAim ThrowerAim;
    [SerializeField] float m_DelayBtwShots = .5f;
    [SerializeField] ThrowingPopcornBehaviour m_MinigameData;
    private float m_CounterBtwShots = 0f;
    private bool m_CanShot = true;

    public override void Movement(){
        DelayedReload();
    }

    void DelayedReload(){
        if(!m_CanShot){
            if(m_CounterBtwShots <= 0f){
                m_CanShot = true;
            }else{
                m_CounterBtwShots -= Time.deltaTime;
            }
        }
    }

    public override void Action(){
        if(m_CanShot){
            ThrowAPopcorn();
            m_CounterBtwShots = m_DelayBtwShots;
            m_CanShot = false;
            m_MinigameData.UpdateUI();
        }
    }

    void ThrowAPopcorn(){
        m_PopcornShots.GetObject();
        ThrowerAim.StopAimForThrow();
    }
}
