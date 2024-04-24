using UnityEngine;

public interface IPlayerBehaviourManagable{
    public void InitBehaviour();
    public void StopBehaviour();
}

public abstract class PlayerBehaviour : MonoBehaviour, IPlayerBehaviourManagable{
    [SerializeField] bool EnableBehaviour = false;
    public void InitBehaviour(){
        EnableBehaviour = true;
    }

    public void StopBehaviour(){
        EnableBehaviour = false;
    }

    void Update(){
        if(EnableBehaviour){
            Movement();
            if(Input.GetKeyDown(KeyCode.Space)) Action();
        }
    }

    public abstract void Movement();
    public abstract void Action();
}