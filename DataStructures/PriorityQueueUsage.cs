namespace DataStructure;

public class PriorityQueueUsage
{
    public static void UsePriorityQueue()
    {
        var priorityQueue = new PriorityQueue<int>(15);
        priorityQueue.Add(12);
        priorityQueue.Add(8);
        priorityQueue.Add(0);
        priorityQueue.Add(4);
        priorityQueue.Add(1);
        priorityQueue.Add(2);
        priorityQueue.Add(3);
        priorityQueue.Add(17);
        priorityQueue.Add(5);
        priorityQueue.Add(6);
        priorityQueue.Add(10);
        Console.WriteLine("Priority Queue:");
        foreach (var item in priorityQueue)
        {
            Console.WriteLine(item);
        }

        priorityQueue.Pop();
        Console.WriteLine("Priority Queue after Pop:");
        foreach (var item in priorityQueue)
        {
            Console.WriteLine(item);
        }

        priorityQueue.Remove(6);

        Console.WriteLine("Priority Queue after Remove:");
        foreach (var item in priorityQueue)
        {
            Console.WriteLine(item);
        }
    }
}

