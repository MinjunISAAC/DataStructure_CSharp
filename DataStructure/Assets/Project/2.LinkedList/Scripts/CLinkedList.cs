// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

namespace DataStructure
{
    public class CLinckeList<T> : IEnumerable<T>
    {
        // --------------------------------------------------
        // Node Class
        // --------------------------------------------------
        private class Node
        {
            public T    Data     { get; set; }
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
        private int  _count    = 0;

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

        public int Length
        {
            get
            {
                int  length  = 0;
                Node current = _headNode;

                while (current != null)
                {
                    length++;
                    current = current.NextNode;
                }

                return length;
            }
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        /// <summary>
        /// Item(제네릭)을 받아서 Array에 더해주는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node newNode = new Node(item);

            if (_headNode == null)
            {
                _headNode = newNode;
            }
            else
            {
                Node current = _headNode;
                while (current.NextNode != null)
                {
                    current = current.NextNode;
                }
                current.NextNode = newNode;
            }

            _count++;
        }

        /// <summary>
        /// Array에 Index로 접근하여, 해당 Item(제네릭)을 돌려주는 함수
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            T resultItem = default(T);

            if (_TryGet(index, out resultItem))
                return resultItem;
            else
            {
                Debug.LogError($"[CArray.Get] 해당 Index에 대응되는 Item이 존재하지 않습니다. / {index}");
                return resultItem;
            }
        }

        /// <summary>
        /// Array에 해당 Item(제네릭)의 Index를 돌려주는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            int resultIndex = -1;

            if (_TryIndexOf(item, out resultIndex))
                return resultIndex;
            else
            {
                Debug.LogError($"[CArray.IndexOf] 해당 Item은 존재하지 않습니다 / {item}");
                return -1;
            }
        }

        /// <summary>
        /// 복사하고자 하는 배열(Source Array)의 가장 앞 Item부터 원하는 길이(Length)까지 복사 대상 배열(Copy Array)에 복사하는 함수  
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="copyArray"></param>
        /// <param name="length"></param>
        public void Copy(T[] sourceArray, T[] copyArray, int length)
        {
            Debug.Assert(sourceArray == null, $"[CArray.Copy] (Null) 복사하고자 하는 배열(Source Array)가 존재하지 않습니다.");
            Debug.Assert(copyArray   == null, $"[CArray.Copy] (Null) 복사 대상 배열(Copy Array)가 존재하지 않습니다.");
            Debug.Assert(length      <     0, $"[CArray.Copy] (OutRange) 복사하고자 하는 배열(Array)의 길이가 잘못되었습니다.");

            int sourceLength = Math.Min(length, sourceArray.Length);
            int copyLength   = Math.Min(length, copyArray.Length);
            int realLength   = Math.Min(sourceLength, copyLength);

            for (int i = 0; i < realLength; i++)
            {
                copyArray[i] = sourceArray[i];
            }
        }

        /// <summary>
        /// Array의 내용을 지우는 함수
        /// </summary>
        public void Clear()
        {
            _headNode = null;
            _count    = 0;
        }

        /// <summary>
        /// 선택 정렬을 통해서 Array의 Item들을 최소값부터 최대값까지 순서대로 정렬해주는 함수
        /// </summary>
        public void Sort()
        {
            if (_count <= 1)
                return;

            T[]  array   = new T[_count];
            Node current = _headNode;
            int  index   = 0;

            while (current != null)
            {
                array[index++] = current.Data;
                current        = current.NextNode;
            }

            for (int i = 0; i < _count - 1; i++)
            {
                Node minNode = _FindMinimumNode(array, i);
                _Swap(array, i, minNode);
            }

            current = _headNode;
            index   = 0;

            while (current != null)
            {
                current.Data = array[index++];
                current      = current.NextNode;
            }
        }

        /// <summary>
        /// Array를 역순으로 정렬해주는 함수
        /// </summary>
        public void Reverse()
        {
            if (_count <= 1)
                return;

            Node prevNode = null;
            Node currNode = _headNode;
            Node nextNode = null;

            while (currNode != null)
            {
                nextNode          = currNode.NextNode;
                currNode.NextNode = prevNode;
                prevNode          = currNode;
                currNode          = nextNode;
            }

            _headNode = prevNode;
        }

        // ----- Private
        /// <summary>
        /// Array에서 가장 작은 값을 가지고 있는 Node를 리턴하는 함수
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private Node _FindMinimumNode(T[] array, int startIndex)
        {
            Node minNode  = _headNode;
            Node currNode = _headNode;
            int index = 0;

            while (index < startIndex)
            {
                currNode = currNode.NextNode;
                index++;
            }

            while (currNode != null)
            {
                if (Comparer<T>.Default.Compare(currNode.Data, minNode.Data) < 0)
                    minNode = currNode;

                currNode = currNode.NextNode;
            }

            return minNode;
        }

        /// <summary>
        /// Index를 입력받아 Array에 Item이 있을 경우 True를 리턴하고 Item을 Out 키워드를 통해 할당 / 아닐 경우 False를 리턴하고 Default 값을 리턴하는 함수
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool _TryGet(int index, out T item)
        {
            item = default(T);

            if (index < 0 || index >= _count)
                return false;
            else
            {
                Node current = _headNode;
                for (int i = 0; i < index; i++)
                {
                    current = current.NextNode;
                }

                item = current.Data;
                return true;
            }
        }

        /// <summary>
        /// Item을 입력받아 Array에 Item값을 가지고 있는 Node를 검색하고 해당 Node가 있을 경우 True를 리턴하고 index을 Out 키워드를 통해 할당 / 아닐 경우 False를 리턴하고 -1 값을 리턴하는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool _TryIndexOf(T item, out int index)
        {
            Node current = _headNode;
            index = 0;

            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;

                current = current.NextNode;
                index++;
            }

            index = -1;
            return false;
        }

        /// <summary>
        /// Array의 특정 Index의 Node를 바꿔치기하는 함수 
        /// </summary>
        /// <param name="targetArray"></param>
        /// <param name="index"></param>
        /// <param name="node"></param>
        private void _Swap(T[] targetArray, int index, Node node)
        {
            T tempData         = targetArray[index];
            targetArray[index] = node.Data;
            node.Data          = tempData;
        }


        // --------------------------------------------------
        // IEnumerator
        // 
        // HeadNode부터 모든 요소들을 열거
        // 열거된 열거자를 가져온 후 IEnumerator로 반환
        // Array를 열거할 수 있도록 구현
        // --------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = _headNode;

            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}