using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 기존에 있던 클래스 Adaptee가 있고,
// 그 Adaptee와 다른 라이브러리, 혹은 시스템을 연동시키고 싶으나
// 상호간의 인터페이스가 다를 때.
// 기존 기능(Adaptee)에 새 기능을 보완하여 내 방식대로 호환시키려 할 때,
// 내

namespace ConsoleApp1
{
    class AdepterPattern
    {
        public interface IConverting // 어텝터 인터페이스
        {
            void DoConvert();
        }

        public class Adaptee // 기존 인터페이스
        {
            public void AdapteeRequest()
            {

            }
        }

        // 클래스 어뎁터 패턴
        public class Adapter : Adaptee, IConverting
        {
            public void DoConvert()
            {
                base.AdapteeRequest();
            }
        }

        // 오브젝트 어댑터 패턴
        public class Adapter2 : IConverting
        {
            Adaptee adaptee = new Adaptee();    
            public void DoConvert()
            {
            }
        }
    }
}
