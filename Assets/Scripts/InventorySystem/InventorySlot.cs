using System;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private ItemData _item;
    [SerializeField] private int _stackSize;

    public ItemData Item => _item;
    public int StackSize => _stackSize;

    public InventorySlot(ItemData item, int amount)
    {
        _item = item;
        _stackSize = amount;
    }

    public InventorySlot()
    {
        Clearslot();
    }

    public void UpdateInventorySlot(ItemData item, int amount)
    {
        _item = item;
        _stackSize = amount;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = Item.MaxStackSize - _stackSize;

        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (_stackSize + amountToAdd <= _item.MaxStackSize) 
            return true;
        else
            return false;
    }

    public void Clearslot()
    {
        _item = null;
        _stackSize = -1;
    }

    public void AddToStack(int amount) => _stackSize += amount;
    public void RemoveFromStack(int amount) => _stackSize -= amount;
}
