using System.Collections;
using System.Collections.Generic;

public class PlayerInven
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item Item)
    {
        items.Add(Item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item); 
    }
}
