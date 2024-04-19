using UnityEngine;

public class BartenderBehaviour : MonoBehaviour{
    [SerializeField] float Speed;
    [SerializeField] Vector2 m_Direction;

    void Update(){
        Move();
    }

    void Move(){
        transform.Translate(m_Direction * Speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction){
        m_Direction = direction;
    }
}
