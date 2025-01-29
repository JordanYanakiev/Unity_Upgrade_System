using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuilding : MonoBehaviour
{
    [SerializeField] private int buildingLevel;

    [SerializeField] private Button woodUpgradeButton;
    [SerializeField] private Button goldUpgradeButton;
    [SerializeField] private Button copperUpgradeButton;
    [SerializeField] private List<int> upgradesLevels;
    [SerializeField] private ScriptableObject resourcesScriptableObject;
    //upgradesLevels
    // upgradesLevels[0] => Wood
    // upgradesLevels[1] => Gold
    // upgradesLevels[2] => Copper




    // Start is called before the first frame update
    void Start()
    {
        woodUpgradeButton.onClick.AddListener(() => DoUpgrade(woodUpgradeButton));
        goldUpgradeButton.onClick.AddListener(() => DoUpgrade(goldUpgradeButton));
        copperUpgradeButton.onClick.AddListener(() => DoUpgrade(copperUpgradeButton));
    }


    private void DoUpgrade (Button upgradeButton)
    {
        string buttonTag = upgradeButton.name;
        InGameResourceType resourceType;
        int upgradeLevelIndexPosition = 0;
        int upgradeLevel = 0;

        // Reference your ScriptableObject instance
        UpgradesSO upgradesSO = UpgradesManager.instance.upgradesSo;

        // Use reflection to find the corresponding list inside the ScriptableObject
        FieldInfo fieldInfo = typeof(UpgradesSO).GetField(buttonTag, BindingFlags.Public | BindingFlags.Instance);

        if (fieldInfo != null && fieldInfo.GetValue(upgradesSO) is List<Upgrade> upgradeList)
        {
            // Find the next available upgrade (not researched yet)
            Upgrade nextUpgrade = upgradeList.FirstOrDefault(u => !u.isAlreadyResearched);

            resourceType = InGameResourceType.wood;
            UpgradeUpgrade(resourceType, nextUpgrade, upgradeLevel);

            Debug.Log("All upgrades in this category have been researched.");
            //if (nextUpgrade != null)
            //{
            //    //UpgradeUpgrade(nextUpgrade);
            //}
            //else
            //{
            //    Debug.Log("All upgrades in this category have been researched.");
            //}
        }
        else
        {
            Debug.LogError($"No matching upgrade list found for tag: {buttonTag}");
        }





        //switch (buttonTag)
        //{
        //    case "WoodUpgradeButon":
        //        resourceType = InGameResourceType.wood;
        //        upgradeLevelIndexPosition = 0;
        //        upgradeLevel = upgradesLevels[upgradeLevelIndexPosition];
        //        UpgradeUpgrade(resourceType, UpgradesManager.instance.upgradesSo.woodUpgrades, upgradeLevel);
        //        break;

        //    case "GoldUpgradeButon":
        //        resourceType = InGameResourceType.gold;
        //        upgradeLevelIndexPosition = 1;
        //        upgradeLevel = upgradesLevels[upgradeLevelIndexPosition];
        //        UpgradeUpgrade(resourceType, UpgradesManager.instance.upgradesSo.goldUpgrades, upgradeLevel);
        //        break;

        //    case "CopperUpgradeButon":
        //        resourceType = InGameResourceType.copper;
        //        upgradeLevelIndexPosition = 2;
        //        upgradeLevel = upgradesLevels[upgradeLevelIndexPosition];
        //        UpgradeUpgrade(resourceType, UpgradesManager.instance.upgradesSo.copperUpgrades, upgradeLevel);
        //        break;
        //}

    }


    private void UpgradeUpgrade(InGameResourceType resourceType, List<Upgrade> upgradeList, int levelIndex)
    {
        Debug.Log(resourceType + " is upgraded now");
        StartCoroutine(ResearchCountdown(upgradeList, levelIndex));
    }
    
    private void UpgradeUpgrade(InGameResourceType resourceType, Upgrade upgradeToFinish, int levelIndex)
    {
        Debug.Log(resourceType + " is upgraded now");
        StartCoroutine(ResearchCountdown(upgradeToFinish));
    }

    private IEnumerator ResearchCountdown(List<Upgrade> upgradeList, int levelIndex)
    {
        yield return new WaitForSeconds(1f);
        SaveAndLoadResearches.instance.SaveUpgradeStates();


        while (upgradeList[levelIndex].upgradeTime > 0)
        {
            upgradeList[levelIndex].upgradeTime -= 1f;

            SaveAndLoadResearches.instance.SaveUpgradeStates();
            yield return new WaitForSeconds(1f);
        }
        upgradeList[levelIndex].isAlreadyResearched = true;
        upgradeList[levelIndex].isCurrentlyResearching = false;
    }
    
    private IEnumerator ResearchCountdown(Upgrade upgrade)
    {
        yield return new WaitForSeconds(1f);
        SaveAndLoadResearches.instance.SaveUpgradeStates();


        while (upgrade.upgradeTime > 0)
        {
            upgrade.upgradeTime -= 1f;

            SaveAndLoadResearches.instance.SaveUpgradeStates();
            yield return new WaitForSeconds(1f);
        }
        upgrade.isAlreadyResearched = true;
        upgrade.isCurrentlyResearching = false;
    }




}
