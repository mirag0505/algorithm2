namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void TestaBST()
    {
        aBST tree = new aBST(3);
        Assert.Equal(15, tree.Count());

        aBST tree1 = new aBST(2);
        Assert.Equal(7, tree1.Count());
    }

    [Fact]
    public void TestFindaBST()
    {
        aBST tree = new aBST(3);
        var empty1 = tree.FindKeyIndex(1);
        var empty2 = tree.FindKeyIndex(3);
        var empty3 = tree.FindKeyIndex(-3);
        Assert.Equal(0, empty1);
        Assert.Equal(0, empty2);
        Assert.Equal(0, empty3);
    }

    [Fact]
    public void TestAddNodes()
    {
        aBST tree = new aBST(2);
        tree.AddKey(50);
        tree.AddKey(25);
        tree.AddKey(75);
        tree.AddKey(37);
        tree.AddKey(62);
        tree.AddKey(84);
        Assert.Equal("50,25,75,,37,62,84", tree.getTreeString());
    }

    [Fact]
    public void TestFind()
    {
        aBST tree = new aBST(2);
        tree.AddKey(50);
        tree.AddKey(25);
        tree.AddKey(75);
        tree.AddKey(37);
        tree.AddKey(62);
        tree.AddKey(84);
        Assert.Equal(0, tree.FindKeyIndex(50));
        Assert.Equal(1, tree.FindKeyIndex(25));
        Assert.Equal(2, tree.FindKeyIndex(75));
        Assert.Equal(4, tree.FindKeyIndex(37));
        Assert.Equal(5, tree.FindKeyIndex(62));
        Assert.Equal(6, tree.FindKeyIndex(84));
    }
}