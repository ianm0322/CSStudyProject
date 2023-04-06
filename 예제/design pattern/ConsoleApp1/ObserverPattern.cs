using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ObserverPattern
    {
        public void Run()
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "X"));
            subject.Attach(new ConcreteObserver(subject, "Y"));
            subject.Attach(new ConcreteObserver(subject, "Z"));
            subject.State = "ABC";
            subject.Notify();
            subject.State = "776";
            subject.Notify();
        }
    }

    abstract class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach(var o in _observers)
            {
                o.OnEvent();
            }
        }
    }
    class ConcreteSubject : Subject
    {
        private string state;

        public ConcreteSubject()
        {

        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }
    }

    interface IObserver
    {
        public void OnEvent();
    }

    class ConcreteObserver : IObserver
    {
        private string name;
        private string state;
        private ConcreteSubject subject;

        // Constructor
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.subject = subject;
            this.name = name;
            //subject.Attach(this);
        }

        public void OnEvent()
        {

        }

        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }

}
