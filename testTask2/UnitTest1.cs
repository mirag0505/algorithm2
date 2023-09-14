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

    [Fact]
    public void WideAllNodes_EmptyTree_ShouldReturnEmptyList()
    {
        var tree = new BST<int>(null);
        var res = tree.WideAllNodes();

        AssertList(res, 0, new List<int>());
    }

    [Fact]
    public void WideAllNodes_OnlyRoot_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(1, 1, null));
        var res = tree.WideAllNodes();

        AssertList(res, 1, new List<int> { 1 });
    }

    [Fact]
    public void WideAllNodes_OnlyRootAndLeft_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);

        var res = tree.WideAllNodes();
        AssertList(res, 2, new List<int> { 2, 1 });
    }

    [Fact]
    public void WideAllNodes_OnlyRootAndLeftRight_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        var res = tree.WideAllNodes();

        AssertList(res, 3, new List<int> { 2, 1, 3 });
    }

    [Fact]
    public void WideAllNodes_FourElementsLeftSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        var res = tree.WideAllNodes();

        AssertList(res, 4, new List<int> { 4, 2, 1, 3 });
    }

    [Fact]
    public void WideAllNodes_FourElementsRightSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(1, 1, null));
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);

        var res = tree.WideAllNodes();

        AssertList(res, 4, new List<int> { 1, 3, 2, 4 });
    }

    [Fact]
    public void WideAllNodes_FourElementsLeftRightSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(4, 4);

        var res = tree.WideAllNodes();

        AssertList(res, 4, new List<int> { 2, 1, 3, 4 });
    }

    [Fact]
    public void WideAllNodes_FiveElementsLeftSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(0, 0);

        var res = tree.WideAllNodes();

        AssertList(res, 5, new List<int> { 4, 2, 1, 3, 0 });
    }

    [Fact]
    public void WideAllNodes_FiveElementsRightSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);

        var res = tree.WideAllNodes();

        AssertList(res, 5, new List<int> { 8, 4, 12, 13, 14 });
    }

    [Fact]
    public void WideAllNodes_SixElementsLeftRightSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);

        var res = tree.WideAllNodes();

        AssertList(res, 6, new List<int> { 8, 4, 12, 2, 13, 14 });
    }

    [Fact]
    public void WideAllNodes_SevenElementsLeftRightSubtree_ShouldBeCorrect()
    {
        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);

        var res = tree.WideAllNodes();

        AssertList(res, 7, new List<int> { 8, 4, 12, 2, 6, 13, 14 });
    }

    [Fact]
    public void WideAllNodes_BigTreeLeftRightSubtree_ShouldBeCorrect()
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

        var res = tree.WideAllNodes();

        AssertList(res, 11, new List<int> { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7 });
    }

    static void AssertList<T>(List<BSTNode<T>> nodes, int count, List<int> values)
    {
        Assert.Equal(count, nodes.Count);
        for (int i = 0; i < count; i++)
        {
            Assert.Equal(values[i], nodes[i].NodeKey);
        }
    }

    [Fact]
    public void DeepAllNodesInOrder_EmptyTree_ShouldReturnEmptyList()
    {

        var tree = new BST<int>(null);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 0, new List<int>());
    }

    [Fact]
    public void DeepAllNodesInOrder_OnlyRoot_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(1, 1, null));


        var res = tree.DeepAllNodes(0);


        AssertList(res, 1, new List<int> { 1 });
    }

    [Fact]
    public void DeepAllNodesInOrder_OnlyRootAndLeft_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 2, new List<int> { 1, 2 });
    }

    [Fact]
    public void DeepAllNodesInOrder_OnlyRootAndLeftRight_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 3, new List<int> { 1, 2, 3 });
    }

    [Fact]
    public void DeepAllNodesInOrder_FourElementsLeftSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 4, new List<int> { 1, 2, 3, 4 });
    }

    [Fact]
    public void DeepAllNodesInOrder_FourElementsRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(1, 1, null));
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 4, new List<int> { 1, 2, 3, 4 });
    }

    [Fact]
    public void DeepAllNodesInOrder_FourElementsLeftRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(4, 4);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 4, new List<int> { 1, 2, 3, 4 });
    }

    [Fact]
    public void DeepAllNodesInOrder_FiveElementsLeftSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(0, 0);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 5, new List<int> { 0, 1, 2, 3, 4 });
    }

    [Fact]
    public void DeepAllNodesInOrder_FiveElementsRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 5, new List<int> { 4, 8, 12, 13, 14 });
    }

    [Fact]
    public void DeepAllNodesInOrder_SixElementsLeftRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 6, new List<int> { 2, 4, 8, 12, 13, 14 });
    }

    [Fact]
    public void DeepAllNodesInOrder_SevenElementsLeftRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);


        var res = tree.DeepAllNodes(0);


        AssertList(res, 7, new List<int> { 2, 4, 6, 8, 12, 13, 14 });
    }

    [Fact]
    public void DeepAllNodesInOrder_BigTreeLeftRightSubtree_ShouldBeCorrect()
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



        var res = tree.DeepAllNodes(0);



        AssertList(res, 11, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 10, 12, 14 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_EmptyTree_ShouldReturnEmptyList()
    {

        var tree = new BST<int>(null);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 0, new List<int>());
    }

    [Fact]
    public void DeepAllNodesPostOrder_OnlyRoot_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(1, 1, null));


        var res = tree.DeepAllNodes(1);


        AssertList(res, 1, new List<int> { 1 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_OnlyRootAndLeft_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 2, new List<int> { 1, 2 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_OnlyRootAndLeftRight_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 3, new List<int> { 1, 3, 2 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_FourElementsLeftSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 4, new List<int> { 1, 3, 2, 4 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_FourElementsRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(1, 1, null));
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 4, new List<int> { 2, 4, 3, 1 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_FourElementsLeftRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(2, 2, null));
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(4, 4);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 4, new List<int> { 1, 4, 3, 2 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_FiveElementsLeftSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(0, 0);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 5, new List<int> { 0, 1, 3, 2, 4 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_FiveElementsRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 5, new List<int> { 4, 14, 13, 12, 8 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_SixElementsLeftRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 6, new List<int> { 2, 4, 14, 13, 12, 8 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_SevenElementsLeftRightSubtree_ShouldBeCorrect()
    {

        var tree = new BST<int>(new BSTNode<int>(8, 8, null));
        tree.AddKeyValue(4, 4);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(13, 13);
        tree.AddKeyValue(14, 14);


        var res = tree.DeepAllNodes(1);


        AssertList(res, 7, new List<int> { 2, 6, 4, 14, 13, 12, 8 });
    }

    [Fact]
    public void DeepAllNodesPostOrder_BigTreeLeftRightSubtree_ShouldBeCorrect()
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



        var res = tree.DeepAllNodes(1);



        AssertList(res, 11, new List<int> { 1, 3, 2, 5, 7, 6, 4, 10, 14, 12, 8 });
    }


    public partial class BSTTests
    {
        [Fact]
        public void DeepAllNodesInOrder_EmptyTree_ShouldReturnEmptyList()
        {

            var tree = new BST<int>(null);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 0, new List<int>());
        }

        [Fact]
        public void DeepAllNodesInOrder_OnlyRoot_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(1, 1, null));


            var res = tree.DeepAllNodes(0);


            AssertList(res, 1, new List<int> { 1 });
        }

        [Fact]
        public void DeepAllNodesInOrder_OnlyRootAndLeft_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 2, new List<int> { 1, 2 });
        }

        [Fact]
        public void DeepAllNodesInOrder_OnlyRootAndLeftRight_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 3, new List<int> { 1, 2, 3 });
        }

        [Fact]
        public void DeepAllNodesInOrder_FourElementsLeftSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(4, 4, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 4, new List<int> { 1, 2, 3, 4 });
        }

        [Fact]
        public void DeepAllNodesInOrder_FourElementsRightSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(1, 1, null));
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 4, new List<int> { 1, 2, 3, 4 });
        }

        [Fact]
        public void DeepAllNodesInOrder_FourElementsLeftRightSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 4, new List<int> { 1, 2, 3, 4 });
        }

        [Fact]
        public void DeepAllNodesInOrder_FiveElementsLeftSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(4, 4, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(0, 0);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 5, new List<int> { 0, 1, 2, 3, 4 });
        }

        [Fact]
        public void DeepAllNodesInOrder_FiveElementsRightSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 5, new List<int> { 4, 8, 12, 13, 14 });
        }

        [Fact]
        public void DeepAllNodesInOrder_SixElementsLeftRightSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 6, new List<int> { 2, 4, 8, 12, 13, 14 });
        }

        [Fact]
        public void DeepAllNodesInOrder_SevenElementsLeftRightSubtree_ShouldBeCorrect()
        {

            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);


            var res = tree.DeepAllNodes(0);


            AssertList(res, 7, new List<int> { 2, 4, 6, 8, 12, 13, 14 });
        }

        [Fact]
        public void DeepAllNodesInOrder_BigTreeLeftRightSubtree_ShouldBeCorrect()
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

            var res = tree.DeepAllNodes(0);

            AssertList(res, 11, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 10, 12, 14 });
        }
    }
}