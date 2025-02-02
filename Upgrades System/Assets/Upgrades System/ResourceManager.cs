using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Dictionary<InGameResourceType, float> availableResources;

    private static ResourceManager _instance;
    public static ResourceManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ResourceManager)) as ResourceManager;
            }

            return _instance;
        }

        set { _instance = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        availableResources = new Dictionary<InGameResourceType, float>();
        availableResources.Add(InGameResourceType.copper, 2500);
        availableResources.Add(InGameResourceType.gold, 2500);
        availableResources.Add(InGameResourceType.wood, 2500);
        availableResources.Add(InGameResourceType.stone, 2500);
    }
}
