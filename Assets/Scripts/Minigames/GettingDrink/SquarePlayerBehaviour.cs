using UnityEngine;

public class SquarePlayerBehaviour : MonoBehaviour{
    [SerializeField] float Speed; // Velocidad de movimiento
    [SerializeField] float MoveDistance; // Distancia exterior a mover en cada dirección
    private Vector3 m_OutStartPosition;
    private Vector3[] m_OutMovePoints;
    private int m_PointToMoveIndex = 0;
    private bool m_IsHidden = false;
    [SerializeField] Vector2 m_ExitFromHidePosition = Vector2.zero;

    void Start(){
        SetStartPoints();
        SetMovePoints();
    }

    void Update(){
        if(!m_IsHidden)
            MoveTowardsPoints();

        if(Input.GetKeyDown(KeyCode.Space)){
            m_IsHidden = !m_IsHidden;
            if(m_IsHidden){
                HideBehindBar();
            }else{
                ExitFromBar();
            }
        }
    }

    void SetStartPoints(){
        m_OutStartPosition = transform.position;
    }

    void SetMovePoints(){
        m_OutMovePoints = new Vector3[4]{
            // Mover a la derecha
            m_OutStartPosition + new Vector3(MoveDistance, 0, 0),
            // Mover hacia arriba
            m_OutStartPosition + new Vector3(MoveDistance, MoveDistance, 0),
            // Mover a la izquierda
            m_OutStartPosition + new Vector3(0, MoveDistance, 0),
            // Mover hacia abajo
            m_OutStartPosition
        };
    }

    void MoveTowardsPoints(){
        if(Vector3.Distance(transform.position, m_OutMovePoints[m_PointToMoveIndex]) < 0.01f){
            m_PointToMoveIndex = (m_PointToMoveIndex < m_OutMovePoints.Length-1) ? m_PointToMoveIndex+1 : 0;
        }else{
            Vector2 direction = m_OutMovePoints[m_PointToMoveIndex] - transform.position;
            transform.Translate(direction.normalized * Speed * Time.deltaTime);
        }
    }

    void HideBehindBar(){
        m_ExitFromHidePosition = transform.position;
        Vector2 direction = (Vector2.zero - (Vector2)transform.position).normalized;
        transform.Translate(direction * 2f);
    }

    void ExitFromBar(){
        Vector2 direction = (m_ExitFromHidePosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * 2f);
    }
}