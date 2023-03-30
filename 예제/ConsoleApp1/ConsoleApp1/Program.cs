using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void WOW<T>(Queue<T> queue)
        {
            Console.WriteLine(queue.Dequeue());
        }
        static void Main(string[] args)
        {
            {
                Queue<int> queue = new Queue<int>();
                Action printAndDequeue = () => { Console.WriteLine(queue.Dequeue()); };

                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Enqueue(4);
                queue.Enqueue(5);

                WOW(queue);
                WOW(queue);

                Console.WriteLine();

                var arr = queue.ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            return;

            {
                Stack<int> stack = new Stack<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);

                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(GetStackElement(stack, input));
            }
            return;

            #region [My Stack]
            {
                StackByArray<int> stack = new StackByArray<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);
                Console.WriteLine("[Stack By Array]");
                stack.Print();
                Console.WriteLine();

                Console.WriteLine("Peek");
                Console.WriteLine(stack.Peek());
                Console.WriteLine();

                Console.WriteLine("Pop");
                while (stack.Count > 0)
                {
                    Console.WriteLine(stack.Pop());
                }
                Console.WriteLine();
                StackByLink<int> stack2 = new StackByLink<int>();
                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Push(4);
                Console.WriteLine("[Stack By Link]");
                stack.Print();
                Console.WriteLine();

                Console.WriteLine("Peek");
                Console.WriteLine(stack.Peek());
                Console.WriteLine();

                Console.WriteLine("Pop");
                while (stack.Count > 0)
                {
                    Console.WriteLine(stack.Pop());
                }
                Console.WriteLine();
            }
            #endregion [My Stack]

            return;



        }

        static int GetStackElement(Stack<int> stack, int idx)
        {
            using (var enumerator = stack.GetEnumerator())
            {
                int i = 0;
                while (enumerator.MoveNext())
                {
                    if (i == idx)
                    {
                        return enumerator.Current;
                    }
                    i++;
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
}
