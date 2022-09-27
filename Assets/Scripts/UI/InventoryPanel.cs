using System.Collections;
using System;
using UnityEngine;

public class InventoryPanel : ToggleablePanel
{
    private void Start()
    {
        Bind(Inventory.Instance);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Show();
        }
    }

    public void Bind(Inventory inventory)
    {
        var panelSlots = GetComponentsInChildren<InventoryPanelSlot>();
        for (int i = 0; i < panelSlots.Length; i++)
        {
            panelSlots[i].Bind(inventory.GeneralInventorySlots[i]);
        }
    }
}
