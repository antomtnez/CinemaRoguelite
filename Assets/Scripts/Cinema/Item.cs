using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items")]
public class Item : ScriptableObject{
    public string ID;
    public string Name;
    public string Description;
    public int Amount;
    public int MaxAmount;
    public Sprite Icon;
}
