using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolFlag", menuName = "Game Flags/Bool")]
public class BoolGameFlag : GameFlag<bool>
{
    protected override void SetFromData(string value)
    {
        if (Boolean.TryParse(value, out var boolValue))
        {
            Set(boolValue);
        }
    }
}
