using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int GENERAL_SIZE = 9;
    public ItemSlot[] GeneralInventory = new ItemSlot[GENERAL_SIZE];
    public Item _debugItem;

    private void Awake()
    {
        for (int i = 0; i < GENERAL_SIZE; i++)
        {
            GeneralInventory[i] = new ItemSlot();
        }
    }

    public void AddItem(Item item)
    {
        var firstEmptySlot = GeneralInventory.FirstOrDefault(t => t.IsEmpty);
        firstEmptySlot.SetItem(item);
    }

    [ContextMenu(nameof(AddDebugItem))]
    public void AddDebugItem()
    {
        AddItem(_debugItem);
    }

    [ContextMenu(nameof(MoveItemsRight))]
    public void MoveItemsRight()
    {
        var lastItem = GeneralInventory.Last().Item;
        for (int i = GENERAL_SIZE - 1; i > 0; i--)
        {
            GeneralInventory[i].SetItem(GeneralInventory[i - 1].Item);
        }

        GeneralInventory.First().SetItem(lastItem);
    }
}
