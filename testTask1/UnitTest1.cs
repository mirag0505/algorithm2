using AlgorithmsDataStructures2;

namespace testTask1;

public class UnitTest1
{
    [Fact]
    public void CreateEmptyTree()
    {
        SimpleTree<int> tree = new SimpleTree<int>(null);
        // Assert.Equal(0, tree.Count());
        Assert.Equal(null, tree.Root);
    }

    [Fact]
    public void CreateTreeWithNode()
    {
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTree<int> tree1 = new SimpleTree<int>(node1);
        // Assert.Equal(1, tree1.Count());
        Assert.Equal(node1, tree1.Root);

        SimpleTreeNode<string> node2 = new SimpleTreeNode<string>("abc", null);
        SimpleTree<string> tree2 = new SimpleTree<string>(node2);
        // Assert.Equal(1, tree2.Count());
        Assert.Equal(node2, tree2.Root);
    }

    [Fact]
    public void AddChildByNullRoot()
    {
        SimpleTree<int> tree = new SimpleTree<int>(null);
        Assert.Equal(0, tree.Count());
        Assert.Equal(null, tree.Root);

        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        tree.AddChild(null, node1);
        // Assert.Equal(1, tree.Count());
        Assert.Equal(node1, tree.Root);
        Assert.Equal(1, node1.NodeValue);
    }

    [Fact]
    public void AddChildByRoot()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTree<int> tree = new SimpleTree<int>(node);
        // Assert.Equal(1, tree.Count());
        Assert.Equal(1, node.NodeValue);

        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, null);
        tree.AddChild(node, node1);
        // Assert.Equal(2, tree.Count());
        Assert.Equal(node, tree.Root);
        Assert.Equal(node.Children[0], node1);
        Assert.Equal(2, node1.NodeValue);
    }

    [Fact]
    public void DeleteNodeOneLevel()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTree<int> tree = new SimpleTree<int>(node);
        // Assert.Equal(1, tree.Count());
        Assert.Equal(node, tree.Root);

        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, null);
        tree.AddChild(node, node1);
        // Assert.Equal(2, tree.Count());

        Assert.Equal(node.Children[0], node1);

        tree.DeleteNode(node1);
        // Assert.Equal(1, tree.Count());
        Assert.Equal(node, tree.Root);
        Assert.Equal(null, node.Children);

        tree.DeleteNode(node);
        // Assert.Equal(0, tree.Count());
        Assert.Null(tree.Root);
    }

    [Fact]
    public void DeleteNodeSecondLevel()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, node);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(3, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(4, node2);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(5, node3);

        SimpleTree<int> tree = new SimpleTree<int>(node);

        tree.DeleteNode(node4);
        Assert.Equal(null, node3.Children);

        tree.DeleteNode(node3);
        Assert.Equal(null, node2.Children);

        tree.DeleteNode(node2);
        Assert.Equal(null, node1.Children);

        Assert.Equal(2, node1.NodeValue);
        Assert.Equal(node1.Parent, node);
    }

    [Fact]
    public void DeleteNodeOSecondLevel_WITH_ADD()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(3, node1);
        SimpleTree<int> tree = new SimpleTree<int>(node);

        tree.AddChild(node, node1);
        tree.AddChild(node1, node2);

        Assert.Equal(node, tree.Root);
        Assert.Equal(node.Children[0], node1);
        Assert.Equal(node1.Children[0], node2);
        Assert.Equal(node2.Children, null);

        tree.DeleteNode(node1);

        Assert.Equal(node, tree.Root);
        Assert.Equal(null, node.Children);

        tree.DeleteNode(node);
        Assert.Null(tree.Root);
    }

    [Fact]
    public void GetAllNodes_RootNull()
    {
        SimpleTree<int> tree = new SimpleTree<int>(null);

        Assert.Equal(null, tree.GetAllNodes());
    }

    [Fact]
    public void GetAllNodes_withOneNode()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTree<int> tree = new SimpleTree<int>(node);

        Assert.Equal(node, tree.GetAllNodes()[0]);
    }

    [Fact]
    public void GetAllNodes_withTwoNode()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, node);
        SimpleTree<int> tree = new SimpleTree<int>(node);

        Assert.Equal(node, tree.GetAllNodes()[0]);
        Assert.Equal(node1, tree.GetAllNodes()[1]);
    }

    [Fact]
    public void GetAllNodes_TwoNodeWith()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, null);
        SimpleTree<int> tree = new SimpleTree<int>(node);
        tree.AddChild(node, node1);
        Assert.Equal(node, tree.GetAllNodes()[0]);
        Assert.Equal(node1, tree.GetAllNodes()[1]);
    }

    [Fact]
    public void GetAllNodes()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(2, node);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(3, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(4, node2);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(5, node3);

        SimpleTree<int> tree = new SimpleTree<int>(node);

        Assert.Equal(node, tree.GetAllNodes()[0]);
        Assert.Equal(node1, tree.GetAllNodes()[1]);
        Assert.Equal(node2, tree.GetAllNodes()[2]);
        Assert.Equal(node3, tree.GetAllNodes()[3]);
        Assert.Equal(node4, tree.GetAllNodes()[4]);
    }

    [Fact]
    public void FindNodesByValue()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, node);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(1, node1);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(1, node2);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(1, node3);

        SimpleTree<int> tree = new SimpleTree<int>(node);

        Assert.Equal(node, tree.FindNodesByValue(1)[0]);
        Assert.Equal(node1, tree.FindNodesByValue(1)[1]);
        Assert.Equal(node2, tree.FindNodesByValue(1)[2]);
        Assert.Equal(node3, tree.FindNodesByValue(1)[3]);
        Assert.Equal(node4, tree.FindNodesByValue(1)[4]);
    }

    [Fact]
    public void FindNodesByValueWithAdd()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node1 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(1, null);
        SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(1, null);

        SimpleTree<int> tree = new SimpleTree<int>(node);
        tree.AddChild(node, node1);
        tree.AddChild(node1, node2);
        tree.AddChild(node2, node3);
        tree.AddChild(node3, node4);

        Assert.Equal(node, tree.FindNodesByValue(1)[0]);
        Assert.Equal(node1, tree.FindNodesByValue(1)[1]);
        Assert.Equal(node2, tree.FindNodesByValue(1)[2]);
        Assert.Equal(node3, tree.FindNodesByValue(1)[3]);
        Assert.Equal(node4, tree.FindNodesByValue(1)[4]);
    }

    [Fact]
    public void MoveNode()
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

        tree.MoveNode(node3, node1);

        Assert.Equal(node, tree.GetAllNodes()[0]);
        Assert.Equal(node1, tree.GetAllNodes()[1]);
        Assert.Equal(node3, tree.GetAllNodes()[3]);
        Assert.Equal(node4, tree.GetAllNodes()[4]);
    }

    [Fact]
    public void Count()
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


        Assert.Equal(5, tree.Count());
    }

    [Fact]
    public void LeafCount()
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


        Assert.Equal(1, tree.LeafCount());
    }

    [Fact]
    public void LeafCounByOneNode()
    {
        SimpleTreeNode<int> node = new SimpleTreeNode<int>(1, null);

        SimpleTree<int> tree = new SimpleTree<int>(node);

        Assert.Equal(1, tree.LeafCount());
    }
}