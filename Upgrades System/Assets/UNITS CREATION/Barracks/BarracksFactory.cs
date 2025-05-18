using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksFactory : MonoBehaviour
{
    public static BarracksFactory barracksFactory;
    [SerializeField] private List<ISoldier> soldiersInQueue;
    [SerializeField] private List<int> soldiersToTrainAmounts;

    public List<ISoldier> SoldiersInQueue { get => soldiersInQueue; set => soldiersInQueue = value; }
    public List<int> SoldiersToTrainAmounts { get => soldiersToTrainAmounts; set => soldiersToTrainAmounts = value; }


    public void AddSoldiersToQueue(ISoldier soldier, int amount)
    {
        soldiersInQueue.Add(soldier);
        soldiersToTrainAmounts.Add(amount);
    }

    private void Start()
    {
        barracksFactory = this;
        soldiersInQueue = new List<ISoldier>();
    }
}
