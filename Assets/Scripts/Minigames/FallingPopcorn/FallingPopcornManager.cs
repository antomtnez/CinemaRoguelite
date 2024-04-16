using UnityEngine;

public class FallingPopcornManager : MonoBehaviour{
    public static FallingPopcornManager Instance;
    [SerializeField] int m_Points;
    private FallingPopcornPresenter m_FallingPopcornPresenter;
    public int Points => m_Points;

    void Awake(){
        if(Instance != null){
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    void Start(){
        m_FallingPopcornPresenter = new FallingPopcornPresenter(this, FindObjectOfType<FallingPopcornView>());
    }

    public void AddPoints(int points){
        m_Points += points;
        m_FallingPopcornPresenter.UpdateText();
    }
}