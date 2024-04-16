using UnityEngine;

public class FallingPopcorn : MonoBehaviour{
    [SerializeField] float Speed;
    private Vector2 m_Direction = Vector2.down;

    void OnEnable(){
        transform.position = SetRandomPosition();
        CalculateDirection();
    }

    void Update(){
        Move();
    }

    void Move(){
        transform.Translate(m_Direction.normalized * Speed * Time.deltaTime);
        if(IsOutOfBounds()) gameObject.SetActive(false);
    }

    Vector2 SetRandomPosition(){
        return new Vector2(Random.Range(-5f, 5f), 6f);
    }

    void CalculateDirection(){
        Vector2 targetPoint = new Vector2(Random.Range(-5f, 5f), -4f);
        m_Direction = targetPoint - (Vector2)transform.position;
    }

    bool IsOutOfBounds(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0;
    }
}