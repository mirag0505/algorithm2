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
    public void Test4()
    {
        int[] inputArray = { 1, 2, 3, 4, 5, 6, 7 };
        int[] array = BalancedBST.GenerateBBSTArray(inputArray);
        Assert.Equal("4,2,6,1,3,5,7", string.Join(",", array));
    }

    [Fact]
    public void Test3()
    {
        int[] inputArray = { 5, 2, 3, 4, 1, 0 };
        int[] array = BalancedBST.GenerateBBSTArray(inputArray);
        Assert.Equal("50,25,37,62,75", string.Join(",", array));
    }
}