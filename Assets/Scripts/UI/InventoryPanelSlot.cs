using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelSlot : MonoBehaviour
{
    private ItemSlot _itemSlot;
    [SerializeField] private Image _itemIcon;

    public void Bind(ItemSlot itemSlot)
    {
        _itemSlot = itemSlot;

        if (itemSlot.Item != null)
        {
            _itemIcon.sprite = itemSlot.Item.Icon;
            _itemIcon.enabled = true;
        }
        else
        {
            _itemIcon.sprite = null;
            _itemIcon.enabled = false;
        }
    }
}