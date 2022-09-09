using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolFlag", menuName = "Game Flags/Bool")]
public class GameFlag : ScriptableObject
{
    public bool Value;

    private void OnEnable()
    {
        Value = default;
    }
}
