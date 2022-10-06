using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image _itemSprite;
    [SerializeField] private TMP_Text _itemCount;
    [SerializeField] private InventorySlot _assignedInventorySlot;

    private Button button;
    public InventorySlot AssignedInventorySlot => _assignedInventorySlot;

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }

    public void Init(InventorySlot slot)
    {
        _assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    private void UpdateUISlot(InventorySlot slot)
    {
        if(slot.Item != null)
        {
            _itemSprite.sprite = slot.Item.Icon;
            _itemSprite.color = Color.white;

            if (slot.StackSize > 1) 
                _itemCount.SetText(slot.StackSize.ToString());
            else 
                _itemCount.SetText("");
        }
        else
        {
            ClearSlot();
        }
    }

    public void UpdateUISlot()
    {
        if (_assignedInventorySlot != null) UpdateUISlot(_assignedInventorySlot);
    }

    private void ClearSlot()
    {
        _assignedInventorySlot?.Clearslot();
        _itemSprite.sprite = null;
        _itemSprite.color = Color.clear;
        _itemCount.SetText("");
    }

    private void OnUISlotClick()
    {
        //Access Display class function
    }
}
