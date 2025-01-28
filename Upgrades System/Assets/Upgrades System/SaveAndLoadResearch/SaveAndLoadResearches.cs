using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using UnityEngine;
using System.Linq;

// TO DO: Finish SaveLoad system for the upgrades

public class SaveAndLoadResearches : MonoBehaviour
{
    #region SINGLETON
    public static SaveAndLoadResearches _instance;

    public static SaveAndLoadResearches instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(SaveAndLoadResearches)) as SaveAndLoadResearches;
            }

            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    #endregion

    [SerializeField]
    private SaveDataUpgradesStates saveData;
    private string fileLocation;

    public SaveDataUpgradesStates SaveData
    {
        get { return saveData; }
        set { saveData = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        saveData = new SaveDataUpgradesStates();
        DontDestroyOnLoad(this.gameObject);
        LoadUpgradeStates();
    }

    public void SaveUpgradeStates()
    {

        // Clear existing save data lists
        var allListsFromSO = UseReflection.GetAllLists(UpgradesManager.instance.upgradesSo);
        var allListsFromSaveData = UseReflection.GetAllLists(saveData);

        for (int i = 0; i < allListsFromSO.Count; i++)
        {
            var sourceList = allListsFromSO[i] as IList;
            var targetList = allListsFromSaveData[i] as IList;

            if (sourceList != null && targetList != null && sourceList.GetType() == targetList.GetType())
            {
                targetList.Clear(); // Clear the save data list
                foreach (var item in sourceList)
                {
                    targetList.Add(item); // Add current state of ScriptableObject data to save data
                }
            }
            else
            {
                Debug.LogError($"Type mismatch or invalid list at index {i}. Source: {sourceList?.GetType()}, Target: {targetList?.GetType()}");
            }
        }
        //fileLocation = Application.persistentDataPath + "/SavedUpgradesStates.nws";

        //saveData.woodUpgradesSaveData = new List<Upgrade>();

        //for (int i = 0; i < UpgradesManager.instance.upgradesSo.woodUpgrades.Count; i++)
        //{
        //    saveData.woodUpgradesSaveData.Add(UpgradesManager.instance.upgradesSo.woodUpgrades[i]);
        //}

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(fileLocation, FileMode.Create);
        bf.Serialize(stream, saveData);
        stream.Close();
    }


    public void LoadUpgradeStates()
    {
        fileLocation = Application.persistentDataPath + "/SavedUpgradesStates.nws";

        if (File.Exists(fileLocation))
        {
            // Deserialize the saved data
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(fileLocation, FileMode.Open);
            saveData = (SaveDataUpgradesStates)bf.Deserialize(stream);
            stream.Close();

            // Get all lists from the ScriptableObject (source) and SaveData (target)
            var soLists = UseReflection.GetAllLists(UpgradesManager.instance.upgradesSo);
            var saveDataLists = UseReflection.GetAllLists(saveData);

            // Replace the data in ScriptableObject with the deserialized saved data
            for (int i = 0; i < soLists.Count; i++)
            {
                var soList = soLists[i] as IList;
                var savedList = saveDataLists[i] as IList;

                if (soList != null && savedList != null && soList.GetType() == savedList.GetType())
                {
                    // Clear the existing data in the ScriptableObject list and replace it
                    soList.Clear();
                    foreach (var item in savedList)
                    {
                        soList.Add(item);
                    }
                }
            }

            Debug.Log("Upgrade states successfully loaded and applied to the ScriptableObject.");
        }
        else if (!File.Exists(fileLocation))
        {
            ////Get all lists from scriptableObject UpgradesSO
            //var allListsFromSO = UseReflection.GetAllLists(UpgradesManager.instance.upgradesSo);
            ////Get all lists from SaveDataUpgradesStates
            //var allListsFromSaveDataUpgradesStates = UseReflection.GetAllLists(saveData);

            ////Populate the saveDataLists with data from UpgradesSO
            //for (int i = 0; i < allListsFromSO.Count; i++)
            //{

            //    if (allListsFromSO[i].GetType() == allListsFromSaveDataUpgradesStates[i].GetType())
            //    {
            //        foreach (var saveItem in allListsFromSO[i])
            //        {
            //            allListsFromSaveDataUpgradesStates[i] = allListsFromSO[i];
            //            //Debug.Log("Stop Here! And the type of the saveItem is " + saveItem.GetType());
            //        }
            //    }
            //}

            // Get all lists from the ScriptableObject (source) and SaveDataUpgradesStates (target)
            var allListsFromSO = UseReflection.GetAllLists(UpgradesManager.instance.upgradesSo);
            var allListsFromSaveData = UseReflection.GetAllLists(saveData);

            // Populate SaveData lists with data from the ScriptableObject
            for (int i = 0; i < allListsFromSO.Count; i++)
            {
                var sourceList = allListsFromSO[i] as IList;
                var targetList = allListsFromSaveData[i] as IList;

                if (sourceList != null && targetList != null && sourceList.GetType() == targetList.GetType())
                {
                    targetList.Clear(); // Clear existing target data if any
                    foreach (var item in sourceList)
                    {
                        targetList.Add(item); // Add items from the ScriptableObject to SaveData
                    }
                }
                else
                {
                    Debug.LogError($"Type mismatch or invalid list at index {i}. Source: {sourceList?.GetType()}, Target: {targetList?.GetType()}");
                }
            }


            #region INITIAL LIST LOAD
            //========== THIS IS WORKING STUFF SO DON'T DELETE IT IN CASE YOU NEED IT======
            //saveData.woodUpgradesSaveData = new List<Upgrade>();

            //for(int i = 0; i < UpgradesManager.instance.upgradesSo.woodUpgrades.Count; i++)
            //{
            //    saveData.woodUpgradesSaveData.Add(UpgradesManager.instance.upgradesSo.woodUpgrades[i]);
            //}
            //=============================================================
            #endregion

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(fileLocation, FileMode.Create);
            bf.Serialize(stream, saveData);
            stream.Close();
        }
    }




}
