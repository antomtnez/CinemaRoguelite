using UnityEngine;

public class CorridorPlayerBehaviour : PlayerBehaviour{
    [SerializeField] float JumpForce;
    [SerializeField] bool m_CanDobleJump;
    [SerializeField] bool m_IsGrounded;
    [SerializeField] LayerMask GroundLayer;

    public override void Movement(){
        CheckGrounded();
        if(m_IsGrounded) m_CanDobleJump = true;
    }

    public override void Action(){
        if(m_IsGrounded){
            Jump();
        }else{
            if(m_CanDobleJump){
                Jump();
                m_CanDobleJump = false;
            }
        }
    }

    void Jump(){
        GetComponent<Rigidbody2D>().AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }

    void CheckGrounded(){
        m_IsGrounded = Physics2D.OverlapCircle(transform.position, 0.4f, GroundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")) Death();
        if(other.CompareTag("Finish")) Death();
    }

    void Death(){
        StopBehaviour();
        FindObjectOfType<Minigame>().SendOnMinigameFinishedCall();
    }
}
