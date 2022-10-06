using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventoryContainer : MonoBehaviour
{
    [SerializeField] private int _inventorySize;
    [SerializeField] protected InventorySystem _inventorySystem;
    public InventorySystem InventorySystem => _inventorySystem;
    public static UnityEvent<InventorySystem> OnDynamicInventoryDisplayRequested;

    private void Awake()
    {
        _inventorySystem = new InventorySystem(_inventorySize);
    }
}
