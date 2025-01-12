using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public string upgradeName;
    public float bonusPercent;
    public List<InGameResourceType> resourceRequirements;
    public List<float> resourceQuantityRequirements;
    public float upgradeTime;
}
