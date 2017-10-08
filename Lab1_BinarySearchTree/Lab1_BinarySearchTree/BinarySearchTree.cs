using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1_BinarySearchTree
{
    class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
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
