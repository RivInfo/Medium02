using System;
using System.Collections.Generic;
using System.Linq;

class Bag
{
    private List<Item> _items;
    private readonly int _maxWeidth;

    public Bag(int maxWeidth, List<Item> items)
    {
        if(items.Sum(item => item.Count)> maxWeidth)
            throw new ArgumentOutOfRangeException();
        _maxWeidth = maxWeidth;
        _items = items;
    }

    public void AddItem(string name, int count)
    {
        int currentWeidth = _items.Sum(item => item.Count);
        Item targetItem = _items.FirstOrDefault(item => item.Name == name);

        if (currentWeidth + count > _maxWeidth)
            throw new InvalidOperationException();

        if (targetItem == null)
            _items.Add(new Item(name, count));
        else
            targetItem.Count += count;
    }

    public IEnumerable<IItem> GetItems()
    {
        return _items;
    }
}

interface IItem
{
    string GetName();
    int GetCount();
}

class Item : IItem
{
    public readonly string Name;
    public int Count;

    public Item(string name, int count)
    {
        Name = name;
        Count = count;
    }

    public string GetName() => Name;

    public int GetCount() => Count;
}