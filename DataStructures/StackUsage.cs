namespace DataStructure
{
    public class StackUsage
    {
        public static void StackUsageExample()
        {
            var stack = new DataStructure.Stack<int>();
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);

            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
            Console.WriteLine($"Poped stack element is{stack.Pop()}");
        }
    }
}
