using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoldier
{
    public string UnitName { get; set; }
    public int Damage { get; set; }
    public int Deffense { get; set; }
    public float BuildTime { get; set; }
    public string UnitDescription { get; set; }

    public void Initialize();
    public void Attack();
    public void TakeDamage();
}
