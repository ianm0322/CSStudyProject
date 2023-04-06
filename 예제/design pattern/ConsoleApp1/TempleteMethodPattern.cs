using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TempleteMethodPattern
    {
    }
    
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        public virtual void VirtualMethod()
        {

        }
        // 특정 로직의 메소드는 override하지 않음.
        public void TempleteMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            VirtualMethod();
        }
    }
}
