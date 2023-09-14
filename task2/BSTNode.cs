namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTNode<T> : BSTNode
    {
        public T NodeValue;

        public BSTNode(int key, T val, BSTNode<T> parent) : base(key, parent)
        {
            NodeValue = val;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;
        // true если узел найден
        public bool NodeHasKey;
        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind(BSTNode<T> node)
        {
            Node = node;
            NodeHasKey = false;
            ToLeft = false;
        }
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
        public BSTFind<T> NodeIterator(int key, BSTFind<T> intermediate)
        {
            if (intermediate.Node == null) return null;
            if (key == intermediate.Node.NodeKey)
            {
                intermediate.NodeHasKey = true;
                return intermediate;
            }

            if (key < intermediate.Node.NodeKey)
            {
                if (intermediate.Node.LeftChild == null)
                {
                    intermediate.ToLeft = true;
                    return intermediate;
                }
                intermediate.Node = (BSTNode<T>)intermediate.Node.LeftChild;
            }

            if (key > intermediate.Node.NodeKey)
            {
                if (intermediate.Node.RightChild == null)
                {
                    return intermediate;
                }
                intermediate.Node = (BSTNode<T>)intermediate.Node.RightChild;
            }

            return NodeIterator(key, intermediate);
        }
        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> intermediate = new BSTFind<T>(Root);
            if (Root != null) return NodeIterator(key, intermediate);
            return null;
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
            }
            else
            {
                BSTFind<T> intermediate = FindNodeByKey(key);
                if (intermediate.NodeHasKey) return false;
                if (intermediate.ToLeft)
                    intermediate.Node.LeftChild = new BSTNode<T>(key, val, intermediate.Node);
                else
                    intermediate.Node.RightChild = new BSTNode<T>(key, val, intermediate.Node);
            }
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальный/минимальный ключ в поддереве
            if (FromNode == null) FromNode = Root;
            if (FindMax)
            {
                if (FromNode.RightChild == null) return FromNode;
                FromNode = (BSTNode<T>)FromNode.RightChild;
            }
            else
            {
                if (FromNode.LeftChild == null) return FromNode;
                FromNode = (BSTNode<T>)FromNode.LeftChild;
            }

            return FinMinMax(FromNode, FindMax);
        }

        public BSTNode<T> DeleteRecursion(BSTNode<T> root, int key)
        {
            if (root == null) return root;
            if (key < root.NodeKey) root.LeftChild = DeleteRecursion((BSTNode<T>)root.LeftChild, key);
            else if (key > root.NodeKey) root.RightChild = DeleteRecursion((BSTNode<T>)root.RightChild, key);
            else if (root.LeftChild != null && root.RightChild != null)
            {
                var average = FinMinMax((BSTNode<T>)root.RightChild, false);
                root.NodeKey = average.NodeKey;
                root.NodeValue = average.NodeValue;
                root.RightChild = DeleteRecursion((BSTNode<T>)root.RightChild, root.NodeKey);
            }
            else
            {
                if (root.LeftChild != null)
                {
                    root.LeftChild.Parent = root.Parent;
                    root = (BSTNode<T>)root.LeftChild;
                }

                else if (root.RightChild != null)
                {
                    root.RightChild.Parent = root.Parent;
                    root = (BSTNode<T>)root.RightChild;
                }

                else root = null;
            }

            return root;
        }


        public bool DeleteNodeByKey(int key)
        {
            if (!FindNodeByKey(key).NodeHasKey) return false;

            Root = DeleteRecursion(Root, key);
            return true;
        }

        public int Count()
        {
            return CountNodes(Root);
        }

        private int CountNodes(BSTNode<T> node)
        {
            if (node == null) return 0;
            return 1 + CountNodes((BSTNode<T>)node.LeftChild) + CountNodes((BSTNode<T>)node.RightChild);
        }

        public List<BSTNode> WideAllNodes()
        {
            if (Root == null) return new List<BSTNode>();

            var res = new List<BSTNode>();
            var queue = new Queue<BSTNode>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                res.Add(node);

                if (node.LeftChild != null) queue.Enqueue(node.LeftChild);
                if (node.RightChild != null) queue.Enqueue(node.RightChild);
            }

            return res;
        }

        public List<BSTNode> DeepAllNodes(int order)
        {
            if (order < 0 || order > 2)
                throw new InvalidOperationException("order can be only 0, 1, 2");

            switch (order)
            {
                case 0:
                    return InOrder(Root);
                case 1:
                    return PostOrder(Root);
                default:
                    return PreOrder(Root);
            }
        }

        List<BSTNode> InOrder(BSTNode node)
        {
            if (node == null) return new List<BSTNode>();

            var result = new List<BSTNode>();
            result.AddRange(InOrder(node.LeftChild));
            result.Add(node);
            result.AddRange(InOrder(node.RightChild));

            return result;
        }

        List<BSTNode> PreOrder(BSTNode node)
        {
            if (node == null) return new List<BSTNode>();

            var result = new List<BSTNode>();
            result.Add(node);
            result.AddRange(PreOrder(node.LeftChild));
            result.AddRange(PreOrder(node.RightChild));

            return result;
        }

        List<BSTNode> PostOrder(BSTNode node)
        {
            if (node == null) return new List<BSTNode>();

            var result = new List<BSTNode>();
            result.AddRange(PostOrder(node.LeftChild));
            result.AddRange(PostOrder(node.RightChild));
            result.Add(node);

            return result;
        }
    }
}