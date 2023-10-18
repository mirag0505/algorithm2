using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;

            if (Parent != null && Parent.Children == null)
            {
                List<SimpleTreeNode<T>> NodeList = new List<SimpleTreeNode<T>> { this };
                Parent.Children = NodeList;
            }
            if (Parent != null && Parent.Children is List<SimpleTreeNode<T>> && !Parent.Children.Contains(this)) Parent.Children.Add(this);
        }
    }

    public class SimpleTree<T> where T : IComparable<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode

            if (Root == null) Root = NewChild;
            if (ParentNode != null && ParentNode.Children == null)
            {
                List<SimpleTreeNode<T>> NodeList = new List<SimpleTreeNode<T>>();
                ParentNode.Children = NodeList;
            }
            if (ParentNode != null && ParentNode.Children is List<SimpleTreeNode<T>> && !ParentNode.Children.Contains(NewChild)) ParentNode.Children.Add(NewChild);

            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            // ваш код удаления существующего узла NodeToDelete
            if (NodeToDelete.Parent != null) NodeToDelete.Parent.Children.Remove(NodeToDelete);
            if (NodeToDelete.Parent != null && NodeToDelete.Parent.Children.Count == 0) NodeToDelete.Parent.Children = null;
            if (Root == NodeToDelete) Root = null;

            NodeToDelete.Children = null;
            NodeToDelete.Parent = null;
        }

        public void AddNodesRecursively(SimpleTreeNode<T> Node, List<SimpleTreeNode<T>> listNodes)
        {
            listNodes.Add(Node);
            if (Node.Children == null) return;
            foreach (SimpleTreeNode<T> children in Node.Children)
            {
                AddNodesRecursively(children, listNodes);
            }
        }

        public List<SimpleTreeNode<T>> CollectAllNodes(SimpleTreeNode<T> Node)
        {
            List<SimpleTreeNode<T>> listNodes = new List<SimpleTreeNode<T>>();
            AddNodesRecursively(Node, listNodes);
            return listNodes;
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
            if (Root == null) return null;
            return CollectAllNodes(Root);
        }

        public void FindNodesRecursively(SimpleTreeNode<T> Node, T val, List<SimpleTreeNode<T>> listNodes)
        {
            if (Node.NodeValue.CompareTo(val) == 0) listNodes.Add(Node);
            if (Node.Children == null) return;
            foreach (SimpleTreeNode<T> children in Node.Children)
            {
                FindNodesRecursively(children, val, listNodes);
            }
        }

        public List<SimpleTreeNode<T>> CollectAllNodesByValue(SimpleTreeNode<T> Node, T val)
        {
            List<SimpleTreeNode<T>> listNodes = new List<SimpleTreeNode<T>>();
            FindNodesRecursively(Node, val, listNodes);
            return listNodes;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            // ваш код поиска узлов по значению
            if (Root == null) return null;
            return CollectAllNodesByValue(Root, val);
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            // ваш код перемещения узла вместе с его поддеревом -- 
            if (OriginalNode == Root) return;
            if (NewParent != null && NewParent.Children == null)
            {
                List<SimpleTreeNode<T>> NodeList = new List<SimpleTreeNode<T>> { OriginalNode };
                NewParent.Children = NodeList;
            }
            if (NewParent != null && NewParent.Children is List<SimpleTreeNode<T>> && !NewParent.Children.Contains(OriginalNode)) NewParent.Children.Add(OriginalNode);
            if (OriginalNode.Parent != null) OriginalNode.Parent.Children.Remove(OriginalNode);
            if (OriginalNode.Parent != null && OriginalNode.Parent.Children.Count == 0) OriginalNode.Parent.Children = null;
        }

        public int CountNodesRecursively(SimpleTreeNode<T> Node)
        {
            if (Node == null) return 0;

            int count = 1;
            if (Node.Children == null) return count;

            foreach (SimpleTreeNode<T> child in Node.Children)
            {
                count += CountNodesRecursively(child);
            }

            return count;
        }

        public int Count()
        {
            // количество всех узлов в дереве
            if (Root == null) return 0;
            return CountNodesRecursively(Root);
        }

        public int LeafCountNodesRecursively(SimpleTreeNode<T> Node)
        {
            if (Node == null) return 0;
            if (Node.Children == null) return 1;

            int count = 0;
            foreach (SimpleTreeNode<T> children in Node.Children)
            {
                count += LeafCountNodesRecursively(children);
            }

            return count;
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            if (Root == null) return 0;
            return LeafCountNodesRecursively(Root);
        }

        // Чётное дерево -- это дерево с чётным количеством вершин.
        // найти лес, состоящий из чётных деревьев, из которого удалено максимально возможное количество рёбер
        // На входе имеется обычное (не бинарное) дерево, и требуется найти максимально возможное количество рёбер, 
        // которое можно из него удалить так, чтобы в результате получался лес из чётных деревьев.
        public List<T> EvenTrees()
        {
            List<T> eventTrees = new List<T>();
            if (CountNodesRecursively(Root) % 2 != 0) return eventTrees;

            foreach (SimpleTreeNode<T> children in Root.Children)
            {
                int count = CountNodesRecursively(children);

                if (count % 2 == 0) eventTrees.Add(children.NodeValue);
                else eventTrees.Add(Root.NodeValue);
            }

            return eventTrees;
        }

    }
}