using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class CList<T>
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // const
        private const int DEFAULT_SIZE = 1;                   // 리스트를 구성할 Array의 초기화를 위한 최소 크키 (변경할 수 없기에 Const 상수 지정)

        // private
        private       T[] _data        = new T[DEFAULT_SIZE]; // 리스트 생성 시 최초의 
        private       int _capacity    = 0;                   
        private       int _count       = 0;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public int Count 
        {
            get { return _count; }
        }
        
        public int Capacity
        {
            get
            {
                return _data.Length;
            }
            set
            {
                T[] tempArray = new T[DEFAULT_SIZE];

                if (value < _data.Length) tempArray = new T[_capacity];
                else                      tempArray = new T[value];

                for (int i = 0; i < _count; i++) 
                {
                    tempArray[i] = _data[i];
                } 

                _data = tempArray;
            }
        }

        // ----- Indexer
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // --------------------------------------------------
        // Function - Nomal
        // --------------------------------------------------
        public void Add(T item)
        {
            if (_count >= _data.Length)
            {
                T[] newArray = new T[_count * 2];
                for (int i = 0; i < _count; i++)
                {
                    newArray[i] = _data[i];
                }
                _data = newArray;
            }

            _data[_count] = item;
            _count++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_data[i].Equals(item))
                {
                    for (int j = i + 1; j < _count; j++)
                    {
                        _data[j - 1] = _data[j];
                    }

                    _count -= 1;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _data[_count - 1] = default(T);
            _count--;
        }

        public void Clear()
        {
            _data  = null;
            _count = 0;
        }

        public void Insert(int index, T item)
        {
            if (_count <= index) throw new ArgumentOutOfRangeException();

            if (_count + 1 >= _capacity)
            {
                if (_capacity == 0)
                    _capacity = 1;

                _capacity *= 2;

                T[] tempArray = new T[_count];
                Array.Copy(_data, 0, tempArray, 0, _count);

                Array.Copy(tempArray, 0, _data, 0, tempArray.Length);
            }

            T[] cappyArray = new T[_count - index];

            Array.Copy(_data,      index, cappyArray, 0,         _count - index);
            Array.Copy(cappyArray, 0,     _data,      index + 1, cappyArray.Length);

            _data[index] = item;
            _count += 1;
        }
    }
}