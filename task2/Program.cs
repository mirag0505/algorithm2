using AlgorithmsDataStructures2;

class Program
{
    static void Main(string[] args)
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.DeleteNodeByKey(2);
    }
}