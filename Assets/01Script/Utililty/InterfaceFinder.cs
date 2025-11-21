using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // c# 쿼리문법제공

public class InterfaceFinder : MonoBehaviour
{
    public static List<T> FindObjectsOfInterface<T>() where T : class
    {
        MonoBehaviour[] allObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        List<T> list = new List<T>();

        foreach(var obj in allObjects)
        {
            if(obj is T iterfaceInst)
                list.Add(iterfaceInst);
        }
        return list;
    }

    public static List<T> FindObjectsOfInterface2<T>() where T : class
    {
        return FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
            .OfType<T>().ToList();
    }
}
