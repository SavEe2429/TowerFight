using UnityEngine;

public class SO_MOCKUP : MonoBehaviour
{
    public ItemData itemData;
    public SkillData skillData;
    public UnitData unitData;
    public CardData cardData;
    public BuildingData buildingData;

    void OnEnable()
    {
        if(buildingData != null)
        {
            buildingData.OnDataChanged += RefreshStatus;
            RefreshStatus();
        }
    }

    void OnDisable()
    {
        if(buildingData != null)
        {
            buildingData.OnDataChanged -= RefreshStatus;
        }
    }

    void RefreshStatus()
    {
        // if(buildingData == null) return;
        // if(buildingData.buildingType == BuildingType.Farm)
        // {
            
        // }
        Debug.Log($"<color=green>ตึก {gameObject.name} อัปเดตค่า Rice เป็น: </color>");
    }
}
