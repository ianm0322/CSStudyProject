using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1.복잡한 객체를 생성하는 비용이 클 때 사용.
// 2. 원형 객체를 미리 생성, 이를 복제해 새 객체 생성하는 방식.

// * 똑같은 데이터의 객체를 여러번 반복해 생성할 때.
// * 

namespace ConsoleApp1
{
    class PrototypePattern
    {
    }

    public abstract class Prototype:ICloneable // 추상 원본 클래스
    {
        public abstract Prototype Clone();  // 이 항목 필수. 원형인 Prototype반환하는 클론 함수.
        public string PrototypeSomething { get; protected set; }
        public void SetOwnData(string val)
        {
            this.PrototypeSomething = val;
        }

        object ICloneable.Clone()       // C#에서 제공하는 interface. object형 반환.
        {
            throw new NotImplementedException();
        }
    }

    // 프로토타입 서브클래스
    public class InheritPrototype : Prototype
    {
        public InheritPrototype()
        {
            PrototypeSomething = "InheritPrototype";
        }

        public override Prototype Clone()
        {

        }
    }
}
