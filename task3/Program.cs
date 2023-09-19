
namespace AlgorithmsDataStructures2;
class Program
{
    static void Main(string[] args)
    {
        aBST tree = new aBST(3);
        tree.AddKey(50);
        tree.AddKey(25);
        tree.AddKey(75);
        tree.AddKey(37);
        tree.AddKey(62);
        tree.AddKey(84);

        var lol = tree;
    }
}