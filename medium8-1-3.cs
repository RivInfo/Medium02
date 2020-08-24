using System;
using System.Collections.Generic;
using System.Linq;

class Bag
{
    private List<Item> _items;
    private readonly int _maxWeidth;

    public Bag(int maxWeidth, List<Item> items)
    {
        _maxWeidth = maxWeidth;
        _items = items;
    }

    public void AddItem(string name, int count)
    {
        int currentWeidth = _items.Sum(item => item.Count);
        Item targetItem = _items.FirstOrDefault(item => item.Name == name);

        if (targetItem == null)
            throw new InvalidOperationException();

        if (currentWeidth + count > _maxWeidth)
            throw new InvalidOperationException();

        targetItem.CountPlus(count);
    }

    public IEnumerable<Item> GetItems()
    {
        return _items.AsEnumerable();
    }
}

class Item
{
    public readonly string Name;
    public int Count { get; private set; }

    public Item(string name, int count)
    {
        Name = name;
        Count = count;
    }

    public void CountPlus(int count)
    {
        Count += count;
    }
}