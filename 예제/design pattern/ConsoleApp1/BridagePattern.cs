using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BridagePattern
    {
    }

    public interface IImplementor   // 구현체 // 구현할 함수 목록
    {
        void ImplementorOperation();
    }

    public abstract class Abstraction   // 추상층 // c/c++의 헤더 같은? 
    {
        public IImplementor Implementor { get; set; }
        public abstract void Operation();
    }

    public class ReflinedAbstraction:Abstraction    // 추상층 구현
    {
        public override void Operation()
        {
            Implementor.ImplementorOperation();
        }
    }

    public class ImplementorClass : IImplementor // 구현체 구현(Concrete Implement)
    {
        public void ImplementorOperation()
        {
            throw new NotImplementedException();
        }
    }
}
