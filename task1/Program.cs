using AlgorithmsDataStructures2;

class Program
{
    static void Main(string[] args)
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);

        SimpleTree<int> tree = new SimpleTree<int>(node);

        var result = tree.LeafCount();
    }
}