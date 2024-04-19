using UnityEngine;

public class BorderBehaviour : MonoBehaviour{
    [SerializeField] Transform m_RightBorder;
    [SerializeField] Transform m_RightEndPoint;
    public Transform RightEndPoint => m_RightEndPoint;
    [SerializeField] Transform m_LeftBorder;
    [SerializeField] Transform m_LeftEndPoint;
    [SerializeField] ObstacleLine m_BottomObstacleLine;
    [SerializeField] ObstacleLine m_TopObstacleLine;
    [SerializeField] float Speed;
    private Vector2 m_Direction = Vector2.down;
    public bool HasObstacles = true;

    void Update(){
        Move();
    }

    void Move(){
        transform.Translate(m_Direction.normalized * Speed * Time.deltaTime);
        if(IsOutOfBounds()) gameObject.SetActive(false);
    }

    bool IsOutOfBounds(){
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        return screenPosition.y < - .5f;
    }

    public void SetBorderHeight(float newHeight){
        m_RightBorder.transform.position = new Vector2(newHeight, m_RightBorder.transform.position.y);
        m_LeftBorder.transform.position = new Vector2(-newHeight, m_LeftBorder.transform.position.y);
    }

    public void CloseBorderHeight(float closeRotation){
        m_RightBorder.transform.rotation = Quaternion.Euler(0f, 0f, closeRotation);
        m_LeftBorder.transform.rotation = Quaternion.Euler(0f, 0f, -closeRotation);
    }

    public void SpawnObstacles(){
        m_TopObstacleLine.SpawnObstacle();
        m_BottomObstacleLine.SpawnObstacle();
    }
}
