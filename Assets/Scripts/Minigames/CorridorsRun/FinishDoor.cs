using UnityEngine;

public class FinishDoor : MonoBehaviour{
    [SerializeField] float Speed;
    private Vector2 m_Direction = Vector2.left;

    void OnEnable(){
        transform.position = new Vector2(12f, -1f);
    }

    void Update(){
        if(!IsInCenter()) Move();
    }

    void Move(){
        transform.Translate(m_Direction.normalized * Speed * Time.deltaTime);
    }

    bool IsInCenter(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.x < .2f;
    }
}
