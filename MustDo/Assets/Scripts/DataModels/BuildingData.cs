using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "TowerFight/Data/Building Data")]
public class BuildingData : BaseClass
{
    // สร้าง Event ไว้ให้ตึกมา "ติดตาม"
    public System.Action OnDataChanged;
    
    [Header("Building Info")]
    public string buildingID;
    public BuildingType buildingType;
    public Vector2Int gridSize = new Vector2Int(1, 1);

    [Tooltip("X = Current Level, Y = Max Level")]
    public Vector2Int buildingLevel = new Vector2Int(1, 4);

    public GameObject[] buildingLevelPrefab = new GameObject[4];


    // -------------------- BuildingType Info --------------------
    // <<< Farm Info >>>
    [ShowIf("buildingType", BuildingType.Farm)]
    public Farm farm;

    // <<< Farm Mine >>>
    [ShowIf("buildingType", BuildingType.Mine)]
    public Mine mine;

    // <<< Farm Store >>>
    [ShowIf("buildingType", BuildingType.Store)]
    public Store store;

    // <<< Farm MagicStore >>>
    [ShowIf("buildingType", BuildingType.MagicStore)]
    public MagicStore magicStore;

    [ShowIf("buildingType", BuildingType.GachaTree)]
    public GachaTree gachaTree;

    // -------------------- BuildingUpgrade Info --------------------
    [ReadOnly, BoxGroup("Upgrade Supply (ReadOnly)")]
    public int woodCost, stoneCost, ironCost;

    [BoxGroup("Params Adjustment")]
    public int woodRate = 15000, stoneRate = 10000, ironRate = 10000;

    public override void OnEditorRefresh()
    {
        if (buildingType == BuildingType.Store && store != null)
        {
            store.FilterByType(this);
        }
        else if (buildingType == BuildingType.MagicStore && magicStore != null)
        {
            magicStore.FilterByType(this);
        }
    }
    void OnValidate()
    {
        gachaTree.RefreshSize();
        // ดึงค่าออกมาพักไว้ก่อน เพื่อให้อ่านง่าย
        int current = buildingLevel.x;
        int max = buildingLevel.y;

        if (buildingLevelPrefab == null || buildingLevelPrefab.Length != max)
        {
            System.Array.Resize(ref buildingLevelPrefab, max);
        }

        // ป้องกันเลเวลติดลบ หรือเกิน Max (Clamp ค่า current แล้วใส่กลับไปที่ x)
        current = Mathf.Clamp(current, 1, max);
        buildingLevel.x = current;

        UpdateStatus(current, max);
        // คำนวณราคา (ใช้ current มาคำนวณ)
        // สูตร (int)(current * 1.3f) จะทำให้ราคาเพิ่มขึ้นแบบทวีคูณนิดๆ
        float multiplier = current * 1.3f;
        woodCost = Mathf.RoundToInt(woodRate * multiplier);
        stoneCost = Mathf.RoundToInt(stoneRate * multiplier);
        ironCost = Mathf.RoundToInt(ironRate * multiplier);
        OnDataChanged?.Invoke();
    }

    void UpdateStatus(int current, int max)
    {
        // อัปเดตข้อมูลการผลิต (ส่ง x และ y ไป)
        if (buildingType == BuildingType.Farm && farm != null)
        {
            farm.updateProduction(current, max);
        }
        // อย่าลืมอัปเดตเหมืองด้วยนะถ้ามีฟังก์ชันเหมือนกัน
        if (buildingType == BuildingType.Mine && mine != null)
        {
            mine.updateProduction(current, max);
        }

    }
}