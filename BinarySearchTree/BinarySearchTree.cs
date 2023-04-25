using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataStructure
{
    internal class BinarySearchTree<T> where T : IComparable<T>     // T는 비교가능한 자료형
    {
        private Node root;

        public BinarySearchTree()       // 생성자 함수
        {
            this.root = null;
        }

        public void Add (T item)
        {
            Node newNode = new Node(item, null, null, null);

            if (root == null)
            {
                root = newNode;     // 루트를 새로운 노드로 선언
                return;
            }

            Node current = root;    // 루트가 null이 아닌 경우
            while (current != null)
            {
                // 비교해서 더 작은 경우 왼쪽으로 감
                if (item.CompareTo(current.item) < 0)  
                {
                    // 비교 노드가 왼쪽 자식이 있는 경우
                    if (current.left != null)
                    {
                        // 자식과 또 비교하기 위해 current 왼쪽 자식으로 설정
                        current.left = current;
                    }
                    // 비교 노드가 왼쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.left = newNode;
                        newNode.parent = current;   // 새로운 노드의 부모가 현재 있던 노드
                        return;
                    }
                }
                // 비교해서 더 큰 경우 오른쪽으로 감
                else if (item.CompareTo(current.item) > 0) 
                {
                    // 비교 노드가 오른쪽 자식이 있는 경우
                    if (current.right != null)
                    {
                        // 자식과 또 비교하기 위해 current 오른쪽 자식으로 설정
                        current = current.right;
                    }
                    // 비교 노드가 오른쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                {
                    return;
                }
            }
        }

        public bool TryGetValue(T item, out T outValue)
        {
            if (root == null)
            {
                outValue = default(T);
                return false;       // 애초에 트리 자체가 비어있음
            }

            Node current = root;
            while (current != null) 
            { 
                // 현재 노드의 값이 찾고자 하는 값보다 작은 경우
               if (item.CompareTo(current.item) < 0)
                {
                    // 왼쪽 자식부터 다시 찾기 시작
                    current = current.left;
                }
               // 현재 노드의 값이 찾고자 하는 값보다 큰 경우
               else if (item.CompareTo(current.item) >0)
                {
                    // 오른쪽 자식부터 다시 찾기 시작
                    current = current.right;
                }
               // 현재 노드의 값이 찾고자 하는 값이랑 같은 경우
               else
                {
                    // 찾음
                    outValue = current.item;
                    return true;

                }
            }
            outValue = default(T);
            return false;
        }

        private void EraseNode(Node node)
        {
            // 1. 자식 노드가 없는 노드일 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild)
                    node.parent.left = null;
                else if (node.IsRightChild)
                    node.parent.right = null;
                else // if (node.IsRootNode)
                    root = null;
            }
            // 2. 자식 노드가 1개인 노드일 경우
            else if (node.HasLeftChild || node.HasRightChild)
            {
                Node parent = node.parent;
                Node child = node.HasLeftChild ? node.left : node.right;

                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                }
                else   // if (node.IsRootNode)
                {
                    root = child;
                    child.parent = null;
                }
            }
            // 3. 자식 노드가 2개인 노드일 경우
            // 왼쪽 자식 중 가장 큰 값과 데이터 교환한 후, 그 노드를 지워주는 방식으로 대체
            else // if (node.HasBothChild)
            {
                Node replaceNode = node.left;
                while (replaceNode.right != null)
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);

                /* 어느쪽이든 상관없다
                Node replaceNode = node.right;
                while (replaceNode.left != null)
                {
                    replaceNode = replaceNode.left;
                }
                node.item = replaceNode.item;
                EraseNode(replaceNode);
                */
            }
        }

        public void Print()
        {
            Print(root);
        }

        public void Print(Node node)
        {
            if (node.left != null) Print(node.left);
            Console.WriteLine(node.item);
            if (node.right != null) Print(node.right);
        }

        public class Node
        {
            // 객체, 부모, 좌측 자식, 우측 자식
           internal T item;
           internal Node parent;
           internal Node left;
           internal Node right;

            public Node(T item, Node parent, Node left, Node right) 
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRootNode { get { return parent == null; } }   
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            public bool HasNoChild { get { return left == null && right == null; } }
            public bool HasLeftChild { get { return left  != null && right == null; } }
            public bool HasRightChild { get { return left == null && right != null; } }
           //  public bool HasOneChild { get { return HasLeftChild ^ HasRightChild; } }
            public bool HasBothtChild { get { return left != null && right != null; } }



        }
    }
}
