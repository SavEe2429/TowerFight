using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkillData", menuName = "TowerFight/Data/Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("Skill Info")]
    public string skillID;
    public string skillName;
    public SkillType effectType;
    [ResizableTextArea] public string description;

    [Header("Parameters")]
    public float damageMultiplier = 1.5f;
    public float coolDown = 20f;
    public float duration = 2f;

    [Header("Visual")]
    public GameObject vfxPrefab;
    public string aniTriggerName;
}
