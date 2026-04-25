using UnityEngine;

public class UI_BuildingInsp : MonoBehaviour
{
    public BuildingData currentBuilding;


    void Start()
    {
        currentBuilding = GetComponent<BuildingData>();
    }
    // แก้ไขใน UI_BuildingInsp.cs
    public void UpLevel(bool isOn) // เพิ่ม bool เข้าไป
    {
        Debug.Log("!ดด");
        // เราจะอัปเลเวลเฉพาะตอนที่ Toggle ถูกติ๊ก (True) เท่านั้น
        Debug.Log("!");
        if (isOn && currentBuilding != null)
        {
            if (currentBuilding.buildingLevel.x < currentBuilding.buildingLevel.y)
            {
                currentBuilding.buildingLevel.x++;
                Debug.Log("อัปเวลผ่าน Toggle เรียบร้อย!");
                
            }
        }
    }
}

