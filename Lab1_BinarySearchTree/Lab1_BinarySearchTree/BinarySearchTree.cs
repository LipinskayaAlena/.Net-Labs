using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1_BinarySearchTree
{
    public class BinarySearchTree<T> : ICollection<T>
    {
        private IComparer<T> comparer;

        private Node<T> root;

        private int size;

        public Node<T> Root
        {
            get { return root; }
                
        }

        public int Count
        {
            get { return size;  }
        }

        public BinarySearchTree(IEnumerable<T> collection)
        {
            comparer = Comparer<T>.Default;
            foreach(var value in collection) {
                Add(value);
            }
        }

        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            this.comparer = comparer;
            foreach (var value in collection)
            {
                Add(value);
            }
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> subtreeRoot = root;

            size++;

            while(subtreeRoot != null)
            {
                if(comparer.Compare(value, subtreeRoot.Value) > 0)
                {
                    if(subtreeRoot.Right != null)
                    {
                        subtreeRoot = subtreeRoot.Right;
                    }
                    else
                    {
                        node.Parent = subtreeRoot;
                        subtreeRoot.Right = node;
                        break;
                    }
                } else if (comparer.Compare(value, subtreeRoot.Value) < 0)
                {
                    if(subtreeRoot.Left != null)
                    {
                        subtreeRoot = subtreeRoot.Left;
                    } else
                    {
                        node.Parent = subtreeRoot;
                        subtreeRoot.Left = node;
                        break;
                    }
                }
            }

            if(IsEmpty)
            {
                root = node;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Contains(T item)
        {
            var current = root;
            while(current != null)
            {
                if(comparer.Compare(item, current.Value) == 0)
                    return true;
                 else if(comparer.Compare(item, current.Value) < 0)
                    current = current.Left;
                 else
                    current = current.Right;
            }
            return false;
        }
        

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
                throw new ArgumentException();
            
            if(arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException();
            
            foreach (var value in this)
                array[arrayIndex++] = value;
            
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
                
        public IEnumerable<T> Inorder()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            if (root == null)
            {
                yield break;
            }
            Node<T> current = root;
            while(stack.Count != 0 || current != null)
            {
                if(current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                } else
                {
                    Node<T> node = stack.Pop();
                    yield return node.Value;
                    current = node.Right;
                }
            }
        }

        public IEnumerable<T> Postorder()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            if (root == null)
            {
                yield break;
            }
            stack.Push(root);
            
            while (stack.Count != 0)
            {
                Node<T> current = stack.Peek();

                if(current.Right == null && current.Left == null)
                {
                    Node<T> node = stack.Pop();
                    yield return node.Value;
                } else
                {
                    if (current.Right != null)
                    {
                        stack.Push(current.Right);
                        current.Right = null;
                    }

                    if (current.Left != null)
                    {
                        stack.Push(current.Left);
                        current.Left = null;
                    }
                }
            }
        }



        public IEnumerable<T> Preorder()
        {
            Stack<Node<T>> stack = new Stack<Node<T>>();
            if (root == null)
            {
                yield break;
            } else
            {
                stack.Push(root);
            }
            

            while(stack.Count != 0)
            {
                Node<T> current = stack.Pop();
                yield return current.Value;
                if (current.Right != null)
                    stack.Push(current.Right);
                if (current.Left != null)
                    stack.Push(current.Left);
            }

        }

        bool IsEmpty
        {
            get { return root == null; }
        }

        public bool Remove(T item)
        {
            if(root == null)
                return false;

            if(Contains(item))
            {
                DeleteNode(root, item);
                size--;
            } else
                return false;
            
            return true;
        }

        public Node<T> DeleteNode(Node<T> node, T item)
        {
            if(node == null)
                return node;
            
            if(comparer.Compare(item, node.Value) < 0)
                node.Left = DeleteNode(node.Left, item);
            else if (comparer.Compare(item, node.Value) > 0)
                node.Right = DeleteNode(node.Right, item);
            else if (node.Left != null && node.Right != null)
            {
                node.Value = Min(node.Right).Value;
                node.Right = DeleteNode(node.Right, node.Value);
            } else
            {
                if(node.Left != null)
                    node = node.Left;
                 else
                    node = node.Right;
            }
            return node;
        }

        public Node<T> Min(Node<T> node)
        {
            if (node.Left == null)
                return node;
             else
                return Min(node.Left);
        }

        

        public void Clear()
        {
            root = null;
            size = 0;
        }

    }

    public class Node<T>
    {
        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Parent { get; set; }

        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

    }





}
