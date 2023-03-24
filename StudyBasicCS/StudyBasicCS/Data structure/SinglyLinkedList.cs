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
    class SinglyLinkedList<T>
    {
        // private field
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        // property
        public int count { get { return _count; } }

        public SinglyLinkedList()
        {
        }

        // InsertLast
        public void InsertFront(T data)
        {
            if(_head == null)
            {
                _head = new Node<T>(data);
                _tail = _head;
                _count++;
                return;
            }
            var n = new Node<T>(data);
            n.next = _head;
            _head = n;

            _count++;
        }

        public void InsertAt(T data, int idx)
        {
            if (idx < 0 || idx >= count)
                throw new IndexOutOfRangeException();

            if (_head == null)
            {
                _head = new Node<T>(data);
                _tail = _head;
            }
            else if (count == 1 || idx == 0)
            {
                InsertFront(data);
            }
            else
            {
                var newNode = new Node<T>(data);

                // idx-1번째 요소에 접근       // 1~idx까지 반복
                var target = _head;
                for (int i = 0; i < count - 1; i++)
                {
                    target = target.next;
                }

                // new node의 next = idx-1의 next
                newNode.next = target;

                // idx-1의 next = new node
                target.next = newNode;
            }
            _count++;
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
