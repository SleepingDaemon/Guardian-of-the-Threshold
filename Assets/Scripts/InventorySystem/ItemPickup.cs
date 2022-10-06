using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    [SerializeField] private float _pickUpRadius = 0.6f;
    private SphereCollider _col;

    private void Awake()
    {
        _col = GetComponent<SphereCollider>();
        _col.isTrigger = true;
        _col.radius = _pickUpRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryContainer>();
        if (inventory == false) return;
        if (inventory.InventorySystem.AddToInventory(_item, 1))
            Destroy(gameObject);
    }
}
