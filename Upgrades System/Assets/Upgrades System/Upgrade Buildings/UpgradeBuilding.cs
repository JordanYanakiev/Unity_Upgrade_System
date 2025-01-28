using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuilding : MonoBehaviour
{
    [SerializeField] private int buildingLevel;

    [SerializeField] private Button woodUpgradeButton;
    [SerializeField] private Button goldUpgradeButton;
    [SerializeField] private Button copperUpgradeButton;
    [SerializeField] private List<int> upgradesLevels;
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
        string buttonTag = upgradeButton.tag;
        InGameResourceType resourceType;
        int upgradeLevelIndexPosition = 0;
        int upgradeLevel = 0;

        switch (buttonTag)
        {
            case "WoodUpgradeButon":
                resourceType = InGameResourceType.wood;
                upgradeLevelIndexPosition = 0;
                upgradeLevel = upgradesLevels[upgradeLevelIndexPosition];
                UpgradeUpgrade(resourceType, UpgradesManager.instance.upgradesSo.woodUpgrades, upgradeLevel);
                break;

            case "GoldUpgradeButon":
                resourceType = InGameResourceType.gold;
                upgradeLevelIndexPosition = 1;
                upgradeLevel = upgradesLevels[upgradeLevelIndexPosition];
                UpgradeUpgrade(resourceType, UpgradesManager.instance.upgradesSo.goldUpgrades, upgradeLevel);

                break;

            case "CopperUpgradeButon":
                resourceType = InGameResourceType.copper;
                upgradeLevelIndexPosition = 2;
                upgradeLevel = upgradesLevels[upgradeLevelIndexPosition];
                UpgradeUpgrade(resourceType, UpgradesManager.instance.upgradesSo.copperUpgrades, upgradeLevel);
                break;
        }

    }


    private void UpgradeUpgrade(InGameResourceType resourceType, List<Upgrade> upgradeList, int levelIndex)
    {
        Debug.Log(resourceType + " is upgraded now");
        StartCoroutine(ResearchCountdown(upgradeList, levelIndex));
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




}
