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

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")){
            Death();
            GettingTicketManager.Instance.EndMinigame();
        } 
        
        if(other.CompareTag("Wall")) ChangeDirection();
        
        if(other.CompareTag("Finish")){ 
            GettingTicketManager.Instance.EndMinigame();
            m_CanMove = false;
        }
    }

    void Death(){
        gameObject.SetActive(false);
        m_CanMove = false;
    }
}