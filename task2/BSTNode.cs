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

        // берем правый от удаляемого -- и спускаемся по левым
        // если искомое лист (без детей) -- поместить вместо удаляемого узла
        // если есть только правый потомок -- преемник ЭТОТ узел
        // а вместо него -- его правый
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

        public BSTNode<T> RecursionFindNode(BSTNode<T> node, int key, BSTFind<T> intermediateFind)
        {
            // Поиск начинается с родителя, сравниваем его с искомым,

            if (node.NodeKey == key)
            {
                intermediateFind.Node = node;
                intermediateFind.NodeHasKey = true;
                return null;
            }

            if (node.NodeKey > key && node.LeftChild != null) return RecursionFindNode(node.LeftChild, key, intermediateFind);
            if (node.NodeKey < key && node.RightChild != null) return RecursionFindNode(node.RightChild, key, intermediateFind);

            // это родитель, куда надо вставить ребенка
            intermediateFind.Node = node;
            intermediateFind.NodeHasKey = false;
            if (node.NodeKey >= key) intermediateFind.ToLeft = true;
            else intermediateFind.ToLeft = false;

            return null;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу

            BSTFind<T> intermediateFind = new BSTFind<T>();

            if (Root == null) intermediateFind.NodeHasKey = false;
            else RecursionFindNode(Root, key, intermediateFind);

            return intermediateFind;
        }

        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            BSTFind<T> intermediateFind = FindNodeByKey(key);

            // если ключ уже есть
            if (intermediateFind.NodeHasKey) return false;

            BSTNode<T> newNode = new BSTNode<T>(key, val, intermediateFind.Node);
            if (intermediateFind.ToLeft) intermediateFind.Node.LeftChild = newNode;
            if (!intermediateFind.ToLeft) intermediateFind.Node.RightChild = newNode;
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальный/минимальный ключ в поддереве
            if (FromNode == null) return null;
            if (!FindMax && FromNode.LeftChild == null) return FromNode;
            if (FindMax && FromNode.RightChild == null) return FromNode;

            if (!FindMax && FromNode.LeftChild != null) return FinMinMax(FromNode.LeftChild, FindMax);
            if (FindMax && FromNode.RightChild != null) return FinMinMax(FromNode.RightChild, FindMax);
            return FinMinMax(FromNode, FindMax);
        }

        // public BSTNode<T> RecursiveDeleteNodeByKey(BSTNode<T> Node, BSTFind<T> intermediate)
        // {
        //     if (Node.LeftChild != null) return RecursiveDeleteNodeByKey(Node.LeftChild, intermediate);
        //     //  Если мы находим лист, то его и надо поместить вместо удаляемого узла.
        //     if (Node.LeftChild == null && Node.RightChild == null)
        //     {
        //         intermediate.Node.Parent.LeftChild = Node;
        //         intermediate.Node.LeftChild.Parent = Node;
        //         return null;
        //     }
        //     // Если мы находим узел, у которого есть только правый потомок, 
        //     if (Node.LeftChild == null && Node.RightChild != null)
        //     {
        //         // то преемником берём этот узел, а вместо него помещаем его правого потомка.
        //         intermediate.Node.Parent.RightChild = Node.RightChild;
        //         intermediate.Node.RightChild.Parent = Node;
        //         return null;
        //     }

        //     return null;
        // }
        // public bool DeleteNodeByKey(int key)
        // {
        //     // удаляем узел по ключу
        //     var intermediateFind = this.FindNodeByKey(key);
        //     if (!intermediateFind.NodeHasKey) return false; // если узел не найден

        //     if (intermediateFind.Node.RightChild == null && intermediateFind.Node.LeftChild == null)
        //     {
        //         intermediateFind.Node.Parent.RightChild = null;
        //         intermediateFind.Node.Parent.LeftChild = null;
        //     }
        //     if (intermediateFind.Node.LeftChild != null && intermediateFind.Node.RightChild == null)
        //     {
        //         intermediateFind.Node.Parent.LeftChild = intermediateFind.Node.LeftChild;
        //         intermediateFind.Node.LeftChild.Parent = intermediateFind.Node.Parent;
        //     }
        //     if (intermediateFind.Node.RightChild != null && intermediateFind.Node.LeftChild == null)
        //     {
        //         intermediateFind.Node.Parent.RightChild = intermediateFind.Node.RightChild;
        //         intermediateFind.Node.RightChild.Parent = intermediateFind.Node.Parent;
        //     }
        //     // если существует и левый и правый потомки
        //     if (intermediateFind.Node.RightChild != null && intermediateFind.Node.LeftChild != null)
        //     {
        //         // надо взять правого потомка удаляемого узла,
        //         RecursiveDeleteNodeByKey(intermediateFind.Node.RightChild, intermediateFind);
        //         // что я здесь должен получить?
        //         // или самый левый узел без потомков, берем его и заменяем удаленный
        //         // или если левый пустой, а правый нет -- берём этот узел, а вместо него помещаем его правого потомка.
        //     }

        //     return true;
        // }

        public bool DeleteNodeByKey(int key)
        {
            var nodeToDelete = FindNodeByKey(key);
            if (!nodeToDelete.NodeHasKey) return false;

            BSTNode<T> parent = nodeToDelete.Node.Parent;
            BSTNode<T> leftChild = nodeToDelete.Node.LeftChild;
            BSTNode<T> rightChild = nodeToDelete.Node.RightChild;

            // Если у узла нет потомков или только один потомок
            BSTNode<T> child = leftChild ?? rightChild;

            if (leftChild == null || rightChild == null)
            {
                if (parent == null) Root = child;

                if (parent != null && parent.LeftChild == nodeToDelete.Node) parent.LeftChild = child;
                else parent.RightChild = child;

                if (child != null) child.Parent = parent;
                return true;
            }

            // Если у узла два потомка
            BSTNode<T> successor = FinMinMax(rightChild, false);
            nodeToDelete.Node.NodeKey = successor.NodeKey;
            nodeToDelete.Node.NodeValue = successor.NodeValue;

            if (successor.Parent.LeftChild == successor) successor.Parent.LeftChild = successor.RightChild;
            else successor.Parent.RightChild = successor.RightChild;

            if (successor.RightChild != null) successor.RightChild.Parent = successor.Parent;
            return true;
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
            List<BSTNode<T>> Nodes = new List<BSTNode<T>>(); // all nodes
            Nodes.Add(Root);

            if (Root.LeftChild != null)
                Nodes.AddRange(GetAllNodes(Root.LeftChild));

            if (Root.RightChild != null)
                Nodes.AddRange(GetAllNodes(Root.RightChild));

            return Nodes;
        }

    }
}