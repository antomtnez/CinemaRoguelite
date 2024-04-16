using UnityEngine;

public class Obstacle : MonoBehaviour{
    [SerializeField] float Speed;
    private Vector2 m_Direction = Vector2.down;

    void OnEnable(){
        transform.position = SetRandomPosition();
    }

    void Update(){
        Move();
    }

    void Move(){
        transform.Translate(m_Direction.normalized * Speed * Time.deltaTime);
        if(IsOutOfBounds()) gameObject.SetActive(false);
    }

    Vector2 SetRandomPosition(){
        float probability = Random.Range(0f, 10f);  
        return probability < 5 ? new Vector2(-3f, 6f) : new Vector2(3f, 6f);
    }

    bool IsOutOfBounds(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.y < 0;
    }
}
