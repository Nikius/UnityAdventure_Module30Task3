using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private readonly List<Item> _items = new();
    private readonly int _maxSize;

    public Inventory(List<Item> items, int maxSize)
    {
        _maxSize = maxSize;
        
        foreach (Item item in items)
            Add(item);
    }

    public List<Item> Items => _items;

    public void Add(Item item)
    {
        if (_items.Count >= _maxSize)
            return;

        _items.Add(item);
    }

    public List<Item> ExtractItemsBy(int id, int count)
    {
        List<Item> extractedItems = _items.Where(item => item.ID == id).Take(count).ToList();
        
        foreach (Item item in extractedItems)
            _items.Remove(item);

        return extractedItems;
    }
}

public class Item
{
    public int ID;

    public Item(int id)
    {
        ID = id;
    }
}