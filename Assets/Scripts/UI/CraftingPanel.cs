using UnityEngine;

public class CraftingPanel : ToggleablePanel
{
    private void Start()
    {
        Bind(Inventory.Instance);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Show();
    }

    public void Bind(Inventory inventory)
    {
        var panelSlots = GetComponentsInChildren<InventoryPanelSlot>();
        for (int i = 0; i < panelSlots.Length; i++)
        {
            panelSlots[i].Bind(inventory.CraftingInventorySlots[i]);
        }
    }
}
