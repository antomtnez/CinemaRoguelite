using UnityEngine;

public class ThrowerAim : MonoBehaviour{
    [SerializeField] Transform CenterPoint;
    [SerializeField] float CircleRadius;
    [SerializeField] float RotationSpeed;
    [SerializeField] int AngularBounds;
    
    private float m_CurrentAngle = 0f;

    void Update(){
        CircularMove();
    }

    void CircularMove(){
        // Incrementa el ángulo según la velocidad y el tiempo
        m_CurrentAngle += RotationSpeed * Time.deltaTime; // Asegúrate de que el ángulo no se desborde
        m_CurrentAngle %= 360;

        // Calcula la nueva posición
        float x = CenterPoint.position.x + Mathf.Cos(m_CurrentAngle * Mathf.Deg2Rad) * CircleRadius;
        float y = CenterPoint.position.y + Mathf.Sin(m_CurrentAngle * Mathf.Deg2Rad) * CircleRadius;

        // Establece la posición del objeto
        transform.position = new Vector2(x, y);

        if(OutInBounds()) RotationSpeed = -RotationSpeed;
    }

    bool OutInBounds(){
        return m_CurrentAngle > AngularBounds || m_CurrentAngle < -AngularBounds;
    }
}
