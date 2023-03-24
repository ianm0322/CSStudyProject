using System;
using System.Threading;
using StudyBasicCS.Data_structure;

namespace StudyBasicCS
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }




            return;

            SinglyLinkedList<string> list = new SinglyLinkedList<string>();
            list.InsertFront("!");
            list.InsertFront("World");
            list.InsertFront("Hello");
            list.InsertAt("WOW", 1);
            list.Print();
        }
    }

    class Item
    {
        public string _name;
        public string _type;
        public int _count;

        public Item(string _name)
        {
            this._name = _name;
            _type = "";
            _count = 1;
        }

        public static bool operator==(Item left, Item right)
        {
            return left._name == right._name;
        }

        public static bool operator !=(Item left, Item right)
        {
            return (left == right) == false;
        }

        public override bool Equals(object other)
        {
            return this == (Item)other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
