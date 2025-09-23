using DataStructures;
using DataStructures.Patterns.PrefixSum;

class Program
{
    static void Main()
    {
        var root = Tree.Create();
        Console.WriteLine("Pre Order");
        Tree.PreOrderDFS(root);
        Console.WriteLine("Pre Order with stack");
        Tree.PreOrderStackDFS(root);

        Console.WriteLine("BFS");
        Tree.BFS(root);

        Console.WriteLine("In Order");
        Tree.InOrderDFS(root);
        Console.WriteLine("Post Order");
        Tree.PostOrderDFS(root);
    }
}
