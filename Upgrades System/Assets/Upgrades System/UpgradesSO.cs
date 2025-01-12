using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradesSO : ScriptableObject
{
    public List<Upgrade> woodUpgrades;
    public List<Upgrade> goldUpgrades;
    public List<Upgrade> copperUpgrades;
}
