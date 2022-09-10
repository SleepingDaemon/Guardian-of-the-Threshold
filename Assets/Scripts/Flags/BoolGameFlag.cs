using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolFlag", menuName = "Game Flags/Bool")]
public class BoolGameFlag : GameFlag<bool>
{
    public void Set(bool value)
    {
        Value = value;
        SendChanged();
    }
}
