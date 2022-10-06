using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> _inventorySlots;
    public List<InventorySlot> InventorySlots => _inventorySlots;
    public int InventorySize => InventorySlots.Count;
    public UnityAction<InventorySlot> OnInventorySlotChanged;


    public InventorySystem(int size)
    {
        _inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            _inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(ItemData item, int amount)
    {
        if(ContainsItem(item, out List<InventorySlot> invSlot)) //check if item exist
        {
            foreach (var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amount))
                {
                    slot.AddToStack(amount);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        
        if(HasFreeSlot(out InventorySlot freeSlot)) //get first available slot
        {
            freeSlot.UpdateInventorySlot(item, amount);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public bool ContainsItem(ItemData item, out List<InventorySlot> invSlot)
    {
        invSlot = _inventorySlots.Where(i => i.Item == item).ToList();
        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.Item == null);
        return freeSlot == null ? false : true;
    }
}
