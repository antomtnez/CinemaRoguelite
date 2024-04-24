using UnityEngine;

public class ZigZagPlayerBehaviour : PlayerBehaviour{
    [SerializeField] float Speed;

    public override void Movement(){
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    public override void Action(){
        ChangeDirection();
    }

    void ChangeDirection(){
        Speed = -Speed;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")) Death();

        if(other.CompareTag("Good")){
            other.gameObject.SetActive(false);
            FindObjectOfType<Minigame>().GetComponent<IGameScoreUpdater>().UpdateScore();
        }
        
        if(other.CompareTag("Finish")) {
            Death();
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void Death(){
        StopBehaviour();
        FindObjectOfType<Minigame>().SendOnMinigameFinishedCall();
    }
}