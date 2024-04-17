using UnityEngine;

public class ThrowerPlayerBehaviour : MonoBehaviour{
    [SerializeField] Pool m_PopcornShots;
    [SerializeField] ThrowerAim ThrowerAim;
    private bool m_CanMove = false;

    public void EnableMove(){
        m_CanMove = true;
    }

    void Start(){
        EnableMove();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && m_CanMove) ThrowAPopcorn();
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
