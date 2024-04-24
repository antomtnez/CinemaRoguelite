using UnityEngine;

public class PopcornBullet : MonoBehaviour{
    [SerializeField] float Speed;
    [SerializeField] Item BulletMagazine;
    private Vector2 m_Direction = Vector2.down;

    void OnEnable(){
        transform.position = FindObjectOfType<ThrowerPlayerBehaviour>().transform.position;
        CalculateDirection();
        BulletMagazine.Amount--;
    }

    void Update(){
        Move();
    }

    void Move(){
        transform.Translate(m_Direction.normalized * Speed * Time.deltaTime);
        if(IsOutOfBounds()) gameObject.SetActive(false);
    }

    void CalculateDirection(){
        Vector2 targetPoint = FindObjectOfType<ThrowerAim>().transform.position;
        m_Direction = targetPoint - (Vector2)transform.position;
    }

    bool IsOutOfBounds(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.x > 1 || screenPosition.y < 0;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bad")){
            FindObjectOfType<Minigame>().GetComponent<IGameScoreUpdater>().UpdateScore();
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
