namespace AlgorithmsDataStructures2;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var heap = new Heap();
        int[] inputArray = { 75, 25, 50 };

        heap.MakeHeap(inputArray, 2);

        heap.GetMax();

        heap.Add(75);
    }
}