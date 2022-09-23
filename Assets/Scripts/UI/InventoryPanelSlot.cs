﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPanelSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ItemSlot _itemSlot;
    [SerializeField] private Image _draggedItemIcon;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Outline _outline;
    [SerializeField] private Color _draggingColor = Color.gray;

    public void Bind(ItemSlot itemSlot)
    {
        _itemSlot = itemSlot;
        _itemSlot.Changed += UpdateIconSlot;

        UpdateIconSlot();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_itemSlot.IsEmpty) 
            return;

        _itemIcon.color = _draggingColor;
        _draggedItemIcon.sprite = _itemIcon.sprite;
        _draggedItemIcon.enabled = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _draggedItemIcon.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _itemIcon.color = Color.white;
        _draggedItemIcon.sprite = null;
        _draggedItemIcon.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _outline.enabled = true;
        Debug.Log("Outlining");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _outline.enabled = false;
    }

    private void UpdateIconSlot()
    {
        if (_itemSlot.Item != null)
        {
            _itemIcon.sprite = _itemSlot.Item.Icon;
            _itemIcon.enabled = true;
        }
        else
        {
            _itemIcon.sprite = null;
            _itemIcon.enabled = false;
        }
    }
}