namespace DataStructure;

public class PriorityQueueImprovedUsage
{
    public static void UsePriorityQueue()
    {
        var priorityQueue = new PriorityQueueImproved<int>(15);
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
        priorityQueue.Remove(17);
        priorityQueue.Remove(5);
        priorityQueue.Remove(10);

        Console.WriteLine("Priority Queue after Pop:");
        foreach (var item in priorityQueue)
        {
            Console.WriteLine(item);
        }
    }
}
