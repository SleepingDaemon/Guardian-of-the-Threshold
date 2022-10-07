using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPanelSlot : MonoBehaviour, 
    IPointerEnterHandler, 
    IPointerExitHandler, 
    IBeginDragHandler, 
    IDragHandler, 
    IEndDragHandler,
    IPointerClickHandler
{
    private static InventoryPanelSlot TargetItemSlot;
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
        if(TargetItemSlot == null)
        {
            //todo: Drop item on the ground
            Inventory.Instance.RemoveItemFromSlot(_itemSlot);
        }

        if (_itemSlot.IsEmpty == false && TargetItemSlot != null)
            Inventory.Instance.Swap( _itemSlot, TargetItemSlot._itemSlot);

        _itemIcon.color = Color.white;
        _draggedItemIcon.sprite = null;
        _draggedItemIcon.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Q) && _itemSlot.IsEmpty == false)
            Inventory.Instance.AddItem(_itemSlot.Item);
        else
            ItemTooltipPanel.Instance.ShowItem(_itemSlot.Item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TargetItemSlot = this;
        _outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (TargetItemSlot == this)
            TargetItemSlot = null;

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