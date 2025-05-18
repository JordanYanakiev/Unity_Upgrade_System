using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitiaFactory : Factory
{
    public override void AddSoldiersToQueue(ISoldier soldier)
    {
        ISoldier soldierToBuild = this.GetSoldier(this.soldierGameObject);
        BarracksFactory.barracksFactory.AddSoldiersToQueue(soldierToBuild.UnitName, int.Parse(numberOfUnitsToTrain.text));
    }
    public void AddSoldiersToQueue()
    {
    ISoldier soldierToBuild = this.GetSoldier(this.soldierGameObject);
    BarracksFactory.barracksFactory.AddSoldiersToQueue(soldierToBuild.UnitName, int.Parse(numberOfUnitsToTrain.text));
    }

    public override ISoldier GetSoldier(GameObject soldierGameObject)
    {
        ISoldier soldierToReturn = soldierGameObject.GetComponent<Soldier>();
        return soldierToReturn;
    }
}
