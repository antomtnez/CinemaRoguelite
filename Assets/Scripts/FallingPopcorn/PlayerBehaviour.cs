using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{
    [SerializeField] float Speed;
    [SerializeField] float HorizontalBounds;

    void Update(){
        Move();
    }

    void Move(){
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) || IsOnBounds())
            Speed = -Speed;
    }

    bool IsOnBounds(){
        return transform.position.x >= HorizontalBounds || transform.position.x <= -HorizontalBounds;
    }
}
