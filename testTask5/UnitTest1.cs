namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var tree = new BalancedBST();
        int[] inputArray = { 75, 25, 50 };
        tree.GenerateTree(inputArray);

        Assert.Equal(null, tree.Root.Parent);
        Assert.Equal(50, tree.Root.NodeKey);
        Assert.Equal(25, tree.Root.LeftChild.NodeKey);
        Assert.Equal(75, tree.Root.RightChild.NodeKey);
    }

    [Fact]
    public void Test2()
    {
        var tree = new BalancedBST();
        int[] inputArray = { 1, 2, 3, 4, 5, 6, 7 };
        tree.GenerateTree(inputArray);

        Assert.Equal(4, tree.Root.NodeKey);
        Assert.Equal(0, tree.Root.Level);

        Assert.Equal(2, tree.Root.LeftChild.NodeKey);
        Assert.Equal(1, tree.Root.LeftChild.Level);

        Assert.Equal(1, tree.Root.LeftChild.LeftChild.NodeKey);
        Assert.Equal(3, tree.Root.LeftChild.RightChild.NodeKey);

        Assert.Equal(2, tree.Root.LeftChild.LeftChild.Level);
        Assert.Equal(2, tree.Root.LeftChild.RightChild.Level);

        Assert.Equal(6, tree.Root.RightChild.NodeKey);
        Assert.Equal(1, tree.Root.RightChild.Level);

        Assert.Equal(5, tree.Root.RightChild.LeftChild.NodeKey);
        Assert.Equal(7, tree.Root.RightChild.RightChild.NodeKey);

        Assert.Equal(2, tree.Root.RightChild.LeftChild.Level);
        Assert.Equal(2, tree.Root.RightChild.RightChild.Level);
        // 4,2,6,1,3,5,7
    }

    [Fact]
    public void Test3()
    {
        var tree = new BalancedBST();
        int[] inputArray = { 1, 2, 3, 4, 5, 6, 7 };
        tree.GenerateTree(inputArray);

        Assert.True(tree.IsBalanced(tree.Root));
    }

}