using UnityEngine;

public class ThrowerPlayerBehaviour : MonoBehaviour{
    [SerializeField] Pool m_PopcornShots;
    [SerializeField] ThrowerAim ThrowerAim;
    [SerializeField] float m_DelayBtwShots = .5f;
    private float m_CounterBtwShots = 0f;

    private bool m_CanMove = false;
    private bool m_CanShot = true;

    public void EnableMove(){
        m_CanMove = true;
    }

    void Start(){
        EnableMove();
    }

    void Update(){
        if(m_CanMove){
            if(m_CanShot){
                if(Input.GetKeyDown(KeyCode.Space)){
                    ThrowAPopcorn();
                    m_CounterBtwShots = m_DelayBtwShots;
                    m_CanShot = false;
                }
            }else{
                if(m_CounterBtwShots <= 0f){
                    m_CanShot = true;
                }else{
                    m_CounterBtwShots -= Time.deltaTime;
                }
            }
        }
    }

    void ThrowAPopcorn(){
        m_PopcornShots.GetObject();
        ThrowerAim.StopAimForThrow();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")){
            Death();
            FallingPopcornManager.Instance.EndMinigame();
        }
    }

    void Death(){
        gameObject.SetActive(false);
        m_CanMove = false;
    }
}
