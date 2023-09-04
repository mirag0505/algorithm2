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

        // Удаление, нужно удалять левый и правый

        // левый -- меньше родителя
        // правый -- больше родителя

        // если одинаковые -- правый больше или равен родителю

        // удаляемый узел -- заменяем узлом-приемником
        // его ключ -- наименьший ключ, который больше ключа удаляемого узла

        // или по другому
        // берем правый от удаляемого -- и спускаемся по левым
        // если искомое лист -- поместить вместо удаляемого узла
        // если есть только правый потомок -- преемник ЭТОТ узел
        // а вместо него -- его правый

        // Если я создаю новый узел с родителем, 
        // то мне нужно переходить в родителя
        // там поменять, либо rigth или left ребенка
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

            intermediateFind.Node = node;
            intermediateFind.NodeHasKey = false;
            if (node.NodeKey >= key) intermediateFind.ToLeft = true;
            else intermediateFind.ToLeft = false;

            return null;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу

            // Операция поиска должна выдавать либо факт присутствия ключа в дереве,
            // либо родительский узел, которому надо добавить новый узел в качестве потомка
            // и признак, каким этот узел добавляется -- левым или правым.

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

        public BSTNode<T> RecursiveDeleteNodeByKey(BSTNode<T> Node)
        {
            if (Node.LeftChild == null) return Node;
            if (Node.LeftChild != null) return RecursiveDeleteNodeByKey(Node);
            // Если мы находим узел, у которого есть только правый потомок, 
            if (Node.LeftChild == null && Node.RightChild != null)
            {
                // то преемником берём этот узел, а вместо него помещаем его правого потомка.
                Node.Parent.LeftChild = Node.RightChild;
                Node.RightChild = Node.RightChild.RightChild;  //это приемник
                // а вместо ПРИЕМНИКА надо поместить правый
                return null;
            }

            return null;
        }
        // и далее спускаться по всем левым потомкам.
        // Если мы находим лист, то его и надо поместить вместо удаляемого узла.
        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            var intermediateFind = this.FindNodeByKey(key);
            if (!intermediateFind.NodeHasKey) return false; // если узел не найден

            if (intermediateFind.Node == Root) Root = null;
            // если существует только один левый потомок
            if (intermediateFind.Node.LeftChild != null && intermediateFind.Node.RightChild == null)
            {
                intermediateFind.Node.LeftChild.Parent = intermediateFind.Node.Parent;
                intermediateFind.Node.Parent.LeftChild = intermediateFind.Node.LeftChild;
            }
            // если существует толко один правый потомок
            if (intermediateFind.Node.RightChild != null && intermediateFind.Node.LeftChild == null)
            {
                intermediateFind.Node.RightChild.Parent = intermediateFind.Node.Parent;
                intermediateFind.Node.Parent.RightChild = intermediateFind.Node.RightChild;
            }
            // если существует и левый и правый потомк
            // надо взять правого потомка удаляемого узла,
            var result = RecursiveDeleteNodeByKey(intermediateFind.Node.RightChild);
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

    }
}