using System.Diagnostics;
namespace AlgorithmsDataStructures2;
// namespace testTask2;

public class UnitTest1
{
    [Fact]
    public void CreateNode()
    {
        BSTNode<int> node1 = new BSTNode<int>(0, 0, null);

        Assert.Equal(0, node1.NodeKey);
        Assert.Equal(0, node1.NodeValue);
        Assert.Equal(null, node1.Parent);
    }

    [Fact]
    public void CreateTreeWithoutNode()
    {
        BST<int> tree = new BST<int>(null);
        Assert.Equal(null, tree.GetRoot());
    }

    [Fact]
    public void CreateTreeWithNode()
    {
        BSTNode<int> node1 = new BSTNode<int>(0, 0, null);
        BST<int> tree = new BST<int>(node1);
        Assert.Equal(node1, tree.GetRoot());
    }

    // [Fact]
    // public void AddKeyValue_AddToEmptyRoot()
    // {
    //     BSTNode<int> node1 = new BSTNode<int>(0, 0, null);
    //     BST<int> tree = new BST<int>(null);

    //     tree.AddKeyValue(node1);
    //     Assert.Equal(node1, tree.GetRoot());
    // }

    [Fact]
    public void FindNodeByKey()
    {
        BSTNode<int> node1 = new BSTNode<int>(2, 2, null);
        BSTNode<int> node2 = new BSTNode<int>(1, 1, node1);
        BSTNode<int> node3 = new BSTNode<int>(3, 3, node1);
        node1.LeftChild = node2;
        node1.RightChild = node3;

        BST<int> tree = new BST<int>(node1);

        BSTFind<int> intermediate = tree.FindNodeByKey(2);
        Assert.Equal(node1, tree.GetRoot());
        Assert.Equal(node1, intermediate.Node);
        Assert.Equal(true, intermediate.NodeHasKey);
        Assert.Equal(false, intermediate.ToLeft);

        BSTFind<int> intermediate1 = tree.FindNodeByKey(1);
        Assert.Equal(node2, intermediate1.Node);
        Assert.Equal(true, intermediate1.NodeHasKey);
        Assert.Equal(false, intermediate1.ToLeft);

        BSTFind<int> intermediate2 = tree.FindNodeByKey(3);
        Assert.Equal(node3, intermediate2.Node);
        Assert.Equal(true, intermediate2.NodeHasKey);
        Assert.Equal(false, intermediate2.ToLeft);
    }

    // TODO создать ветвь, где при дети указывают на родителя, а РОДИТЕЛЬ НЕТ!!
    // добавить автоматическое добавление?

    [Fact]
    public void FindNodeByKeyWithoutRoot()
    {
        BST<int> tree = new BST<int>(null);

        BSTFind<int> intermediate = tree.FindNodeByKey(2);
        Assert.Equal(null, tree.GetRoot());
        Assert.Equal(null, intermediate.Node);
        Assert.Equal(false, intermediate.NodeHasKey);
        Assert.Equal(false, intermediate.ToLeft);
    }

    [Fact]
    public void FindNodeByKeyWithOnlyRootWithoutChildren()
    {
        BSTNode<int> node1 = new BSTNode<int>(1, 1, null);
        BST<int> tree = new BST<int>(node1);

        BSTFind<int> intermediate = tree.FindNodeByKey(2);
        Assert.Equal(node1, tree.GetRoot());
        Assert.Equal(node1, intermediate.Node);
        Assert.Equal(false, intermediate.NodeHasKey);
        Assert.Equal(false, intermediate.ToLeft);
    }

    [Fact]
    public void FindNodeByKeyWithoutFinded()
    {
        BSTNode<int> node1 = new BSTNode<int>(2, 2, null);
        BSTNode<int> node2 = new BSTNode<int>(1, 1, node1);
        BSTNode<int> node3 = new BSTNode<int>(3, 3, node1);
        node1.LeftChild = node2;
        node1.RightChild = node3;

        BST<int> tree = new BST<int>(node1);

        BSTFind<int> intermediate = tree.FindNodeByKey(2);
        Assert.Equal(node1, tree.GetRoot());
        Assert.Equal(node1, intermediate.Node);
        Assert.Equal(true, intermediate.NodeHasKey);
        Assert.Equal(false, intermediate.ToLeft);

        BSTFind<int> intermediate1 = tree.FindNodeByKey(1);
        Assert.Equal(node2, intermediate1.Node);
        Assert.Equal(true, intermediate1.NodeHasKey);
        Assert.Equal(false, intermediate1.ToLeft);

        BSTFind<int> intermediate2 = tree.FindNodeByKey(3);
        Assert.Equal(node3, intermediate2.Node);
        Assert.Equal(true, intermediate2.NodeHasKey);
        Assert.Equal(false, intermediate2.ToLeft);
    }

