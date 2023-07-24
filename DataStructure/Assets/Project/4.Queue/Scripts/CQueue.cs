// ----- C#
using System.Collections;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    public class CQueue<T> : IEnumerable<T>
    {
        // --------------------------------------------------
        // Node Class
        // --------------------------------------------------
        private class Node
        {
            public T    Data     { get; }
            public Node NextNode { get; set; }

            public Node(T data)
            {
                Data     = data;
                NextNode = null;
            }
        }

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private Node _headNode = null;
        private Node _tailNode = null;
        private int  _count    = 0;

        // --------------------------------------------------
        // Constructor
        // --------------------------------------------------
        public CQueue()
        {
            _headNode = null;
            _tailNode = null;
            _count    = 0;
        }

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public int Count => _count;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void Clear()
        {
            _headNode = null;
            _tailNode = null;
            _count    = 0;
        }

        public bool Contains(T item)
        {
            Node current = _headNode;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public T Dequeue()
        {
            if (_headNode == null)
            {
                //throw new InvalidOperationException("The queue is empty.");
            }

            T item    = _headNode.Data;
            _headNode = _headNode.NextNode;
            
            _count--;

            if (_headNode == null)
            {
                _tailNode = null;
            }

            return item;
        }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);

            if (_tailNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                _tailNode.NextNode = newNode;
                _tailNode          = newNode;
            }

            _count++;
        }

        public T Peek()
        {
            if (_headNode == null)
            {
                //throw new InvalidOperationException("The queue is empty.");
            }

            return _headNode.Data;
        }

        public T[] ToArray()
        {
            T[]  array   = new T[_count];
            Node current = _headNode;
            int  index   = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current      = current.NextNode;
                index++;
            }

            return array;
        }

        // --------------------------------------------------
        // IEnumerator
        // 
        // HeadNode부터 모든 요소들을 열거
        // 열거된 열거자를 가져온 후 IEnumerator로 반환
        // Queue를 열거할 수 있도록 구현
        // --------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            Node current = _headNode;

            while (current != null)
            {
                yield return current.Data;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

