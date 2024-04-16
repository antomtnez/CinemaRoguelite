using UnityEngine;

public interface IPool{
    public GameObject GetObject();
    public void ReturnObject(GameObject go);
}