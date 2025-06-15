using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public IReadOnlyList<Item> Items => _items;

    public bool HasFreeSpace() => _items.Count < _maxSize;

    public void Add(Item item)
    {
        if (HasFreeSpace() == false)
        {
            Debug.Log("Inventory is full! Item wasn't added.");
            return;
        }

        _items.Add(item);
    }

    public List<Item> ExtractItemsBy(int id, int count)
    {
        List<Item> extractedItems = _items.Where(item => item.ID == id).Take(count).ToList();
        
        if (extractedItems.Count < count)
            Debug.Log($"There are only {extractedItems.Count} items with id {id} in inventory. Requested {count} items.");
        
        foreach (Item item in extractedItems)
            _items.Remove(item);

        return extractedItems;
    }
}

public class Item
{
    public Item(int id)
    {
        ID = id;
    }

    public int ID { get; private set; }
}