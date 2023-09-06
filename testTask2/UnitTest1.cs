using System.Diagnostics;
namespace AlgorithmsDataStructures2;
// namespace testTask2;

public class UnitTest1
{
    [Fact]
    public void TestFindNodeByKey()
    {
        BSTNode<int> root = new BSTNode<int>(10, 0, null);
        BST<int> tree = new BST<int>(root);
        tree.AddKeyValue(5, 1);
        tree.AddKeyValue(15, 2);

        var findResult1 = tree.FindNodeByKey(5);
        Assert.True(findResult1.NodeHasKey);
        Assert.Equal(5, findResult1.Node.NodeKey);

        var findResult2 = tree.FindNodeByKey(20);
        Assert.False(findResult2.NodeHasKey);
        Assert.Equal(15, findResult2.Node.NodeKey);
    }

    [Fact]
    public void TestAddKeyValue()
    {
        BSTNode<int> root = new BSTNode<int>(10, 0, null);
        BST<int> tree = new BST<int>(root);

        Assert.True(tree.AddKeyValue(5, 1));
        Assert.False(tree.AddKeyValue(10, 2));
        Assert.True(tree.AddKeyValue(15, 3));
    }

    [Fact]
    public void TestFinMinMax()
    {
        BSTNode<int> root = new BSTNode<int>(10, 0, null);
        BST<int> tree = new BST<int>(root);
        tree.AddKeyValue(5, 1);
        tree.AddKeyValue(15, 2);

        var minNode = tree.FinMinMax(root, false);
        Assert.Equal(5, minNode.NodeKey);

        var maxNode = tree.FinMinMax(root, true);
        Assert.Equal(15, maxNode.NodeKey);
    }

    [Fact]
    public void TestDeleteNodeByKey()
    {
        BSTNode<int> root = new BSTNode<int>(10, 0, null);
        BST<int> tree = new BST<int>(root);
        tree.AddKeyValue(5, 1);
        tree.AddKeyValue(15, 2);

        Assert.True(tree.DeleteNodeByKey(5));
        Assert.False(tree.DeleteNodeByKey(20));
        Assert.True(tree.DeleteNodeByKey(10));
    }

    [Fact]
    public void TestCount()
    {
        BSTNode<int> root = new BSTNode<int>(10, 0, null);
        BST<int> tree = new BST<int>(root);
        tree.AddKeyValue(5, 1);
        tree.AddKeyValue(15, 2);

        Assert.Equal(3, tree.Count());
    }
}