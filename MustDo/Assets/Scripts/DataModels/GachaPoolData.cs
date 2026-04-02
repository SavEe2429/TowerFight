using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGachaPoolData", menuName = "TowerFight/Data/GachaPoolData")]
public class GachaPoolData : ScriptableObject
{
    [Header("Gacha Info")]
    public string GachaID;
    public string GachaName;
    
    [Header("Drop Rate(%)")]
    public float rateN = 45f;
    // public float rateR = 
    // public float rateSR = 
    // public float rateSSR = 
    // public float rateUR = 
    // public float rateSJ = 
    
}
