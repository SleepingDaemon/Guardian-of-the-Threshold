using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public Sprite Icon;

    [TextArea(3, 10)]
    public string Description;
    public int MaxStackSize;

    [ContextMenu(nameof(Add1))] public void Add1() { Inventory.Instance.AddItem(this); }
    [ContextMenu(nameof(Add5))] public void Add5() { for (int i = 0; i < 5; i++) { Add1(); } }

    [ContextMenu(nameof(Add10))]
    public void Add10()
    {
        for (int i = 0; i < 10; i++)
        {
            Add1();
        }
    }
}
