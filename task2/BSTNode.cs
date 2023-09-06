namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;
        // когда его заполнять? когда нету искомого, и нужно показать родителя,
        // которму будет добавлен ребенок в левое или правое?

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTNode<T> GetRoot()
        {
            return Root;
        }
        public BSTFind<T> NodeIterator(BSTNode<T> node, int key, BSTFind<T> result)
        {
            BSTNode<T> current = node;

            if (key == current.NodeKey)
            {
                result.Node = current;
                result.NodeHasKey = true;
                return result;
            }
            else if (key < current.NodeKey)
            {
                if (current.LeftChild == null)
                {
                    result.Node = current;
                    result.ToLeft = true;
                    return result;
                }
                current = current.LeftChild;
            }
            else
            {
                if (current.RightChild == null)
                {
                    result.Node = current;
                    result.ToLeft = false;
                    return result;
                }
                current = current.RightChild;
            }

            if (current != null) return NodeIterator(current, key, result);
            return null;
        }
        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> result = new BSTFind<T>();
            if (Root != null) return NodeIterator(Root, key, result);
            return null;
        }

        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> findResult = FindNodeByKey(key);
            if (findResult.NodeHasKey) return false;
            BSTNode<T> newNode = new BSTNode<T>(key, val, findResult.Node);
            if (findResult.ToLeft)
                findResult.Node.LeftChild = newNode;
            else
                findResult.Node.RightChild = newNode;
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальный/минимальный ключ в поддереве
            if (!FindMax && FromNode.LeftChild == null)
            {
                return FromNode;
            }
            if (!FindMax)
            {
                return FinMinMax(FromNode.LeftChild, FindMax);
            }
            if (FindMax && FromNode.RightChild == null)
            {
                return FromNode;
            }
            return FinMinMax(FromNode.RightChild, FindMax);
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу

            BSTFind<T> findResult = FindNodeByKey(key);
            if (!findResult.NodeHasKey) return false;
            BSTNode<T> nodeToDelete = findResult.Node;
            if (nodeToDelete.LeftChild == null && nodeToDelete.RightChild == null)
            {
                if (nodeToDelete.Parent.LeftChild == nodeToDelete) nodeToDelete.Parent.LeftChild = null;
                else nodeToDelete.Parent.RightChild = null;
            }
            else if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
            {
                BSTNode<T> successor = FinMinMax(nodeToDelete.RightChild, false);
                nodeToDelete.NodeKey = successor.NodeKey;
                nodeToDelete.NodeValue = successor.NodeValue;

                if (successor.Parent.LeftChild == successor) successor.Parent.LeftChild = successor.RightChild;
                else successor.Parent.RightChild = successor.RightChild;
            }
            else
            {
                BSTNode<T> child;
                if (nodeToDelete.LeftChild != null) child = nodeToDelete.RightChild;
                if (nodeToDelete.Parent != null)
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                        nodeToDelete.Parent.LeftChild = null;
                    else
                        nodeToDelete.Parent.RightChild = null;
                }
            }
            return true;

        }

        public int Count()
        {
            return CountNodes(Root);
        }

        private int CountNodes(BSTNode<T> node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.LeftChild) + CountNodes(node.RightChild);
        }
    }
}