// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- User Defined
using DataStructure.LinkedList.Singly;

namespace DataStructure.Stack 
{ 
    public class CStack<T> : IEnumerable<T>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private CLinckeList<T> _baseList = null;

        // --------------------------------------------------
        // Constructor
        // --------------------------------------------------
        public CStack()
        {
            _baseList = new CLinckeList<T>();
        }

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public int Count 
        {
            get { return _baseList.Count; }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public bool Contains(T item)
        {
            return _baseList.Contains(item);
        }

        public void Push(T item)
        {
            _baseList.AddFirst(item);
        }

        public T Pop()
        {
            if (_baseList.Count == 0)
            {
                //throw new InvalidOperationException("The stack is empty.");
            }

            T item = _baseList.First.Data;
            _baseList.RemoveFirst();
            
            return item;
        }

        public T Peek()
        {
            if (_baseList.Count == 0)
            {
                //throw new InvalidOperationException("The stack is empty.");
            }

            return _baseList.First.Data;
        }

        public void Clear()
        {
            _baseList.Clear();
        }

        public T[] ToArray()
        {
            T[] array = new T[_baseList.Count];
            int index = 0;

            foreach (T item in _baseList)
            {
                array[index] = item;
                index++;
            }

            return array;
        }

        // --------------------------------------------------
        // IEnumerator
        // 
        // HeadNode���� ��� ��ҵ��� ����
        // ���ŵ� �����ڸ� ������ �� IEnumerator�� ��ȯ
        // LinkedList�� ������ �� �ֵ��� ����
        // --------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            return _baseList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}