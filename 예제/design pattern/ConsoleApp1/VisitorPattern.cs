using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class VisitorPattern
    {

    }

    interface IVisitor  // 
    {
        public void VisitConcreteElementA(ConcreteElementA a);
        public void VisitConcreteElementB(ConcreteElementB b);
    }

    class ConcreteVisitor1 : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA a)
        {

        }

        public void VisitConcreteElementB(ConcreteElementB a)
        {

        }
    }

    class ConcreteVisitor2 : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA a)
        {

        }

        public void VisitConcreteElementB(ConcreteElementB a)
        {

        }
    }

    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }


}
