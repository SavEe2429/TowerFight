using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class BaseClass : ScriptableObject
{
    public virtual void OnEditorRefresh() { }
}


[Serializable]
public class Farm
{
    [Header("--- Read Only Stats ---")]
    public int rice;
    public int wood;
    public int storage;

    [Header("--- Adjustment Settings ---")]
    public int storageRate = 8000;
    public AnimationCurve riceRate = AnimationCurve.Linear(0, 20, 1, 150);
    public AnimationCurve woodRate = AnimationCurve.Linear(0, 10, 1, 100);

    public void updateProduction(int currentLevel, int maxLevel)
    {
        float level = (maxLevel > 1) ? (float)(currentLevel - 1) / (maxLevel - 1) : 1f;
        rice = Mathf.RoundToInt(riceRate.Evaluate(level));
        wood = Mathf.RoundToInt(woodRate.Evaluate(level));
        storage = storageRate * currentLevel;
    }
}
[Serializable]
public class Mine
{
    [Header("--- Read Only Stats ---")]
    public int stone;
    public int iron;
    public int soulStone;
    public int storage;

    [Header("--- Adjustment Settings ---")]
    public int storageRate = 8000;
    public AnimationCurve stoneRate = AnimationCurve.Linear(0, 20, 1, 150);
    public AnimationCurve ironRate = AnimationCurve.Linear(0, 10, 1, 100);
    public AnimationCurve soulStoneRate = AnimationCurve.Linear(0, 1, 1, 10);

    public void updateProduction(int currentLevel, int maxLevel)
    {
        float level = (maxLevel > 1) ? (float)(currentLevel - 1) / (maxLevel - 1) : 1f;
        stone = Mathf.RoundToInt(stoneRate.Evaluate(level));
        iron = Mathf.RoundToInt(ironRate.Evaluate(level));
        soulStone = Mathf.RoundToInt(soulStoneRate.Evaluate(level));
        storage = storageRate * currentLevel;
    }
}

[Serializable]
public class Store
{
    private List<ItemData> itemDatas;
    public List<ItemData> weapon;
    public List<ItemData> armor;
    public List<ItemData> accessory;

    public void FilterByType(ScriptableObject parent)
    {
#if UNITY_EDITOR
        itemDatas = UtilityFunction.GetAllIns<ItemData>();
        weapon = UtilityFunction.SelectByEnum(itemDatas, x => x.itemCategory, ItemCategory.Weapon);
        armor = UtilityFunction.SelectByEnum(itemDatas, x => x.itemCategory, ItemCategory.Armor);
        accessory = UtilityFunction.SelectByEnum(itemDatas, x => x.itemCategory, ItemCategory.Accessory);
        UtilityFunction.SaveChange(parent);
#endif
    }
}
[Serializable]
public class MagicStore
{
    private List<SkillData> skillDatas;
    public List<SkillData> damage;
    public List<SkillData> buff;
    public List<SkillData> debuff;
    public List<SkillData> heal;
    public List<SkillData> cc;

    public void FilterByType(ScriptableObject parent)
    {
#if UNITY_EDITOR
        skillDatas = UtilityFunction.GetAllIns<SkillData>();
        damage = UtilityFunction.SelectByEnum(skillDatas, x => x.effectType, SkillType.Damage);
        buff = UtilityFunction.SelectByEnum(skillDatas, x => x.effectType, SkillType.Buff);
        debuff = UtilityFunction.SelectByEnum(skillDatas, x => x.effectType, SkillType.Debuff);
        heal = UtilityFunction.SelectByEnum(skillDatas, x => x.effectType, SkillType.Heal);
        cc = UtilityFunction.SelectByEnum(skillDatas, x => x.effectType, SkillType.CC);
        UtilityFunction.SaveChange(parent);
#endif
    }
}

[Serializable]
public class GachaTree
{

    private int raceCount ;

    [Header("Min Drop Rate"), Space(10)]
    public AnimationCurve minRate = AnimationCurve.Linear(0, 0, 4, 1);
    [Tooltip("Rarity order(N , R , SR , SSR , UR , SJ)")]
    public float[] rarityMinRate;

    [Header("Max Drop Rate"), Space(10)]
    public AnimationCurve maxRate = AnimationCurve.Linear(0, 0, 4, 1);
    [Tooltip("Rarity order(N , R , SR , SSR , UR , SJ)")]
    public float[] rarityMaxRate;

    [Header("GachaPool")]
    public List<UnitData> unitDatas;
    
    public void RefreshSize() {
        raceCount = System.Enum.GetValues(typeof(Races)).Length;
        if(raceCount > 0)
        {
            System.Array.Resize(ref rarityMaxRate , raceCount);
            System.Array.Resize(ref rarityMinRate , raceCount);
        }
    }
    public void AddKey(AnimationCurve animationCurve)
    {
        if (animationCurve.length < 6)
        {
            while (animationCurve.length > 0) animationCurve.RemoveKey(0);

            for (int i = 0; i < 6; i++)
            {
                // float t = 1f / 6
            }
        }
    }
}