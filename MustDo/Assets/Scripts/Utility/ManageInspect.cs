#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public static class UtilityFunction
{
    public static List<T> GetAllIns<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        List<T> tempStack = new List<T>();

        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if (asset != null) tempStack.Add(asset);
        }
        return tempStack;
    }

    public static void SortByID<T>(List<T> list, Func<T, string> keySelector)
    {
        if (list != null && list.Count > 1)
        {
            list.Sort((a, b) => string.Compare(keySelector(a), keySelector(b)));
        }
    }

    public static List<T> SelectByEnum<T,TEnum>(List<T> list, Func<T, TEnum> keySelector , TEnum target)
    {
        if (list == null || list.Count <= 1) return new List<T>();

        return list.FindAll(item => keySelector(item).Equals(target));
    }

    public static void SaveChange(UnityEngine.Object targetObject)
    {
        EditorUtility.SetDirty(targetObject);
        AssetDatabase.SaveAssets();
        Debug.Log("<color=cyan><b>[MasterSO]</b> Save!</color>");
    }
}

#endif