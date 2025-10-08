namespace DataStructure;

public class QueueUsage
{
    public static void QueueUsageExamples()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);

        Console.WriteLine($"Queue peek{queue.Peek()}");
        Console.WriteLine($"Queue Dequeue {queue.Dequeue()}");
        Console.WriteLine($"Queue Dequeue {queue.Dequeue()}");
        Console.WriteLine($"Queue Dequeue {queue.Dequeue()}");
        Console.WriteLine($"Queue Dequeue {queue.Dequeue()}");
        Console.WriteLine($"Queue Dequeue {queue.Dequeue()}");

        Console.WriteLine($"Queue IsEmpty,{queue.IsEmpty()}");
    }
}
