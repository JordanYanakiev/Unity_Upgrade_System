using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] public Button goToOtherSceneButton;
    [SerializeField] private List<GameObject> upgradesManagerInstances;
    [SerializeField] public UpgradesSO upgradesSo;

    private static bool isSubscribed = false;

    private static UpgradesManager _instance;
    public static UpgradesManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(UpgradesManager)) as UpgradesManager;
            }
            return _instance;
        }
        set { _instance = value; }
    }

    void Awake()
    {
        SaveAndLoadResearches.instance.LoadUpgradeStates();
        if (!isSubscribed)
        {
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            isSubscribed = true;
            //Debug.Log("Subscribed to SceneUnloaded event");
        }
    }

    private void OnEnable()
    {
        goToOtherSceneButton = GameObject.Find("OtherSceneButton").GetComponent<Button>();
        goToOtherSceneButton.onClick.AddListener(GoToOtherScene);
    }

    private void GoToOtherScene()
    {
        SaveAndLoadResearches.instance.SaveUpgradeStates();
        SceneManager.LoadScene("OtherScene");
    }

    private void OnSceneUnloaded(Scene current)
    {
        StopAllCoroutines();
        //SaveAndLoadResearches.instance.SaveUpgradeStates();
        //Debug.Log("OnSceneUnloaded: " + current);
    }
    void OnDestroy()
    {
        // Static persists, so no need to unsubscribe unless shutting down the game.
        //SceneManager.sceneUnloaded -= OnSceneUnloaded;
        //Debug.Log("Unsubscribed from SceneUnloaded event");
    }
}
