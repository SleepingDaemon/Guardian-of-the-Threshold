using System.Collections;
using System;
using UnityEngine;
using System.Linq;

public class InventoryPanel : ToggleablePanel
{
    [SerializeField] private InventoryPanelSlot _overflowSlot;

    private void Start() => Bind(Inventory.Instance);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Show();
        }
    }

    public void Bind(Inventory inventory)
    {
        var panelSlots = GetComponentsInChildren<InventoryPanelSlot>()
            .Where(t => t != _overflowSlot)
            .ToArray();
        for (int i = 0; i < panelSlots.Length; i++)
        {
            panelSlots[i].Bind(inventory.GeneralInventorySlots[i]);
        }

        _overflowSlot.Bind(inventory.TopOverflowSlot);
    }
}
