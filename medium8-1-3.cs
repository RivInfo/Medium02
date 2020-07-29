using System.Collections.Generic;

class Bag
{
    public readonly List<Item> _items;
    private readonly int _maxWeidth; 

    public Bag(int maxWeidth, List<Item> items)
    {
        _maxWeidth = maxWeidth;
        _items = items;
    } 

    public void AddItem(string name, int count)
    {
        int currentWeidth = Items.Sum(item => item.Count);
        Item targetItem = Items.FirstOrDefault(item => item.Name == name);

        if (targetItem == null)
            throw new InvalidOperationException();

        if (currentWeidth + count > MaxWeidth)
            throw new InvalidOperationException();

        targetItem.Count += count;
    }
}

class Item
{
    public int Count;
    public readonly string Name;

}