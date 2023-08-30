using AlgorithmsDataStructures2;

class Program
{
    static void Main(string[] args)
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(3, null);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(4, null);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(5, null);

        SimpleTree<int> tree = new SimpleTree<int>(node);
        tree.AddChild(node, node1);
        tree.AddChild(node1, node2);
        tree.AddChild(node2, node3);
        tree.AddChild(node3, node4);


        tree.LeafCount();
    }
}