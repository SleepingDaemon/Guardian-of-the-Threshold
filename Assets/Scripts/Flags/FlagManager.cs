﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public static FlagManager Instance { get; private set; }

    [SerializeField] private GameFlagBase[] _allFlags;
    private Dictionary<string, GameFlagBase> _flagsByName;

    private void Awake() => Instance = this;

    private void Start() => _flagsByName = _allFlags.ToDictionary(k => k.name.Replace(" ", ""), v => v);
    private void OnValidate()
    {
        _allFlags = GetAllInstances<GameFlagBase>();
    }

    public static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;
    }

    public void Set(string flagName, string value)
    {
        if(_flagsByName.TryGetValue(flagName, out var flag) == false)
        {
            Debug.LogError($"Flag not found {flagName}");
            return;
        }

        if(flag is IntGameFlag intGameFlag)
        {
            if (int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
        }
        else if (flag is BoolGameFlag boolGameFlag)
        {
            if (bool.TryParse(value, out var boolGameValue))
                boolGameFlag.Set(boolGameValue);
        }
        else if (flag is StringGameFlag stringGameFlag)
        {
            stringGameFlag.Set(value);
        }
        else if (flag is DecimalGameFlag decimalGameFlag)
        {
            if (decimal.TryParse(value, out var decimalGameValue))
                decimalGameFlag.Set(decimalGameValue);
        }
    }
}