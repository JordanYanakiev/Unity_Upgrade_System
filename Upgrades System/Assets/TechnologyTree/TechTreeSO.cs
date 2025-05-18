using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TechTreeSO : ScriptableObject
{
    public bool isInitializedOnce;
    public List<Technology> skillsList;
}
