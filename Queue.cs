using System.Collections;

namespace DataStructure;

public class Queue<T> : IEnumerable<T>
{
    private T[] _items;
    private int _count = 0;
    public int capacity = 4;
    public int Count { get { return _count; } }
    public Queue()
    {
        _items = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if (capacity == _items.Length)
            Resize();
        _items[_count] = item;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        var item = _items[0];
        var copiedArray = new T[capacity];
        Array.Copy(_items, 1, copiedArray, 0, _count);
        _items = copiedArray;
        _count--;
        return item;
    }

    public T Peek()
    {
        return _items[0];
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Resize()
    {
        capacity = capacity * 2;
        var data = new T[capacity];
        Array.Copy(_items, data, _items.Length);
        _items = data;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _items.AsEnumerable().GetEnumerator();
    }
}
