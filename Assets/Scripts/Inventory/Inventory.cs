using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum InventoryType
{
    General,
    Crafting,
}

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    const int GENERAL_SIZE = 12;
    const int CRAFTING_SIZE = 9;

    public ItemSlot[] GeneralInventorySlots = new ItemSlot[GENERAL_SIZE];
    public ItemSlot[] CraftingInventorySlots = new ItemSlot[GENERAL_SIZE];

    public Item _debugItem;

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < GENERAL_SIZE; i++)
        {
            GeneralInventorySlots[i] = new ItemSlot();
        }

        for (int i = 0; i < CRAFTING_SIZE; i++)
        {
            CraftingInventorySlots[i] = new ItemSlot();
        }
    }

    public void AddItem(Item item, InventoryType preferredInventoryType = InventoryType.General)
    {
        var preferredSlots = preferredInventoryType == InventoryType.General ? GeneralInventorySlots : CraftingInventorySlots;
        var backupSlots = preferredInventoryType != InventoryType.General ? CraftingInventorySlots : GeneralInventorySlots;

        var firstEmptySlot = preferredSlots.FirstOrDefault(t => t.IsEmpty);

        if (firstEmptySlot == null)
            firstEmptySlot = backupSlots.FirstOrDefault(t => t.IsEmpty);

        if (firstEmptySlot != null)
            firstEmptySlot.SetItem(item);
        else
            Debug.LogError("Player Inventory is full");
    }

    [ContextMenu(nameof(AddDebugItem))]
    public void AddDebugItem()
    {
        AddItem(_debugItem);
    }

    [ContextMenu(nameof(MoveItemsRight))]
    public void MoveItemsRight()
    {
        var lastItem = GeneralInventorySlots.Last().Item;
        for (int i = GENERAL_SIZE - 1; i > 0; i--)
        {
            GeneralInventorySlots[i].SetItem(GeneralInventorySlots[i - 1].Item);
        }

        GeneralInventorySlots.First().SetItem(lastItem);
    }

    public void ClearCraftingSlots()
    {
        foreach (var slot in CraftingInventorySlots)
        {
            slot.RemoveItem();
        }
    }

    public void Bind(List<SlotData> slotDatas)
    {
        for (int i = 0; i < GeneralInventorySlots.Length; i++)
        {
            var slot = GeneralInventorySlots[i];
            var slotData = slotDatas.FirstOrDefault(t => t.SlotName == "General" + i);
            if(slotData == null)
            {
                slotData = new SlotData() { SlotName = "General" + i };
                slotDatas.Add(slotData);
            }

            slot.Bind(slotData);
        }

        for (int i = 0; i < CraftingInventorySlots.Length; i++)
        {
            var slot = CraftingInventorySlots[i];
            var slotData = slotDatas.FirstOrDefault(t => t.SlotName == "Crafting" + i);
            if (slotData == null)
            {
                slotData = new SlotData() { SlotName = "Crafting" + i };
                slotDatas.Add(slotData);
            }

            slot.Bind(slotData);
        }
    }
}
