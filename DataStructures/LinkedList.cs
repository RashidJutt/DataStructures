namespace DataStructure;

public class LinkedList<T>
{
    private LinkedListNode<T>? head;
    private int count;
    public int Count { get { return count; } }

    public LinkedList(T value)
    {
        head = new LinkedListNode<T> { Value = value };
        count++;
    }

    public void Add(T item)
    {
        if (head == null)
        {
            head = new LinkedListNode<T>();
            head.Value = item;
        }
        else
        {
            var current = new LinkedListNode<T>();
            current.Value = item;
            current.Next = head;
            head = current;
            current.Next.Previous = head;
        }

        count++;
    }

    public T? Find(T item)
    {
        var current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                return current.Value;
            }
            current = current?.Next!;
        }

        return default;
    }
}

public class LinkedListNode<T>
{
    public T Value { get; set; } = default!;
    public LinkedListNode<T> Next { get; set; } = default!;
    public LinkedListNode<T> Previous { get; set; } = default!;
}