    [Fact]
    public void CountTest()
    {
        BSTNode<int> node1 = new BSTNode<int>(2, 2, null);
        BSTNode<int> node2 = new BSTNode<int>(1, 1, node1);
        BSTNode<int> node3 = new BSTNode<int>(3, 3, node1);
        node1.LeftChild = node2;
        node1.RightChild = node3;

        BST<int> tree = new BST<int>(node1);
        Assert.Equal(3, tree.Count());
    }

    [Fact]
    public void CountTestWithAdd()
    {
        BSTNode<int> node1 = new BSTNode<int>(2, 2, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        Assert.Equal(3, tree.Count());
    }

    [Fact]
    public void AddKeyValue()
    {
        BSTNode<int> node1 = new BSTNode<int>(2, 2, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        Assert.Equal(3, tree.Count());

        Assert.Equal(2, tree.GetRoot().NodeValue);
        Assert.Equal(2, tree.GetRoot().NodeKey);

        Assert.Equal(1, tree.GetRoot().LeftChild.NodeValue);
        Assert.Equal(1, tree.GetRoot().LeftChild.NodeKey);

        Assert.Equal(3, tree.GetRoot().RightChild.NodeValue);
        Assert.Equal(3, tree.GetRoot().RightChild.NodeKey);
    }


    [Fact]
    public void Add7KeyValue()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(6, 6);

        Assert.Equal(3, tree.Count());

        Assert.Equal(4, tree.GetRoot().NodeValue);
        Assert.Equal(4, tree.GetRoot().NodeKey);

        Assert.Equal(2, tree.GetRoot().LeftChild.NodeValue);
        Assert.Equal(2, tree.GetRoot().LeftChild.NodeKey);

        Assert.Equal(6, tree.GetRoot().RightChild.NodeValue);
        Assert.Equal(6, tree.GetRoot().RightChild.NodeKey);

        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.Equal(1, tree.GetRoot().LeftChild.LeftChild.NodeValue);
        Assert.Equal(1, tree.GetRoot().LeftChild.LeftChild.NodeKey);

        Assert.Equal(3, tree.GetRoot().LeftChild.RightChild.NodeValue);
        Assert.Equal(3, tree.GetRoot().LeftChild.RightChild.NodeKey);

        Assert.Equal(5, tree.GetRoot().RightChild.LeftChild.NodeValue);
        Assert.Equal(5, tree.GetRoot().RightChild.LeftChild.NodeKey);

        Assert.Equal(7, tree.GetRoot().RightChild.RightChild.NodeValue);
        Assert.Equal(7, tree.GetRoot().RightChild.RightChild.NodeKey);

        Assert.Equal(7, tree.Count());
    }

    [Fact]
    public void FinMinMax()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        Assert.Equal(1, tree.FinMinMax(tree.GetRoot(), false).NodeKey);
        Assert.Equal(7, tree.FinMinMax(tree.GetRoot(), true).NodeKey);
    }

    [Fact]
    public void DeleteNodeByKeyOnlyLeft()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(2, 2);

