namespace DataStructure.LinkedList.Singly 
{ 
    public class CLinkedListNode<T>
    {
        public T                  Data     { get; set; }
        public CLinkedListNode<T> NextNode { get; set; }

        public CLinkedListNode()
        {
            Data     = default(T);
            NextNode = null;
        }

        public CLinkedListNode(T data)
        {
            Data     = data;
            NextNode = null;
        }
    }
}

namespace DataStructure.LinkedList.Doubly
{
    public class CLinkedListNode<T>
    {
        public T                  Data     { get; set; }
        public CLinkedListNode<T> PrevNode { get; set; }
        public CLinkedListNode<T> NextNode { get; set; }

        public CLinkedListNode(T data)
        {
            Data     = data;
            PrevNode = null;
            NextNode = null;
        }
    }
}

namespace DataStructure.LinkedList.Circular
{
    public class CLinkedListNode<T>
    {
        public T Data { get; set; }
        public CLinkedListNode<T> PrevNode { get; set; }
        public CLinkedListNode<T> NextNode { get; set; }

        public CLinkedListNode(T data)
        {
            Data = data;
            PrevNode = null;
            NextNode = null;
        }
    }
}