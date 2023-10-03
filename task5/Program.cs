namespace AlgorithmsDataStructures2;
class Program
{
    static void Main(string[] args)
    {
        var tree = new BalancedBST();
        int[] inputArray = { 1, 2, 3, 4, 5, 6, 7 };
        tree.GenerateTree(inputArray);

        tree.IsBalanced(tree.Root);
    }
}