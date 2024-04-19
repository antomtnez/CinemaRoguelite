using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{
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
            FallingPopcornManager.Instance.EndMinigame();
        } 
        if(other.CompareTag("Good")){
            other.gameObject.SetActive(false);
            FallingPopcornManager.Instance.AddPoints(1);
        }
        
        if(other.CompareTag("Wall")) ChangeDirection();
        
        if(other.CompareTag("Finish")) FallingPopcornManager.Instance.EndMinigame();
    }

    void Death(){
        gameObject.SetActive(false);
        m_CanMove = false;
    }
}