        Assert.Equal(true, tree.DeleteNodeByKey(2));
        Assert.Equal(1, tree.Count());
        Assert.Equal(null, tree.GetRoot().LeftChild);
    }

    [Fact]
    public void DeleteNodeByKeyOnlyRight()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(6, 6);

        Assert.Equal(true, tree.DeleteNodeByKey(6));
        Assert.Equal(node1, tree.GetRoot());
        Assert.Equal(null, tree.GetRoot().RightChild);
        Assert.Equal(1, tree.Count());
    }

    [Fact]
    public void DeleteNodeByKeyOnlyRighButWithTwoChild()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(9, 9);

        Assert.Equal(true, tree.DeleteNodeByKey(6));
        Assert.Equal(node1, tree.GetRoot());
        Assert.Equal(9, tree.GetRoot().RightChild.NodeKey);
        Assert.Equal(2, tree.Count());
    }

    [Fact]
    public void DeleteNodeByKeyOnlyRighButWithTwoChildAndDeleteTHeLAst()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(9, 9);

        Assert.Equal(true, tree.DeleteNodeByKey(9));
        Assert.Equal(node1, tree.GetRoot());
        Assert.Equal(6, tree.GetRoot().RightChild.NodeKey);
        Assert.Equal(2, tree.Count());
    }

    [Fact]
    public void DeleteNodeByKeyWithoutFindedValue()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);

        Assert.Equal(false, tree.DeleteNodeByKey(22));
    }


    [Fact]
    public void DeleteNodeByKeyLeftAndRightWhenLeftDelete()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        Assert.Equal(true, tree.DeleteNodeByKey(2));
        Assert.Equal(3, tree.GetRoot().LeftChild.NodeKey);
    }

    [Fact]
    public void DeleteNodeByKeyLeftAndRightWhenRightDelete()
    {
        BSTNode<int> node1 = new BSTNode<int>(4, 4, null);

        BST<int> tree = new BST<int>(node1);
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);

        Assert.Equal(true, tree.DeleteNodeByKey(6));
        Assert.Equal(2, tree.GetRoot().LeftChild.NodeKey);
        Assert.Equal(6, tree.Count());
    }

    [Fact]
    public void DeleteNodeByKey1()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.DeleteNodeByKey(1);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(4, 4, null));
        bstreeCompareObj.AddKeyValue(6, 6);
        bstreeCompareObj.AddKeyValue(5, 5);
        bstreeCompareObj.AddKeyValue(7, 7);

        bstreeCompareObj.AddKeyValue(2, 2);
        bstreeCompareObj.AddKeyValue(3, 3);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }

    [Fact]
    public void DeleteNodeByKey2()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.DeleteNodeByKey(3);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(4, 4, null));
        bstreeCompareObj.AddKeyValue(6, 6);
        bstreeCompareObj.AddKeyValue(5, 5);
        bstreeCompareObj.AddKeyValue(7, 7);

        bstreeCompareObj.AddKeyValue(2, 2);
        bstreeCompareObj.AddKeyValue(1, 1);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }

    public void DeleteNodeByKey3()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.DeleteNodeByKey(2);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(4, 4, null));
        bstreeCompareObj.AddKeyValue(6, 6);
        bstreeCompareObj.AddKeyValue(5, 5);
        bstreeCompareObj.AddKeyValue(7, 7);

        bstreeCompareObj.AddKeyValue(1, 1);
        bstreeCompareObj.AddKeyValue(3, 3);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }

    public void DeleteNodeByKey4()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.DeleteNodeByKey(6);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(4, 4, null));
        bstreeCompareObj.AddKeyValue(5, 5);
        bstreeCompareObj.AddKeyValue(7, 7);

        bstreeCompareObj.AddKeyValue(1, 1);
        bstreeCompareObj.AddKeyValue(3, 3);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }

    public void DeleteNodeByKey7()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.DeleteNodeByKey(7);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(4, 4, null));
        bstreeCompareObj.AddKeyValue(6, 6);
        bstreeCompareObj.AddKeyValue(5, 5);

        bstreeCompareObj.AddKeyValue(2, 2);
        bstreeCompareObj.AddKeyValue(1, 1);
        bstreeCompareObj.AddKeyValue(3, 3);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }

    public void DeleteNodeByKey8()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(4, 4, null));
        tree.AddKeyValue(6, 6);
        tree.AddKeyValue(5, 5);
        tree.AddKeyValue(7, 7);

        tree.AddKeyValue(2, 2);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(3, 3);
        tree.DeleteNodeByKey(5);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(4, 4, null));
        bstreeCompareObj.AddKeyValue(6, 6);
        bstreeCompareObj.AddKeyValue(7, 7);

        bstreeCompareObj.AddKeyValue(2, 2);
        bstreeCompareObj.AddKeyValue(1, 1);
        bstreeCompareObj.AddKeyValue(3, 3);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }

    [Fact]
    public void DeleteNodeByKey()
    {
        BST<int> tree = new BST<int>(new BSTNode<int>(100, 100, null));
        tree.AddKeyValue(10, 10);
        tree.AddKeyValue(11, 11);
        tree.AddKeyValue(12, 12);
        tree.AddKeyValue(110, 110);
        tree.AddKeyValue(112, 112);
        tree.AddKeyValue(115, 115);
        tree.AddKeyValue(111, 111);
        tree.AddKeyValue(1, 1);
        tree.AddKeyValue(109, 109);
        tree.DeleteNodeByKey(1);

        BST<int> bstreeCompareObj = new BST<int>(new BSTNode<int>(100, 100, null));
        bstreeCompareObj.AddKeyValue(10, 10);
        bstreeCompareObj.AddKeyValue(11, 11);
        bstreeCompareObj.AddKeyValue(12, 12);
        bstreeCompareObj.AddKeyValue(110, 110);
        bstreeCompareObj.AddKeyValue(112, 112);
        bstreeCompareObj.AddKeyValue(115, 115);
        bstreeCompareObj.AddKeyValue(111, 111);
        bstreeCompareObj.AddKeyValue(109, 109);

        List<BSTNode<int>> bstreeObjList = new List<BSTNode<int>>();
        bstreeObjList = tree.GetAllNodes(tree.GetRoot());

        List<BSTNode<int>> bstreeCompareObjList = new List<BSTNode<int>>();
        bstreeCompareObjList = bstreeCompareObj.GetAllNodes(bstreeCompareObj.GetRoot());

        Assert.Equal(bstreeCompareObj.Count(), tree.Count());

        int index = 0;
        foreach (var element in bstreeCompareObjList)
        {
            Assert.Equal(element.NodeValue, bstreeObjList[index].NodeValue);
            Assert.Equal(element.NodeKey, bstreeObjList[index].NodeKey);
            index++;
        }
    }
}