namespace AlgorithmsDataStructures2;
class Program
{
    static void Main(string[] args)
    {
        var heap = new Heap();

        int[] inputArray = { 3, 2, 4 };
        heap.MakeHeap(inputArray, 2);
        heap.GetMax();
        heap.Add(9);
    }
}