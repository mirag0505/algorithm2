using AlgorithmsDataStructures2;

class Program
{
    static void Main(string[] args)
    {
        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(12, 12);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(6, 6);

        tree.AddKeyValue(10, 10);
        tree.AddKeyValue(14, 14);

        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        List<BSTNode<int>> result1 = tree.DeepAllNodes(0);
    }
}