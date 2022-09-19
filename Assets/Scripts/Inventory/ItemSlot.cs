using System;

[Serializable]
public class ItemSlot
{
    public Item Item;

    public bool IsEmpty => Item == null;

    public void SetItem(Item item)
    {
        Item = item;
    }
}