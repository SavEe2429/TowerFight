using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "TowerFight/Data/Building Data")]
public class BuildingData : ScriptableObject
{
    [Header("Building Info")]
    public string buildingID;
    public BuildingType buildingType;
    public GameObject buildingPrefab;
    public Vector2Int gridSize = new Vector2Int(1, 1);// ขนาดสิ่งก่อสร้าง

    [Header("Production (ผลผลิต)")]
    public Resource resourceProductionType;
    public int productionRate = 0;
    

    [Header("Upgrade")]
    [Range(1, 4)] public int buildingLevel = 1;
    public BuildingData nextLevelPrefab;

    [Header("Economy(construct cost)")]
    public int woodCost;
    public int stoneCost;
    public int ironCost;

    void OnValidate()
    {
        woodCost = 100 * buildingLevel;
        stoneCost = 100 * buildingLevel;
        ironCost = 50 * buildingLevel;
    }
}
