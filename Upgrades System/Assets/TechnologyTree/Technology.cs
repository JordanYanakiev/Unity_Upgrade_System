using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Technology
{
    public InGameResourceType resourceType;
    public int id;
    public string technologyName;
    public string technologyBonusType;
    public int technologyLevel;
    public int[] connectedSkills;
    public int bonusPercent;
    public bool isDiscovered;
}
