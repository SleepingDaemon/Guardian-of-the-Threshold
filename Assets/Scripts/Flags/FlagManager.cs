using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public static FlagManager Instance { get; private set; }

    [SerializeField] private List<GameFlagBase> _allFlags = new List<GameFlagBase>();
    private Dictionary<string, GameFlagBase> _flagsByName;

    private void Awake() => Instance = this;

    private void Start() => _flagsByName = _allFlags.ToDictionary(k => k.name.Replace(" ", ""), v => v);

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
    }
}