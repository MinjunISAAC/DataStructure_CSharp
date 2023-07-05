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
        /// Item(���׸�)�� �޾Ƽ� Array�� �����ִ� �Լ�
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
        /// Array�� Index�� �����Ͽ�, �ش� Item(���׸�)�� �����ִ� �Լ�
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
                Debug.LogError($"[CArray.Get] �ش� Index�� �����Ǵ� Item�� �������� �ʽ��ϴ�. / {index}");
                return resultItem;
            }
        }

        /// <summary>
        /// Array�� �ش� Item(���׸�)�� Index�� �����ִ� �Լ�
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
                Debug.LogError($"[CArray.IndexOf] �ش� Item�� �������� �ʽ��ϴ� / {item}");
                return -1;
            }
        }

        /// <summary>
        /// �����ϰ��� �ϴ� �迭(Source Array)�� ���� �� Item���� ���ϴ� ����(Length)���� ���� ��� �迭(Copy Array)�� �����ϴ� �Լ�  
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="copyArray"></param>
        /// <param name="length"></param>
        public void Copy(T[] sourceArray, T[] copyArray, int length)
        {
            Debug.Assert(sourceArray == null, $"[CArray.Copy] (Null) �����ϰ��� �ϴ� �迭(Source Array)�� �������� �ʽ��ϴ�.");
            Debug.Assert(copyArray   == null, $"[CArray.Copy] (Null) ���� ��� �迭(Copy Array)�� �������� �ʽ��ϴ�.");
            Debug.Assert(length      <     0, $"[CArray.Copy] (OutRange) �����ϰ��� �ϴ� �迭(Array)�� ���̰� �߸��Ǿ����ϴ�.");

            int sourceLength = Math.Min(length, sourceArray.Length);
            int copyLength   = Math.Min(length, copyArray.Length);
            int realLength   = Math.Min(sourceLength, copyLength);

            for (int i = 0; i < realLength; i++)
            {
                copyArray[i] = sourceArray[i];
            }
        }

        /// <summary>
        /// Array�� ������ ����� �Լ�
        /// </summary>
        public void Clear()
        {
            _headNode = null;
            _count    = 0;
        }

        /// <summary>
        /// ���� ������ ���ؼ� Array�� Item���� �ּҰ����� �ִ밪���� ������� �������ִ� �Լ�
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
        /// Array�� �������� �������ִ� �Լ�
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
        /// Array���� ���� ���� ���� ������ �ִ� Node�� �����ϴ� �Լ�
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
        /// Index�� �Է¹޾� Array�� Item�� ���� ��� True�� �����ϰ� Item�� Out Ű���带 ���� �Ҵ� / �ƴ� ��� False�� �����ϰ� Default ���� �����ϴ� �Լ�
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
        /// Item�� �Է¹޾� Array�� Item���� ������ �ִ� Node�� �˻��ϰ� �ش� Node�� ���� ��� True�� �����ϰ� index�� Out Ű���带 ���� �Ҵ� / �ƴ� ��� False�� �����ϰ� -1 ���� �����ϴ� �Լ�
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
        /// Array�� Ư�� Index�� Node�� �ٲ�ġ���ϴ� �Լ� 
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
        // HeadNode���� ��� ��ҵ��� ����
        // ���ŵ� �����ڸ� ������ �� IEnumerator�� ��ȯ
        // Array�� ������ �� �ֵ��� ����
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