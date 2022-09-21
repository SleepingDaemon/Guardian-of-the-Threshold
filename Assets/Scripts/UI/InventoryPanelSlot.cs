using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPanelSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemSlot _itemSlot;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Outline _outline;

    public void Bind(ItemSlot itemSlot)
    {
        _itemSlot = itemSlot;
        _itemSlot.Changed += UpdateIconSlot;

        UpdateIconSlot();
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