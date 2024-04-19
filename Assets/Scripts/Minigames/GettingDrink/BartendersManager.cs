using System.Collections.Generic;
using UnityEngine;

public class BartendersManager : MonoBehaviour{
    [SerializeField] List<BartenderBehaviour> Bartender = new List<BartenderBehaviour>();
    [SerializeField] float MoveDistance; // Distancia exterior a mover en cada dirección
    private Vector3 m_StartPosition;
    private Vector3[] m_MovePoints;
    private int m_PointToMoveFirstIndex = 0;
    private int m_PointToMoveSecondIndex = 2;

    void Start(){
        SetStartPoint();
        SetMovePoints();
    }

    void Update(){
        ChangeBartenderTarget();
    }
 
    void SetStartPoint(){
        m_StartPosition = transform.position;
        Bartender[0].transform.position = m_StartPosition;
        Bartender[1].transform.position = (Vector2)m_StartPosition + (Vector2.one * MoveDistance);
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

    void ChangeBartenderTarget(){
        if(Vector3.Distance(Bartender[0].transform.position, m_MovePoints[m_PointToMoveFirstIndex]) < 0.01f){
            m_PointToMoveFirstIndex = (m_PointToMoveFirstIndex < m_MovePoints.Length-1) ? m_PointToMoveFirstIndex+1 : 0;
        }else{
            Vector2 direction = (m_MovePoints[m_PointToMoveFirstIndex] - Bartender[0].transform.position).normalized;
            Bartender[0].SetDirection(direction);
        }

        if(Vector3.Distance(Bartender[1].transform.position, m_MovePoints[m_PointToMoveSecondIndex]) < 0.01f){
            m_PointToMoveSecondIndex = (m_PointToMoveSecondIndex < m_MovePoints.Length-1) ? m_PointToMoveSecondIndex+1 : 0;
        }else{
            Vector2 direction = (m_MovePoints[m_PointToMoveSecondIndex] - Bartender[1].transform.position).normalized;
            Bartender[1].SetDirection(direction);
        }
    }
}