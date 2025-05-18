using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public int productionRate;
    public int bonusProductionRate;

    private void Awake()
    {
        //bonusProductionRate = LoadTechTreeBonus.loadTecTreeBonus.activeBonuses[3];        
        bonusProductionRate = (LoadTechTreeBonus.loadTecTreeBonus.GetAbility03Bonus());

        Debug.Log($"Production rate = {productionRate} \n Bonus production rate = {bonusProductionRate}");

        LoadTechTreeBonus.loadTecTreeBonus.GetAbility03Bonus();
    }
}
