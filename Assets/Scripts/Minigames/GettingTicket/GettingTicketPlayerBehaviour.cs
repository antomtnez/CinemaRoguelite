using UnityEngine;

public class GettingTicketPlayerBehaviour : MonoBehaviour{
    [SerializeField] float Speed;
    private bool m_CanMove = false;

    public void EnableMove(){
        m_CanMove = true;
    }

    void Update(){
        if(m_CanMove) Move();
    }

    void Move(){
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)) ChangeDirection();
    }

    void ChangeDirection(){
        Speed = -Speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bad")){
            Death();
            GettingTicketManager.Instance.EndMinigame();
        } 
        
        if(other.gameObject.CompareTag("Wall")) ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Finish")){ 
            GettingTicketManager.Instance.EndMinigame();
            m_CanMove = false;
        }
    }

    void Death(){
        m_CanMove = false;
    }
}