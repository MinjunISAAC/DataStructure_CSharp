// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using DataStructure.LinkedList.Singly;
//using DataStructure.LinkedList.Doubly;
//using DataStructure.LinkedList.Circular;

public class Main : MonoBehaviour
{
    void Start()
    {
        CLinckeList<int> list = new CLinckeList<int>();

        CLinkedListNode<int> node_1 = new CLinkedListNode<int>(2);
        CLinkedListNode<int> node_2 = new CLinkedListNode<int>(4);

        CLinkedListNode<int> node_3 = new CLinkedListNode<int>(6);
        CLinkedListNode<int> node_4 = new CLinkedListNode<int>(6);

        list.AddLast(1);
        list.AddLast(node_1);

        list.AddAfter(node_1, 11);

        list.AddLast(3);
        list.AddLast(node_2);

        list.AddBefore(node_2, 22);

        list.AddLast(5);
        list.AddLast(node_3);

        list.AddFirst(33);

        list.AddLast(7);
        list.AddLast(8);

        list.AddFirst(node_4);

        foreach (int value in list)
        {
            Debug.Log(value);
        }
        list.Find(6);
        list.FindLast(6);
    }

}
