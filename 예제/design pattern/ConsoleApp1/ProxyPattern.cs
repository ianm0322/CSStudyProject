using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 //* 클라이언트와 실제 사용하는 객체 사이에 대리자(Proxy)를 두고 실제 객체 대신 프록시를 호출하는 방식.
 //* 프록시는 실제 객체와 동일한 인터페이스를 가짐.
 //* 실제 객체에 직접 접근하는 대신 인터페이스를 재정의한 프록시를 통해 호출함으로서 안정성을 높이는 패턴.
namespace ConsoleApp1
{
    class ProxyPattern
    {
    }

    interface ISubject
    {
        void Request();
    }

    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    class Proxy : ISubject
    {
        private RealSubject realSubject;

        public void Request()
        {
            if(realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }
}
