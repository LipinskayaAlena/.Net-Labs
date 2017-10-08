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
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool IsEmpty
        {
            get { return root == null; }
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
