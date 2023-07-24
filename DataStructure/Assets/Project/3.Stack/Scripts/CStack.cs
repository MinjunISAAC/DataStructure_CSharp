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
        // HeadNode부터 모든 요소들을 열거
        // 열거된 열거자를 가져온 후 IEnumerator로 반환
        // LinkedList를 열거할 수 있도록 구현
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