using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "TowerFight/Data/Card Data")]
public class CardData : ScriptableObject
{
    [Header("Card Info")]
    public string cardID;
    public string cardName;
    [TextArea(2, 4)] public string description;
    public Sprite cardIcon;
    public Rarity rarity;

    [Header("Effect Logic")]
    public CardType cardType;
    public CardTarget cardTarget;

    [Tooltip("กำหนดค่าความสามารถเช่น บัฟ 10% ไม้ 500")]
    public float effectValue;
    [Tooltip("ระยะเวลาแสดงผล (ถ้า 0 คือบัฟถาวร หรือเป็นของที่ใช้แล้วทิ้งเลย)")]
    public float duration = 0;
    
    [Header("Visuals")]
    public GameObject activeVfx;
}
