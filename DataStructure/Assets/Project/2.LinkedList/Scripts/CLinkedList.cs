// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace DataStructure.LinkedList.Singly
{
    public class CLinckeList<T> : IEnumerable<T>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private CLinkedListNode<T> _headNode = null;
        private int                _count    = 0;

        // --------------------------------------------------
        // Constructor
        // --------------------------------------------------
        public CLinckeList()
        {
            _headNode = null;
            _count    = 0;
        }

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public int Count
        {
            get { return _count; }
        }

        public CLinkedListNode<T> First
        {
            get { return _headNode; }
        }

        public CLinkedListNode<T> Last
        {
            get
            {
                if (_headNode == null)
                {
                    return null;
                }

                CLinkedListNode<T> current = _headNode;
                while (current.NextNode != null)
                {
                    current = current.NextNode;
                }

                return current;
            }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public void AddLast(T item)
        {
            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            if (_headNode == null)
            {
                _headNode = newNode;
            }
            else
            {
                CLinkedListNode<T> currNode = _headNode;
                while (currNode.NextNode != null)
                {
                    currNode = currNode.NextNode;
                }
                currNode.NextNode = newNode;
            }

            _count++;
        }

        public void AddLast(CLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {

            }

            if (_headNode == null)
            {
                _headNode = newNode;
            }
            else
            {
                CLinkedListNode<T> currNode = _headNode;
                while (currNode.NextNode != null)
                {
                    currNode = currNode.NextNode;
                }
                currNode.NextNode = newNode;
            }

            _count++;
        }

        public void AddFirst(T item)
        {
            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            newNode.NextNode = _headNode;
            _headNode = newNode;

            _count++;
        }

        public void AddFirst(CLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {

            }

            newNode.NextNode = _headNode;
            _headNode = newNode;

            _count++;
        }

        public void AddAfter(CLinkedListNode<T> node, T item)
        {
            if (node == null)
            {

            }

            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            newNode.NextNode = node.NextNode;
            node.NextNode = newNode;

            _count++;
        }

        public void AddBefore(CLinkedListNode<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            if (_headNode == node)
            {
                AddFirst(item);
                return;
            }

            CLinkedListNode<T> current = _headNode;

            while (current != null)
            {
                if (current.NextNode == node)
                {
                    CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

                    newNode.NextNode = current.NextNode;
                    current.NextNode = newNode;

                    _count++;
                    return;
                }

                current = current.NextNode;
            }
        }

        public void AddBefore(CLinkedListNode<T> node, CLinkedListNode<T> newNode)
        {
            if (node == null)
            {

            }

            if (newNode == null)
            {

            }

            if (_headNode == node)
            {
                AddFirst(newNode);
                return;
            }

            CLinkedListNode<T> current = _headNode;

            while (current != null)
            {
                if (current.NextNode == node)
                {
                    newNode.NextNode = current.NextNode;
                    current.NextNode = newNode;
                    _count++;
                    return;
                }

                current = current.NextNode;
            }
        }

        public void Clear()
        {
            _headNode = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            CLinkedListNode<T> current = _headNode;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                    return true;

                current = current.NextNode;
            }

            return false;
        }

        public CLinkedListNode<T> Find(T item)
        {
            CLinkedListNode<T> current = _headNode;

            var debugCount = 0;

            while (current != null)
            {
                debugCount++;
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    Debug.Log($"Check Find Func {debugCount}");
                    return current;
                }

                current = current.NextNode;
            }

            return null;
        }
        public CLinkedListNode<T> FindLast(T item)
        {
            CLinkedListNode<T> current = _headNode;
            CLinkedListNode<T> lastMatch = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    lastMatch = current;
                }

                current = current.NextNode;
            }

            return lastMatch;
        }

        public void Remove(CLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "제공된 노드는 null일 수 없습니다.");
            }

            if (_headNode == node)
            {
                _headNode = _headNode.NextNode;
                _count--;
                return;
            }

            CLinkedListNode<T> current = _headNode;
            CLinkedListNode<T> previous = null;

            while (current != null)
            {
                if (current.NextNode == node)
                {
                    previous = current;
                    current.NextNode = node.NextNode;
                    _count--;
                    return;
                }

                current = current.NextNode;
            }

            throw new InvalidOperationException("주어진 노드가 LinkedList에 존재하지 않습니다.");
        }

        public bool Remove(T item)
        {
            CLinkedListNode<T> current = _headNode;
            CLinkedListNode<T> previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    if (previous == null)
                    {
                        _headNode = current.NextNode;
                    }
                    else
                    {
                        previous.NextNode = current.NextNode;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.NextNode;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (_headNode == null)
            {

            }

            _headNode = _headNode.NextNode;
            _count--;
        }

        public void RemoveLast()
        {
            if (_headNode == null)
            {

            }

            if (_headNode.NextNode == null)
            {
                _headNode = null;
            }
            else
            {
                CLinkedListNode<T> current = _headNode;
                while (current.NextNode.NextNode != null)
                {
                    current = current.NextNode;
                }
                current.NextNode = null;
            }

            _count--;

        }

        // --------------------------------------------------
        // IEnumerator
        // 
        // HeadNode부터 모든 요소들을 열거
        // 열거된 열거자를 가져온 후 IEnumerator로 반환
        // LinkedList를 열거할 수 있도록 구현
        // --------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            CLinkedListNode<T> current = _headNode;

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

namespace DataStructure.LinkedList.Doubly
{
    public class CLinkedList<T> : IEnumerable<T>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private CLinkedListNode<T> _headNode = null;
        private CLinkedListNode<T> _tailNode = null;
        private int                _count    = 0;

        // --------------------------------------------------
        // Constructor
        // --------------------------------------------------
        public CLinkedList()
        {
            _headNode = null;
            _tailNode = null;
            _count    = 0;
        }

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public int Count
        {
            get { return _count; }
        }

        public CLinkedListNode<T> First
        {
            get { return _headNode; }
        }

        public CLinkedListNode<T> Last
        {
            get { return _tailNode; }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void AddLast(T item)
        {
            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.PrevNode = _tailNode;
                _tailNode.NextNode = newNode;
                _tailNode = newNode;
            }

            _count++;
        }

        public void AddLast(CLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {

            }

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.PrevNode = _tailNode;
                _tailNode.NextNode = newNode;
                _tailNode = newNode;
            }

            _count++;
        }

        public void AddFirst(T item)
        {
            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.NextNode = _headNode;
                _headNode.PrevNode = newNode;
                _headNode = newNode;
            }

            _count++;
        }

        public void AddFirst(CLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The provided node cannot be null.");
            }

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.NextNode = _headNode;
                _headNode.PrevNode = newNode;
                _headNode = newNode;
            }

            _count++;
        }

        public void AddBefore(CLinkedListNode<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            newNode.NextNode = node;
            newNode.PrevNode = node.PrevNode;

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = newNode;
            }
            else
            {
                _headNode = newNode;
            }

            node.PrevNode = newNode;

            _count++;
        }

        public void AddBefore(CLinkedListNode<T> node, CLinkedListNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The provided new node cannot be null.");
            }

            newNode.NextNode = node;
            newNode.PrevNode = node.PrevNode;

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = newNode;
            }
            else
            {
                _headNode = newNode;
            }

            node.PrevNode = newNode;

            _count++;
        }

        public bool Contains(T item)
        {
            CLinkedListNode<T> current = _headNode;

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

        public CLinkedListNode<T> Find(T item)
        {
            CLinkedListNode<T> current = _headNode;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return current;
                }

                current = current.NextNode;
            }

            return null;
        }

        public CLinkedListNode<T> FindLast(T item)
        {
            CLinkedListNode<T> current = _tailNode;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return current;
                }

                current = current.PrevNode;
            }

            return null;
        }

        public void Remove(CLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            if (node == _headNode)
            {
                _headNode = node.NextNode;
            }

            if (node == _tailNode)
            {
                _tailNode = node.PrevNode;
            }

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }

            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }

            node.PrevNode = null;
            node.NextNode = null;

            _count--;
        }

        public bool Remove(T item)
        {
            CLinkedListNode<T> current = _headNode;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    Remove(current);
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (_headNode == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            if (_headNode == _tailNode)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                _headNode = _headNode.NextNode;
                _headNode.PrevNode = null;
            }

            _count--;
        }

        public void RemoveLast()
        {
            if (_tailNode == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            if (_headNode == _tailNode)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                _tailNode = _tailNode.PrevNode;
                _tailNode.NextNode = null;
            }

            _count--;

        }

        // --------------------------------------------------
        // IEnumerator
        // 
        // HeadNode부터 모든 요소들을 열거
        // 열거된 열거자를 가져온 후 IEnumerator로 반환
        // LinkedList를 열거할 수 있도록 구현
        // --------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            CLinkedListNode<T> current = _headNode;

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

