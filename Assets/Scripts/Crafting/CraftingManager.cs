using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public void TryCrafting()
    {
        var itemsInCraftingInventory = Inventory.Instance.CraftingInventorySlots.Count(t => t.IsEmpty == false);
        print(itemsInCraftingInventory);
    }
}
