using AlgorithmsDataStructures2;

class Program
{
    static void Main(string[] args)
    {
        BSTNode<int> node1 = new BSTNode<int>(2, 2, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

    }
}