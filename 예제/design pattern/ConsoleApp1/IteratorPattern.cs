using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Item
    {
    }

    interface IAbstractCollection<T>
    {
        Iterator<T> CreateIterator();
    }

    class Collection<T> : IAbstractCollection<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public Iterator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }
    }

    interface IAbstractIterator<T>
    {
        T Current { get; }
        bool MoveNext();
        void Reset();

    }

    class Iterator<T> : IAbstractIterator<T>
    {
        private Collection<T> collection;
        private int currentIndex;

        public T Current => collection[currentIndex];

        public Iterator(Collection<T> collection)
        {
            this.collection = collection;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return IsDone();
        }

        public bool IsDone()
        {
            if (currentIndex < collection.Count)
                return true;
            else
                return false;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}