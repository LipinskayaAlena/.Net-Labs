using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1_BinarySearchTree
{
    class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        private Node<T> root;

        private int size;

        public int Count
        {
            get { return size;  }
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> subtreeRoot = root;

            size++;

            while(subtreeRoot != null)
            {
                if(value.CompareTo(subtreeRoot.Value) > 0)
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
                } else if (value.CompareTo(subtreeRoot.Value) < 0)
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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Preorder();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Preorder();
        }
                

        public IEnumerator<T> Preorder()
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
            throw new NotImplementedException();
        }

        public void Clear()
        {
            root = null;
            size = 0;
        }

        
    }

    public class Node<T> : IComparable<Node<T>> where T : IComparable<T>
    {
        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Parent { get; set; }

        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public int CompareTo(Node<T> other)
        {
            if(other == null)
            {
                return -1;
            }
            return this.Value.CompareTo(other.Value);
        }
    }



}
