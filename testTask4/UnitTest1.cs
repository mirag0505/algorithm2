namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int[] inputArray = { 75, 50, 25 };
        int[] array = AlgorithmsDataStructures2.BalancedBST.GenerateBBSTArray(inputArray);
        Assert.Equal("50,25,75", string.Join(",", array));
    }
}