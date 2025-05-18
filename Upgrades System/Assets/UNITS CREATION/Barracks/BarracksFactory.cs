using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BarracksFactory : MonoBehaviour
{
    public static BarracksFactory barracksFactory;
    //[SerializeField] private List<ISoldier> soldiersInQueue;
    [SerializeField] private List<string> soldiersInQueue;
    [SerializeField] private List<int> soldiersToTrainAmounts;
    [SerializeField] private List<GameObject> soldiersToTrainGOListDB;
    [SerializeField] private List<GameObject> soldiersToTrainGOList;
    [SerializeField] private Transform unitsQueue;
    [SerializeField] private GameObject unitHolder;
    [SerializeField] private List<GameObject> unitHoldersList;

    //public List<ISoldier> SoldiersInQueue { get => soldiersInQueue; set => soldiersInQueue = value; }
    public List<string> SoldiersInQueue { get => soldiersInQueue; set => soldiersInQueue = value; }
    public List<int> SoldiersToTrainAmounts { get => soldiersToTrainAmounts; set => soldiersToTrainAmounts = value; }


    //public void AddSoldiersToQueue(ISoldier soldier, int amount)
    //{
    //    soldiersInQueue.Add(soldier);
    //    soldiersToTrainAmounts.Add(amount);
    //}
    public void AddSoldiersToQueue(string soldier, int amount)
    {
        soldiersInQueue.Add(soldier);
        soldiersToTrainAmounts.Add(amount);
        VizualiseQueue();
    }

    private void VizualiseQueue()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in unitsQueue)
        {
            children.Add(child.gameObject);
        }

        if (children != null)
        {
            foreach (var child in children)
            {
                Destroy(child);
            }
        }

        soldiersToTrainGOList.Clear();
        foreach (var unit in soldiersInQueue)
        {
            GameObject go = soldiersToTrainGOListDB.FirstOrDefault(u => u.GetComponent<ISoldier>().UnitName == unit);

            soldiersToTrainGOList.Add(go);
        }

        unitHoldersList.Clear();
        foreach (var unit in soldiersToTrainGOList)
        {
            unitHolder.GetComponentInChildren<Text>().text = unit.GetComponent<ISoldier>().UnitName;
            unitHoldersList.Add(Instantiate(unitHolder, unitsQueue));
        }
    }


    private void Start()
    {
        barracksFactory = this;
        //soldiersInQueue = new List<ISoldier>();
    }
}
