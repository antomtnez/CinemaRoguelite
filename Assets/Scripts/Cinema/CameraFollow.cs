using UnityEngine;

public class CameraFollow : MonoBehaviour{
    [SerializeField] Vector3 Offset;
    [SerializeField] float SmoothTime;
    private Vector3 m_RefVelocity;
    private GameObject m_Target;

    void Start(){
        m_Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
        FollowTarget();
    }

    void FollowTarget(){
        Vector3 targetPosition = m_Target.transform.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref m_RefVelocity, SmoothTime);
    }
}
