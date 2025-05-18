using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Factory : MonoBehaviour
{
    [SerializeField] private ISoldier soldier;
    [SerializeField] private List<ISoldier> soldiersInQueList;
    [SerializeField] private List<int> soldiersAmountInQueList;
    [SerializeField] protected GameObject soldierGameObject;
    [SerializeField] protected Text numberOfUnitsToTrain;

    public List<ISoldier> SoldiersInQueueList { get => soldiersInQueList; set => soldiersInQueList = value; }
    public List<int> SoldiersAmountInQueList { get => soldiersAmountInQueList; set => soldiersAmountInQueList = value; }

    public abstract ISoldier GetSoldier(GameObject soldierGameObject);

    public abstract void AddSoldiersToQueue(ISoldier soldier);

}
