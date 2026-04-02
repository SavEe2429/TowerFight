using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitData" , menuName = "TowerFight/Data/Unit Data")]

public class UnitData : ScriptableObject
{
    [Header("Unit Info")]
    public string unitID; 
    public string unitName; 
    public Sprite unitIcon;
    public GameObject modelPrefab;
    [TextArea(2,4)] public string description;

    [Header("Status")]
    public int maxHealth = 1000;
    public int attackDamage = 100;
    public float attackRange = 1f;
    public float attackSpeed  = 1f;
    public float moveSpeed = 300f;

    [Header("Skill & equipments")]
    public ItemData[] equippedItems = new ItemData[3];
    public SkillData[] skills = new SkillData[2];

    [Header("rarity & cost")]
    public Rarity rarity;
    public int recruitCost = 50;
}
