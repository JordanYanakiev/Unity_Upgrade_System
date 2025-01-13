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
       
        //DontDestroyOnLoad(this.gameObject);

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //}

    }

    private void OnEnable()
    {
            goToOtherSceneButton = GameObject.Find("OtherSceneButton").GetComponent<Button>();
            goToOtherSceneButton.onClick.AddListener(GoToOtherScene);
        
    }


    private void GoToOtherScene()
    {
        SceneManager.LoadScene("OtherScene");
    }

    private void Update()
    {
        
    }
}
