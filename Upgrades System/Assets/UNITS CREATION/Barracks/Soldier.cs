using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour, ISoldier
{
    [SerializeField] private string unitName;
    [SerializeField] private string unitDescription;
    [SerializeField] private int damage;
    [SerializeField] private int deffense;
    [SerializeField] private float unitBuildTime;

    public string UnitName { get => unitName; set => unitName = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Deffense { get => deffense; set => deffense = value; }
    public float BuildTime { get => unitBuildTime; set => unitBuildTime = value; }
    public string UnitDescription { get => unitDescription; set => unitDescription = value; }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
