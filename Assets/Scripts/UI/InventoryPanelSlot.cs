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
    private static InventoryPanelSlot Focused;
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
        if (_itemSlot.IsEmpty == false && Focused != null)
            _itemSlot.Swap(Focused._itemSlot);

        _itemIcon.color = Color.white;
        _draggedItemIcon.sprite = null;
        _draggedItemIcon.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemTooltipPanel.Instance.ShowItem(_itemSlot.Item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Focused = this;
        _outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Focused == this)
            Focused = null;

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