using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    private List<Item> _items = new();
    private int _maxSize;
    
    public Inventory(List<Item> items, int maxSize)
    {
        _items = items;
        _maxSize = maxSize;
    }

    public IReadOnlyList<Item> Items => _items;
    private int CurrentSize => _items.Count;

    public bool TryAddItem(Item item)
    {
        if (CurrentSize + 1 > _maxSize)
        {
            Debug.LogWarning("Max size is " + _maxSize + ", current size is " + CurrentSize);
            return false;
        }

        _items.Add(item);
        return true;
    }

    public bool TryRemoveItemsBy(string name, int count, out List<Item> items)
    {
        List<Item> tempItems = new List<Item>(count);
        
        _items.RemoveAll(x =>
        {
            if (x.Name == name && tempItems.Count < count)
            {
                tempItems.Add(x);
                return true;
            }

            return false;
        });

        items = tempItems;

        return items.Count > 0;
    }
}

public class Item
{
    public string Name { get; private set; }
    
    public Item(string name)
    {
        Name = name;
    }
}