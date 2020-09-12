using System;
using System.Collections.Generic;
using System.Linq;

class Bag
{
    private List<Item> Items;
    private readonly int _maxWeidth;

    public Bag(int maxWeidth, List<Item> items)
    {
        _maxWeidth = maxWeidth;
        Items = items;
    }

    public void AddItem(string name, int count)
    {
        int currentWeidth = Items.Sum(item => item.Count);
        Item targetItem = Items.FirstOrDefault(item => item.Name == name);

        if (targetItem == null)
            throw new InvalidOperationException();

        if (currentWeidth + count > _maxWeidth)
            throw new InvalidOperationException();

        targetItem.AddCount(count);
    }
    //"Столкнётесь после освоения темы полиморфизм подтипов". Задача в теме "Инкапсуляция".
    public IEnumerable<IUpdateable> GetItems()
    {
        return Items; // или return _items.AsEnumerable();
    }
}

interface IUpdateable
{
    string GetName();
    int GetCount();
}

class Item : IUpdateable
{
    public readonly string Name;
    public int Count { get; private set; }

    public Item(string name, int count)
    {
        Name = name;
        Count = count;
    }

    public void AddCount(int count)
    {
        Count += count;
    }

    public string GetName() => Name;

    public int GetCount() => Count;
}