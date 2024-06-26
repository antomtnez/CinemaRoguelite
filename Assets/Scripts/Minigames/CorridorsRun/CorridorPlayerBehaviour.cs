using Unity.VisualScripting;
using UnityEngine;

public class CorridorPlayerBehaviour : MonoBehaviour{
    [SerializeField] float JumpForce;
    [SerializeField] bool m_CanDobleJump;
    [SerializeField] bool IsGrounded;
    [SerializeField] LayerMask GroundLayer;
    private bool m_CanMove = true;

    public void EnableMove(){
        m_CanMove = true;
    }

    void Update(){
        CheckGrounded();
        if(m_CanMove) Move();
    }

    void Move(){
        if(IsGrounded){
            m_CanDobleJump = true;
            if(Input.GetKeyDown(KeyCode.Space)) Jump();
        }else{
            if(Input.GetKeyDown(KeyCode.Space) && m_CanDobleJump){
                Jump();
                m_CanDobleJump = false;
            }
        }
    }

    void Jump(){
        GetComponent<Rigidbody2D>().AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }

    void CheckGrounded(){
        IsGrounded = Physics2D.OverlapCircle(transform.position, 0.4f, GroundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")){
            m_CanMove = false;
            CorridorRunManager.Instance.EndMinigame();
        } 

        if(other.CompareTag("Finish")){
            m_CanMove = false;
            CorridorRunManager.Instance.EndMinigame();
        }
    }

    public void StopMove(){
        m_CanMove = false;
    }
}
