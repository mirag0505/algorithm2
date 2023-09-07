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
    public void TestCount()
    {
        BSTNode<int> root = new BSTNode<int>(10, 0, null);
        BST<int> tree = new BST<int>(root);
        tree.AddKeyValue(5, 1);
        tree.AddKeyValue(15, 2);

        Assert.Equal(3, tree.Count());
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
    public void TestDeleteNodeByKey1()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        var treeRoot = tree.GetRoot();
        Assert.Equal(4, treeRoot.NodeKey);

        var firstLeft = treeRoot.LeftChild;
        Assert.Equal(2, firstLeft.NodeKey);

        var leftSecondLeft = firstLeft.LeftChild;
        Assert.Equal(1, leftSecondLeft.NodeKey);
        var leftSecondRight = firstLeft.RightChild;
        Assert.Equal(3, leftSecondRight.NodeKey);

        var firstRight = treeRoot.RightChild;
        Assert.Equal(6, firstRight.NodeKey);

        var rightSecondLeft = firstRight.LeftChild;
        Assert.Equal(5, rightSecondLeft.NodeKey);
        var rightSecondRight = firstRight.RightChild;
        Assert.Equal(7, rightSecondRight.NodeKey);

        Assert.True(tree.DeleteNodeByKey(2));
        Assert.False(tree.DeleteNodeByKey(10));

        var treeRootNew = tree.GetRoot();
        Assert.Equal(4, treeRootNew.NodeKey);

        var firstLeftNew = treeRootNew.LeftChild;
        Assert.Equal(1, firstLeftNew.NodeKey);
        var leftSecondLeftNew = firstLeftNew.LeftChild;
        Assert.Equal(null, leftSecondLeftNew);

        var leftSecondRightNew = firstLeftNew.RightChild;
        Assert.Equal(3, leftSecondRightNew.NodeKey);


        var firstRightNew = treeRootNew.RightChild;
        Assert.Equal(6, firstRightNew.NodeKey);
        var rightSecondLeftNew = firstRightNew.LeftChild;
        Assert.Equal(5, rightSecondLeftNew.NodeKey);
        var rightSecondRightNew = firstRightNew.RightChild;
        Assert.Equal(7, rightSecondRightNew.NodeKey);
    }

    [Fact]
    public void TestDeleteNodeByKey2()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.True(tree.DeleteNodeByKey(1));
        Assert.False(tree.DeleteNodeByKey(10));
    }

    [Fact]
    public void TestDeleteNodeByKey3()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.True(tree.DeleteNodeByKey(3));
        Assert.False(tree.DeleteNodeByKey(10));
    }

    [Fact]
    public void TestDeleteNodeByKey4()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.True(tree.DeleteNodeByKey(6));
        Assert.False(tree.DeleteNodeByKey(10));
    }

    [Fact]
    public void TestDeleteNodeByKey5()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.True(tree.DeleteNodeByKey(5));
        Assert.False(tree.DeleteNodeByKey(10));
    }

    [Fact]
    public void TestDeleteNodeByKey7()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.True(tree.DeleteNodeByKey(7));
        Assert.False(tree.DeleteNodeByKey(10));
    }

    [Fact]
    public void TestDeleteNodeByKey8()
    {
        BSTNode<int> root = new BSTNode<int>(4, 4, null);
        BST<int> tree = new BST<int>(root);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.True(tree.DeleteNodeByKey(4));
        Assert.False(tree.DeleteNodeByKey(10));
    }
}