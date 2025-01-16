using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDataUpgradesStates 
{
    //public bool isCurrentlyResearching;
    //public bool isAlreadyResearched = false;
    //public string upgradeName;
    //public float bonusPercent;
    //public List<InGameResourceType> resourceRequirements;
    //public List<float> resourceQuantityRequirements;
    //public float upgradeTime;
    public List<Upgrade> woodUpgradesSaveData;
    public List<Upgrade> goldUpgradesSaveData;
    public List<Upgrade> stoneUpgradesSaveData;
}
