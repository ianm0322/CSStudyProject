using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class QueueByArray<T>
    {
        private T[] arr;
        private int front;
        private int rear;
        private int count;

        public int Count => count;
        public bool IsEmpty
        {
            get
            {
                return front == rear;
            }
        }
        public bool IsFull
        {
            get
            {
                return Next(front) == rear;
            }
        }

        public QueueByArray(int size = 2)
        {
            arr = new T[size];
            front = -1;
            rear = -1;
            count = 0;
        }

        public void Enqueue(T data)
        {
            if (IsFull)
            {
                throw new IndexOutOfRangeException();
            }
            count++;
            Next(ref front);
            arr[front] = data;
        }
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException();
            }

            count--;
            Next(ref rear);
            return arr[rear];
        }
        public T Peek()
        {
            return arr[rear];
        }


        public void Print()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException();
            int iter = rear;
            while(iter != front)
            {
                Next(ref iter);
                var result = arr[iter];
                Console.WriteLine(result);
            }
        }

        private void ArrayResize()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException();
            var newArray = new T[arr.Length * 2];
            int iter = rear;
            int i = 0;
            while(iter != front && i < Count)
            {
                Next(ref iter);
                newArray[i] = arr[iter];
                i++;
            }
            arr = newArray;
        }


        private int Next(int index)
        {
            index = (index + 1) % arr.Length;
            return index;
        }
        private int Next(ref int index)
        {
            index = (index + 1) % arr.Length;
            return index;
        }
    }
}
