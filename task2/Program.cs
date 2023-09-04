using AlgorithmsDataStructures2;

class Program
{
    static void Main(string[] args)
    {
        BSTNode<int> node1 = new BSTNode<int>(8, 8, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(12, 12);

        var result1 = tree.GetRoot().NodeValue;
        var result2 = tree.GetRoot().NodeKey;

        var result3 = tree.GetRoot().LeftChild.NodeValue;
        var result4 = tree.GetRoot().LeftChild.NodeKey;

        var result5 = tree.GetRoot().RightChild.NodeValue;
        var result6 = tree.GetRoot().RightChild.NodeKey;
    }
}