using System;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item Item;
    private SlotData _slotData;

    public bool IsEmpty => Item == null;

    public void SetItem(Item item)
    {
        Item = item;
        _slotData.ItemName = item?.name ?? string.Empty;
    }

    public void Bind(SlotData slotData)
    {
        _slotData = slotData;
        Debug.LogError($"Attempted to load item {_slotData.ItemName}");
        //SetItem();
    }
}

[Serializable]
public class SlotData
{
    public string SlotName;
    public string ItemName;
}