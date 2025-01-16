using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


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
        fileLocation = Application.persistentDataPath + "/SavedUpgradesStates.nws";

        saveData.woodUpgradesSaveData = new List<Upgrade>();

        for (int i = 0; i < UpgradesManager.instance.upgradesSo.woodUpgrades.Count; i++)
        {
            saveData.woodUpgradesSaveData.Add(UpgradesManager.instance.upgradesSo.woodUpgrades[i]);
        }

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
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(fileLocation, FileMode.Open);
            stream.Position = 0;
            saveData = (SaveDataUpgradesStates)bf.Deserialize(stream);
            stream.Close();

            int counter = 0;
            foreach (Upgrade upgrade in saveData.woodUpgradesSaveData)
            {
                UpgradesManager.instance.upgradesSo.woodUpgrades[counter] = upgrade;
                counter++;
            }
        }
        else if (!File.Exists(fileLocation))
        {
            saveData.woodUpgradesSaveData = new List<Upgrade>();

            for(int i = 0; i < UpgradesManager.instance.upgradesSo.woodUpgrades.Count; i++)
            {
                saveData.woodUpgradesSaveData.Add(UpgradesManager.instance.upgradesSo.woodUpgrades[i]);
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(fileLocation, FileMode.Create);
            bf.Serialize(stream, saveData);
            stream.Close();
        }
    }




}
