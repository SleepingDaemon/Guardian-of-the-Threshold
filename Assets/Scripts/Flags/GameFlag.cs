using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolFlag", menuName = "Game Flags/Bool")]
public class GameFlag : ScriptableObject
{
    public static event Action AnyChange;
    public bool Value { get; private set; }

    private void OnEnable()
    {
        Value = default;
    }

    private void OnDisable()
    {
        Value = default;
    }

    public void Set(bool value)
    {
        Value = value;
        AnyChange?.Invoke();
    }
}
