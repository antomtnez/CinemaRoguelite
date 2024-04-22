using UnityEngine;

public class CorridorObstacle : MonoBehaviour{
    [SerializeField] float Speed;
    private Vector2 m_Direction = Vector2.left;

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
        return new Vector2(10f, Random.Range(-2f, -3f));
    }

    bool IsOutOfBounds(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.x < 0;
    }
}
