using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "MasterSO", menuName = "TowerFight/Master/MasterSO")]
public class MasterSO : ScriptableObject
{
    public List<UnitData> unitDatas;
    public List<SkillData> skillDatas;
    public List<ItemData> itemDatas;
    public List<BuildingData> buildingDatas;
    public List<CardData> cardDatas;

    public static MasterSO Instance;
    private void OnEnable() => Instance = this;

    [ContextMenu("Refresh & Collect All ScriptableObject")]
    private void RefreshAllData()
    {
#if UNITY_EDITOR
        unitDatas = GetAllIns<UnitData>();
        skillDatas = GetAllIns<SkillData>();
        itemDatas = GetAllIns<ItemData>();
        cardDatas = GetAllIns<CardData>();
        buildingDatas = GetAllIns<BuildingData>();

        SortAllData();
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
        Debug.Log("<color=cyan><b>[MasterSO]</b> Refresh ครบจบในปุ่มเดียว!</color>");
#endif
    }

    private List<T> GetAllIns<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        List<T> tempStack = new List<T>();

        for(int i = 0 ; i < guids.Length ; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if(tempStack != null) tempStack.Add(asset);
        }
        return tempStack;
    }

    
    // [ContextMenu("Sort All Data By ID")]
    void SortAllData()
    {
        SortList(unitDatas, x => x.unitID);
        SortList(skillDatas, x => x.skillID);
        SortList(itemDatas, x => x.itemID);
        SortList(cardDatas, x => x.cardID);
        SortList(buildingDatas, x => x.buildingID);
        // 2. ส่วนสำคัญ: สั่งให้ Unity "บันทึก" การเปลี่ยนแปลงลงไฟล์

        Debug.Log("<color=green><b>[MasterSO]</b> All data sorted and saved to asset file!</color>");
    }

    private void SortList<T>(List<T> list, Func<T, string> keySeclector)
    {
        if (list != null && list.Count > 0)
        {
            list.Sort((a, b) => string.Compare(keySeclector(a), keySeclector(b)));
        }
    }
} 