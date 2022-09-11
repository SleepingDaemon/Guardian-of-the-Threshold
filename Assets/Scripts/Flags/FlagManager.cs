using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public static FlagManager Instance { get; private set; }

    [SerializeField] private List<GameFlagBase> _allFlags = new List<GameFlagBase>();

    private void Awake()
    {
        Instance = this;
    }

    public void Set(string flagName, string value)
    {
        var flag = _allFlags.FirstOrDefault(t => t.name.Replace(" ", "") == flagName);
        if(flag == null)
        {
            Debug.LogError($"Flag not found {flagName}");
            return;
        }

        if(flag is IntGameFlag intGameFlag)
        {
            if (int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
        }
    }
}