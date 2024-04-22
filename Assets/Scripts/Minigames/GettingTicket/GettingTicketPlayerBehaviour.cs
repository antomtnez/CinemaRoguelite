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
        FlipSprite();
    }

    void FlipSprite(){
        //transform.rotation = transform.rotation.eulerAngles.y == 0 ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bad")){
            m_CanMove = false;
            GettingTicketManager.Instance.EndMinigame();
        } 
        
        if(other.gameObject.CompareTag("Wall")) ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Finish")){
            m_CanMove = false;
            GettingTicketManager.Instance.EndMinigame();
        }
    }
}