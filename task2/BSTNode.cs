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

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
            if (Root == null) return new BSTFind<T>();
            return FindNode(Root, key);
        }

        public BSTFind<T> FindNode(BSTNode<T> node, int key)
        {
            if (Root == null || node == null) return new BSTFind<T>();

            if (key == node.NodeKey) return new BSTFind<T>
            {
                Node = node,
                NodeHasKey = true,
            };

            if (node.NodeKey < key && node.RightChild == null) return new BSTFind<T>
            {
                Node = node,
                NodeHasKey = false,
                ToLeft = false,
            };
            if (node.NodeKey < key && node.RightChild != null) return FindNode(node.RightChild, key);

            if (node.LeftChild == null) return new BSTFind<T>
            {
                Node = node,
                NodeHasKey = false,
                ToLeft = true,
            };

            return FindNode(node.LeftChild, key);
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            // добавляем ключ-значение в дерево
            BSTFind<T> intermediateFind = FindNodeByKey(key);

            if (intermediateFind == null || intermediateFind.Node == null) return false;
            if (intermediateFind.NodeHasKey) return false;

            if (intermediateFind.ToLeft)
            {
                intermediateFind.Node.LeftChild = new BSTNode<T>(key, val, intermediateFind.Node);
                return true;
            }
            intermediateFind.Node.RightChild = new BSTNode<T>(key, val, intermediateFind.Node);
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальный/минимальный ключ в поддереве
            if (!FindMax && FromNode.LeftChild == null) return FromNode;
            if (!FindMax) return FinMinMax(FromNode.LeftChild, FindMax);
            if (FindMax && FromNode.RightChild == null) return FromNode;
            return FinMinMax(FromNode.RightChild, FindMax);
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            BSTFind<T> foundNode = FindNodeByKey(key);
            BSTNode<T> Node = foundNode.Node;
            BSTNode<T> successorNode;


            if (!foundNode.NodeHasKey) return false;

            if (Node.LeftChild != null && Node.RightChild != null)
            {
                successorNode = FinMinMax(Node.RightChild, false);

                if (Node == Root && GetAllNodes(successorNode).Count == 1)
                {
                    Node.RightChild.Parent = null;
                    Node.LeftChild.Parent = successorNode;
                    successorNode.LeftChild = Node.LeftChild;
                    Root = Node.RightChild;
                }

                if (Node == Root && successorNode != Node.RightChild)
                {
                    successorNode.Parent.LeftChild = null;
                    successorNode.Parent = null;

                    Root.LeftChild.Parent = successorNode;
                    successorNode.LeftChild = Root.LeftChild;

                    Root.RightChild.Parent = successorNode;
                    successorNode.RightChild = Root.RightChild;
                    Root = successorNode;
                }

                if (Node == Root)
                {
                    Root.LeftChild.Parent = successorNode;
                    successorNode.LeftChild = Root.LeftChild;

                    Root.RightChild.Parent = null;
                    Root = successorNode;
                }

                if (successorNode != Node.RightChild)
                {
                    successorNode.Parent = Node.Parent;
                    // successorNode.Parent.LeftChild = null;

                    if (Node.Parent != null && Node.Parent.LeftChild == Node) Node.Parent.LeftChild = successorNode;
                    else if (Node.Parent != null) Node.Parent.RightChild = successorNode;

                    if (Node.Parent != null && Node.LeftChild != null)
                    {
                        Node.LeftChild.Parent = successorNode;
                        successorNode.LeftChild = Node.LeftChild;
                    }

                    if (Node.RightChild == null) return true;
                    Node.RightChild.Parent = successorNode;
                    successorNode.RightChild = Node.RightChild;
                }

                successorNode.Parent = Node.Parent;

                if (Node.Parent != null && Node.Parent.LeftChild == Node) Node.Parent.LeftChild = successorNode;

                if (Node.Parent != null) Node.Parent.RightChild = successorNode;

                if (Node.LeftChild != null) successorNode.LeftChild = Node.LeftChild;
                if (Node.LeftChild != null) Node.LeftChild.Parent = successorNode;


            }

            if (Node == Root)
            {
                if (GetAllNodes(Root).Count == 1)
                    Root = null;
                else
                {
                    if (Node.LeftChild != null)
                    {
                        Node.LeftChild.Parent = null;
                        Root = Node.LeftChild;
                    }
                    else
                    {
                        Node.RightChild.Parent = null;
                        Root = Node.RightChild;
                    }
                }
            }

            if (Node.LeftChild == null && Node.RightChild == null)
            {
                if (Node.Parent.LeftChild == Node) Node.Parent.LeftChild = null;
                else Node.Parent.RightChild = null;

                Node.Parent = null;
            }

            else if (Node.LeftChild != null)
            {
                Node.LeftChild.Parent = Node.Parent;

                if (Node.Parent != null && Node.Parent.LeftChild == Node) Node.Parent.LeftChild = Node.LeftChild;
                else if (Node.Parent != null && Node.RightChild != null) Node.Parent.RightChild = Node.RightChild;
            }

            else
            {
                Node.RightChild.Parent = Node.Parent;

                if (Node.Parent.LeftChild == Node) Node.Parent.LeftChild = Node.LeftChild;
                else Node.Parent.RightChild = Node.RightChild;
            }

            return true;
        }

        private BSTNode<T> getLeftest(BSTNode<T> node)
        {
            if (node.LeftChild == null) return node;
            return getLeftest(node.LeftChild);
        }


        public int CountNodesRecursively(BSTNode<T> Node)
        {
            if (Node == null) return 0;

            int count = 1;

            if (Node.LeftChild != null) count += CountNodesRecursively(Node.LeftChild);
            if (Node.RightChild != null) count += CountNodesRecursively(Node.RightChild);

            return count;
        }
        public int Count()
        {
            if (Root == null) return 0;
            return CountNodesRecursively(Root);
        }

        public List<BSTNode<T>> GetAllNodes(BSTNode<T> Root)
        {
            List<BSTNode<T>> Nodes = new List<BSTNode<T>> { Root }; // all nodes
            if (Root == default) return Nodes;
            if (Root.LeftChild != default)
                Nodes.AddRange(GetAllNodes(Root.LeftChild));

            if (Root.RightChild != default)
                Nodes.AddRange(GetAllNodes(Root.RightChild));

            return Nodes;
        }

    }
}