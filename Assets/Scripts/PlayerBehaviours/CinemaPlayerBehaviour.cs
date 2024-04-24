using UnityEngine;

public class CinemaPlayerBehaviour : MonoBehaviour{
    [SerializeField] float Speed;

    void Update(){
        Move();
    }

    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(horizontalInput, verticalInput) * Speed * Time.deltaTime);
    }
}
