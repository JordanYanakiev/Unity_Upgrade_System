using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;







public class UseReflection : MonoBehaviour
{
    public class SomeClass
    {
      public List<string> listOfStrings = new List<string> { "this", " is", " some", " string", " list" };
      public List<float> listOfFloats = new List<float> { 2f, 3.5f };
    }


    public UpgradesSO upgradesSO; // Assign your ScriptableObject in the Inspector
    public SomeClass someClass = new SomeClass()
    {
        listOfStrings = new List<string> { "this", " is", " some", " string", " list" }
    };


    #region SINGLETON
    private static UseReflection _instance;
    public static UseReflection instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(UseReflection)) as UseReflection;
            }
            return _instance;
        }
        set { _instance = value; }
    }
    #endregion






    void Start()
    {
        someClass.listOfStrings = new List<string> { "this", " is", " some", " string", " list" };
        // Get all lists of Upgrade and log upgrade names
        //List<IList> allLists = GetAllUpgradeLists(upgradesSO);


        var allLists2 = GetAllLists(someClass);
        //LogUpgradeNames(allLists);
        Debug.Log("Hello World!");
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

    List<IList> GetAllUpgradeLists<T>(T anyClassToRetrieveListsFrom)
    {
        List<IList> lists = new List<IList>();

        // Use reflection to find all fields in the ScriptableObject
        FieldInfo[] fields = anyClassToRetrieveListsFrom.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        foreach (var field in fields)
        {
            // Check if the field is a List<Upgrade>
            if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(T))
            {
                // Ensure it's specifically a List<Upgrade>
                if (field.FieldType.GetGenericArguments()[0] == typeof(T))
                {
                    // Get the value of the field and add it to the list
                    object value = field.GetValue(anyClassToRetrieveListsFrom);
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


    public static List<IEnumerable> GetAllLists<T>(T obj)
    {
        var result = new List<IEnumerable>();

        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        // Get all fields of the object
        var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            if (IsList(field.FieldType))
            {
                var value = field.GetValue(obj) as IEnumerable;
                if (value != null)
                    result.Add(value);
            }
        }

        // Get all properties of the object
        var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var property in properties)
        {
            if (IsList(property.PropertyType))
            {
                var value = property.GetValue(obj) as IEnumerable;
                if (value != null)
                    result.Add(value);
            }
        }

        return result;
    }

    private static bool IsList(Type type)
    {
        return type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type) && type.GetGenericTypeDefinition() == typeof(List<>);
    }

    //void LogUpgradeNames(List<IList> allLists)
    //{
    //    foreach (var list in allLists)
    //    {

    //        Debug.Log($"Upgrade Name: {list.GetType().BaseType}");

    //    }
    //}
}
