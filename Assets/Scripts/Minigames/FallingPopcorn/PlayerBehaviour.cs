using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{
    [SerializeField] float Speed;
    [SerializeField] float HorizontalBounds;
    private bool m_CanMove = false;

    public void EnableMove(){
        m_CanMove = true;
    }

    void Update(){
        if(m_CanMove) Move();
    }

    void Move(){
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) || IsOnBounds())
            Speed = -Speed;
    }

    bool IsOnBounds(){
        return transform.position.x >= HorizontalBounds || transform.position.x <= -HorizontalBounds;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")){
            Death();
            FallingPopcornManager.Instance.EndMinigame();
        } 
        if(other.CompareTag("Good")) {
            other.gameObject.SetActive(false);
            FallingPopcornManager.Instance.AddPoints(1);
        } 
    }

    void Death(){
        gameObject.SetActive(false);
        m_CanMove = false;
    }
}
