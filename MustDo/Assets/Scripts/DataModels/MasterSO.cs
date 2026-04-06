using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using NaughtyAttributes;


#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "MasterSO", menuName = "TowerFight/Master/MasterSO")]
public class MasterSO : BaseClass
{
    public List<UnitData> unitDatas;
    public List<SkillData> skillDatas;
    public List<ItemData> itemDatas;
    public List<BuildingData> buildingDatas;
    public List<CardData> cardDatas;

    public static MasterSO Instance;
    private void OnEnable() => Instance = this;

    // [Button("Refresh & Collect All ScriptableObject")]
    public void RefreshAllData()
    {
#if UNITY_EDITOR
        unitDatas = UtilityFunction.GetAllIns<UnitData>();
        skillDatas = UtilityFunction.GetAllIns<SkillData>();
        itemDatas = UtilityFunction.GetAllIns<ItemData>();
        cardDatas = UtilityFunction.GetAllIns<CardData>();
        buildingDatas = UtilityFunction.GetAllIns<BuildingData>();

        SortAllData();
        UtilityFunction.SaveChange(this);
#endif
    }
    void SortAllData()
    {
        UtilityFunction.SortByID(unitDatas, x => x.unitID);
        UtilityFunction.SortByID(skillDatas, x => x.skillID);
        UtilityFunction.SortByID(itemDatas, x => x.itemID);
        UtilityFunction.SortByID(cardDatas, x => x.cardID);
        UtilityFunction.SortByID(buildingDatas, x => x.buildingID);
        // 2. ส่วนสำคัญ: สั่งให้ Unity "บันทึก" การเปลี่ยนแปลงลงไฟล์

        Debug.Log("<color=green><b>[MasterSO]</b> All data sorted and saved to asset file!</color>");
    }

    public override void OnEditorRefresh()
    {
        RefreshAllData();
    }


}