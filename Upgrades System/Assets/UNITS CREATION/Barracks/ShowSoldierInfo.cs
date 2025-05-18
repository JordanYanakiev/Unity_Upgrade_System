using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSoldierInfo : MonoBehaviour
{
    [SerializeField] private GameObject unitToDisplay;
    [SerializeField] private Text unitName;
    [SerializeField] private Text unitDescription;
    [SerializeField] private ISoldier iSoldier;


    // Start is called before the first frame update
    void Start()
    {
        iSoldier = unitToDisplay.GetComponent<ISoldier>();
        unitName.text = iSoldier.UnitName;
        unitDescription.text = iSoldier.UnitDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
