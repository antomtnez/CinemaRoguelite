using UnityEngine;

public class SquarePlayerBehaviour : MonoBehaviour{
    [SerializeField] float Speed; // Velocidad de movimiento
    [SerializeField] float MoveDistance; // Distancia exterior a mover en cada dirección
    private Vector3 m_StartPosition;
    private Vector3[] m_MovePoints;
    private int m_PointToMoveIndex = 0;
    private bool m_IsHidden = false;
    [SerializeField] Vector2 m_ExitFromHidePosition = Vector2.zero;

    void Start(){
        SetStartPoint();
        SetMovePoints();
    }

    void Update(){
        if(!m_IsHidden)
            MoveTowardsPoints();

        if(Input.GetKeyDown(KeyCode.Space)){
            m_IsHidden = !m_IsHidden;
            HideBehindBar();
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            m_IsHidden = !m_IsHidden;
            ExitFromBar();
        }
    }

    void SetStartPoint(){
        m_StartPosition = transform.position;
    }

    void SetMovePoints(){
        m_MovePoints = new Vector3[4]{
            // Mover a la derecha
            m_StartPosition + new Vector3(MoveDistance, 0, 0),
            // Mover hacia arriba
            m_StartPosition + new Vector3(MoveDistance, MoveDistance, 0),
            // Mover a la izquierda
            m_StartPosition + new Vector3(0, MoveDistance, 0),
            // Mover hacia abajo
            m_StartPosition
        };
    }

    void MoveTowardsPoints(){
        if(Vector3.Distance(transform.position, m_MovePoints[m_PointToMoveIndex]) < 0.01f){
            m_PointToMoveIndex = (m_PointToMoveIndex < m_MovePoints.Length-1) ? m_PointToMoveIndex+1 : 0;
        }else{
            Vector2 direction = m_MovePoints[m_PointToMoveIndex] - transform.position;
            transform.Translate(direction.normalized * Speed * Time.deltaTime);
        }
    }

    void HideBehindBar(){
        m_ExitFromHidePosition = transform.position;
        Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;
        transform.Translate(direction * 1.5f);
    }

    void ExitFromBar(){
        Vector2 direction = (m_ExitFromHidePosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * 1.5f);
    }
}