using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "TowerFight/Data/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Item Info")]
    public string itemID;
    public string itemName;
    public Sprite itemIcon;
    public ItemCategory itemCategory;
    [TextArea(2, 4)] public string description;

    [Header("Status")]
    public int bonusHealth;
    public int bonusAttack;
    public int duration;
    public int recruitCost;

    [Header("Sell")]
    public int sellPrice;

}