namespace DataStructure.LinkedList.Circular 
{
    public class CLinkedList<T> : IEnumerable<T>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private CLinkedListNode<T> _headNode = null;
        private CLinkedListNode<T> _tailNode = null;
        private int                _count    = 0;

        // --------------------------------------------------
        // Constuctor
        // --------------------------------------------------
        public CLinkedList()
        {
            _headNode = null;
            _tailNode = null;
            _count = 0;
        }

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public int Count
        {
            get { return _count; }
        }

        public CLinkedListNode<T> First
        {
            get { return _headNode; }
        }

        public CLinkedListNode<T> Last
        {
            get { return _tailNode; }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void AddLast(T item)
        {
            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
                newNode.NextNode = newNode; // 첫 번째 노드를 가리키도록 설정
            }
            else
            {
                newNode.PrevNode = _tailNode;
                newNode.NextNode = _headNode;
                _tailNode.NextNode = newNode;
                _headNode.PrevNode = newNode;
                _tailNode = newNode;
            }

            _count++;
        }

        public void AddLast(CLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The provided node cannot be null.");
            }

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
                newNode.NextNode = newNode; // 첫 번째 노드를 가리키도록 설정
            }
            else
            {
                newNode.PrevNode = _tailNode;
                newNode.NextNode = _headNode;
                _tailNode.NextNode = newNode;
                _headNode.PrevNode = newNode;
                _tailNode = newNode;
            }

            _count++;
        }


        public void AddFirst(T item)
        {
            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
                newNode.NextNode = newNode; // 첫 번째 노드를 가리키도록 설정
            }
            else
            {
                newNode.PrevNode = _tailNode;
                newNode.NextNode = _headNode;
                _tailNode.NextNode = newNode;
                _headNode.PrevNode = newNode;
                _headNode = newNode;
            }

            _count++;
        }

        public void AddFirst(CLinkedListNode<T> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The provided node cannot be null.");
            }

            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
                newNode.NextNode = newNode; // 첫 번째 노드를 가리키도록 설정
            }
            else
            {
                newNode.PrevNode = _tailNode;
                newNode.NextNode = _headNode;
                _tailNode.NextNode = newNode;
                _headNode.PrevNode = newNode;
                _headNode = newNode;
            }

            _count++;
        }

        public void AddBefore(CLinkedListNode<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            CLinkedListNode<T> newNode = new CLinkedListNode<T>(item);

            newNode.NextNode = node;
            newNode.PrevNode = node.PrevNode;

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = newNode;
            }
            else
            {
                _headNode = newNode;
            }

            node.PrevNode = newNode;

            _count++;
        }

        public void AddBefore(CLinkedListNode<T> node, CLinkedListNode<T> newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The provided new node cannot be null.");
            }

            newNode.NextNode = node;
            newNode.PrevNode = node.PrevNode;

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = newNode;
            }
            else
            {
                _headNode = newNode;
            }

            node.PrevNode = newNode;

            _count++;
        }

        public bool Contains(T item)
        {
            CLinkedListNode<T> current = _headNode;

            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public CLinkedListNode<T> Find(T item)
        {
            CLinkedListNode<T> current = _headNode;

            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return current;
                }

                current = current.NextNode;
            }

            return null;
        }

        public CLinkedListNode<T> FindLast(T item)
        {
            CLinkedListNode<T> current = _tailNode;

            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return current;
                }

                current = current.PrevNode;
            }

            return null;
        }

        public bool Remove(T item)
        {
            CLinkedListNode<T> current = _headNode;

            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    Remove(current);
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public void Remove(CLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The provided node cannot be null.");
            }

            if (_count == 1)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;

                if (node == _headNode)
                {
                    _headNode = node.NextNode;
                }
                else if (node == _tailNode)
                {
                    _tailNode = node.PrevNode;
                }
            }

            node.PrevNode = null;
            node.NextNode = null;

            _count--;
        }

        public void RemoveFirst()
        {
            if (_headNode == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            if (_headNode == _tailNode)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                _headNode = _headNode.NextNode;
                _tailNode.NextNode = _headNode; // 첫 번째 노드를 가리키도록 설정
                _headNode.PrevNode = _tailNode;
            }

            _count--;
        }

        public void RemoveLast()
        {
            if (_tailNode == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            if (_headNode == _tailNode)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                _tailNode = _tailNode.PrevNode;
                _tailNode.NextNode = _headNode; // 마지막 노드를 가리키도록 설정
                _headNode.PrevNode = _tailNode;
            }

            _count--;

        }

        // --------------------------------------------------
        // IEnumerator
        // 
        // HeadNode부터 모든 요소들을 열거
        // 열거된 열거자를 가져온 후 IEnumerator로 반환
        // LinkedList를 열거할 수 있도록 구현
        // --------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            CLinkedListNode<T> current = _headNode;

            for (int i = 0; i < _count; i++)
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