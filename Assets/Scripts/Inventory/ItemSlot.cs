using System;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public event Action Changed;

    public Item Item;

    private SlotData _slotData;

    public bool IsEmpty => Item == null;

    public bool HasStackSpaceAvailable => _slotData.StackCount < Item.MaxStackSize;

    public void SetItem(Item item)
    {
        var previousItem = Item;
        Item = item;
        _slotData.ItemName = item?.name ?? string.Empty;
        _slotData.StackCount = 1;

        if (previousItem != Item)
            Changed?.Invoke();
    }

    public void Bind(SlotData slotData)
    {
        _slotData = slotData;
        var item = Resources.Load<Item>("Items/" + _slotData.ItemName);
        SetItem(item);
    }

    public void Swap(ItemSlot slotToSwapWith)
    {
        var itemInOtherSlot = slotToSwapWith.Item; //Cache item
        slotToSwapWith.SetItem(Item); //Set item to new slot
        SetItem(itemInOtherSlot); //Set item to cached slot
    }

    public void RemoveItem()
    {
        SetItem(null);
    }

    public void ModifyStack(int amount)
    {
        _slotData.StackCount += amount;
        Changed?.Invoke();
    }
}

[Serializable]
public class SlotData
{
    public string SlotName;
    public string ItemName;
    public int StackCount;
}