using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System 2/Item")]
public class ItemData : ScriptableObject
{
    public Sprite Icon;
    public int MaxStackSize;
}
