using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class UseReflection : MonoBehaviour
{
    public UpgradesSO upgradesSO; // Assign your ScriptableObject in the Inspector

    void Start()
    {
        // Get all lists of Upgrade and log upgrade names
        List<IList> allLists = GetAllUpgradeLists(upgradesSO);
        //LogUpgradeNames(allLists);
    }

    List<IList> GetAllUpgradeLists(UpgradesSO scriptableObject)
    {
        List<IList> lists = new List<IList>();

        // Use reflection to find all fields in the ScriptableObject
        FieldInfo[] fields = scriptableObject.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var field in fields)
        {
            // Check if the field is a List<Upgrade>
            if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
            {
                // Ensure it's specifically a List<Upgrade>
                if (field.FieldType.GetGenericArguments()[0] == typeof(Upgrade))
                {
                    // Get the value of the field and add it to the list
                    object value = field.GetValue(scriptableObject);
                    if (value is IList list)
                    {
                        lists.Add(list);
                        Debug.Log($"Upgrade Name: {field.Name}");
                    }
                }
            }
        }

        return lists;
    }

    //void LogUpgradeNames(List<IList> allLists)
    //{
    //    foreach (var list in allLists)
    //    {
            
    //        Debug.Log($"Upgrade Name: {list.GetType().BaseType}");
                
    //    }
    //}
}
