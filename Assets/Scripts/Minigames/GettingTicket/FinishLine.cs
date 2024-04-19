using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float Speed;
    private Vector2 m_Direction = Vector2.down;

    void OnEnable(){
        transform.position = new Vector2(0f, 6f);
    }

    void Update(){
        if(!IsInCenter()) Move();
    }

    void Move(){
        transform.Translate(m_Direction.normalized * Speed * Time.deltaTime);
    }

    bool IsInCenter(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.y < .1f;
    }
}
