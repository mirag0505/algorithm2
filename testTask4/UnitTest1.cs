namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int[] inputArray = { 75, 25, 50 };
        int[] array = BalancedBST.GenerateBBSTArray(inputArray);
        Assert.Equal("50,25,75", string.Join(",", array));
    }

    [Fact]
    public void Test2()
    {
        int[] inputArray = { 3, 4, 2, 1, 5 };
        int[] array = BalancedBST.GenerateBBSTArray(inputArray);
        Assert.Equal("3,1,2,4,5", string.Join(",", array));
    }

    [Fact]
    public void Test3()
    {
        int[] inputArray = { 5, 2, 3, 4, 1, 0 };
        int[] array = BalancedBST.GenerateBBSTArray(inputArray);
        Assert.Equal("50,25,37,62,75", string.Join(",", array));
    }
}