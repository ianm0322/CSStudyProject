using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBasicCS.Data_structure
{
    public class Node<T>          // data를 가지고 next node를 가리키는 node class
    {
        public T data;
        public Node<T> next;

        public Node()
        {
            data = default(T);
            next = null;
        }
        public Node(T data)
        {
            this.data = data;
            next = null;
        }
    }
    class SingleLinkedListOther<T>
    {
        public T Data { get; set; }
        public SingleLinkedListOther<T> Next;
        public SingleLinkedListOther(T data)
        {
            this.Data = data;
            this.Next = null;
        }

        private SingleLinkedListOther<T> head;

        // 노드 추가 메소드
        public void Add(SingleLinkedListOther<T> newNode)
        {
            if (head == null)           // 리스트가 비어있을 시 새 노드 할당
                head = newNode;
            else
            {
                var current = head;
                while(current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void AddAfter(SingleLinkedListOther<T> current, SingleLinkedListOther<T> newNode)
        {
            if(head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void Remove(SingleLinkedListOther<T> removeNode) // 노드 삭제
        {
            if (head == null || removeNode == null)
                return;
            if(removeNode == head)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                var current = head;
                while (current != null && current.Next != removeNode)
                    current = current.Next;
                if(current != null)
                {
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SingleLinkedListOther<T> GetNode(int index)      // index 위치의 노드 반환
        {
            var current = head;
            for(int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }
            return current;           
        }

        public void Print()
        {
            var current = head;
            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public int Count()
        {
            int cnt = 0;
            var current = head;
            while(current != null)
            {
                cnt++;
                current = current.Next;
            }
            return cnt;
        }
    }
    class SinglyLinkedList<T>
    {
        // private field
        private Node<T> _head = new Node<T>();
        private int _count;

        // property
        public int count { get { return _count; } }

        public SinglyLinkedList()
        {
        }

        // Insert
        public void Add(T data, int idx)
        {

        }

        // Remove

        // Print
        public void Print()
        {
            Node<T> iter = _head;
            while(iter != null)
            {
                Console.WriteLine(iter.data);

                iter = iter.next;
            }
        }
    }
}
