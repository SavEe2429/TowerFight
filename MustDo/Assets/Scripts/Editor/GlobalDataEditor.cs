#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using NaughtyAttributes.Editor; // ต้องเพิ่มตัวนี้เข้ามาเพื่อรองรับ ShowIf

[CustomEditor(typeof(BaseClass), true)]
public class GlobalDataEditor : NaughtyInspector // เปลี่ยนจาก Editor เป็น NaughtyInspector
{
    public override void OnInspectorGUI()
    {
        // ดึงข้อมูล ScriptableObject ออกมา
        BaseClass data = (BaseClass)target;

        Color myCustomColor = Color.gray;
        ColorUtility.TryParseHtmlString("#dddddd", out myCustomColor);
        // --- ส่วนที่ 1: วาดปุ่ม REFRESH ไว้นอกก้อนข้อมูล (บนสุด) ---

        if (data is BuildingData buildingData)
        {
            if (buildingData.buildingType == BuildingType.Store)
            {
                DrawCustomButton("REFRESH STORE ITEMS", myCustomColor, () => data.OnEditorRefresh());
            }
            else if (buildingData.buildingType == BuildingType.MagicStore)
            {
                DrawCustomButton("REFRESH MAGIC SKILLS", myCustomColor, () => data.OnEditorRefresh());
            }
        }else if(data is MasterSO)
        {
                DrawCustomButton("REFRESH SO", myCustomColor, () => data.OnEditorRefresh());
        }




        // --- ส่วนที่ 2: วาด Inspector ตามปกติ (รวมถึง ShowIf, BoxGroup ทั้งหมด) ---
        base.OnInspectorGUI();
    }

    // ฟังก์ชันช่วยวาดปุ่มให้โค้ดดูสะอาดขึ้น
    private void DrawCustomButton(string label, Color color, System.Action action)
    {
        GUI.color = color;
        if (GUILayout.Button(label, GUILayout.Height(20)))
        {
            action?.Invoke();
        }
        GUI.color = Color.white;
        EditorGUILayout.Space();
    }
}
#endif