using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Gacha/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject prefab;
}