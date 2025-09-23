namespace DataStructures;

public class TreeNode
{
    public int? Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(int? value)
    {
        Value = value;
    }
}

public class Tree
{
    public static TreeNode Create()
    {
        TreeNode root = new TreeNode(10);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(-3);

        root.Left.Left = new TreeNode(3);
        root.Left.Right = new TreeNode(2);

        root.Right.Left = new TreeNode(null);
        root.Right.Right = new TreeNode(11);

        root.Left.Left.Left = new TreeNode(3);
        root.Left.Left.Right = new TreeNode(-2);

        root.Left.Right.Left = new TreeNode(null);
        root.Left.Right.Right = new TreeNode(1);

        return root;
    }

    public static void PreOrderDFS(TreeNode? root)
    {
        if (root == null) return;

        Console.WriteLine(root?.Value);
        PreOrderDFS(root?.Left);
        PreOrderDFS(root?.Right);
    }

    public static void InOrderDFS(TreeNode? root)
    {
        if (root == null) return;

        PreOrderDFS(root?.Left);
        Console.WriteLine(root?.Value);
        PreOrderDFS(root?.Right);
    }

    public static void PostOrderDFS(TreeNode? root)
    {
        if (root == null) return;

        PreOrderDFS(root?.Left);
        PreOrderDFS(root?.Right);
        Console.WriteLine(root?.Value);
    }

    public static void PreOrderStackDFS(TreeNode? root)
    {
        if (root == null) return;

        var dfsStack = new Stack<TreeNode>();
        dfsStack.Push(root);

        while (dfsStack.Count > 0)
        {
            var node = dfsStack.Pop();
            Console.WriteLine(node?.Value);

            if (node?.Right != null)
                dfsStack.Push(node.Right);

            if(node?.Left != null)
                dfsStack.Push(node.Left);
        }
    }

    public static void BFS(TreeNode? root)
    {
        if (root == null) return;
        var bfsQueue=new Queue<TreeNode>();
        bfsQueue.Enqueue(root);

        while(bfsQueue.Count > 0)
        {
            var node = bfsQueue.Dequeue();
            Console.WriteLine(node?.Value);
            if(node?.Left!= null) bfsQueue.Enqueue(node.Left);
            if(node?.Right!= null) bfsQueue.Enqueue(node.Right);
        }
    }
}