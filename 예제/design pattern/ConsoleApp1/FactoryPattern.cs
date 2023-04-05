using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum eTest
    {
        AA, BB,
        End
    }

    #region [추상 팩토리]

    public class ProductA { }
    public class ConcreteProduct2A : ProductA { }
    public class ProductB { }
    

    #endregion [추상 팩토리]

    #region [일반 팩토리 메소드]
    class FactoryPattern
    {
        public static void Main1()
        {
            // 1 concrete factory 사용
            // 팩토리 서브 클래스로부터 객체를 생성하여 abstract factory M의 메서드에서 사용하는 방식
            AbstractFactoryM fac = new InheritedSubFactory1();
            fac.SomethingParentMethod();

            // 2. static factory method 호출
            // 라이브러리에서 어떤 객체를 사용할지를 결정하게 하여 클라이언트에 로그 객체를 리턴하는 방식
            AbstractFactoryM fac2 = AbstractFactoryM.GetAbstractFactoryM(EFactoryKind.Sub2);
            fac2.SomethingParentMethod();
        }
    }

    public enum EFactoryKind
    {
        Sub1, Sub2,End
    }
    public interface IFactory   // factory interface
    {
        void SomeMethod();      // 서브클래스가 동일하게 구현해씅면 싶은 함수 선언
    }
    class SubFactory1 : IFactory
    {
        public EFactoryKind _kind { get; private set; } = EFactoryKind.End;
        private string a;
        public SubFactory1(string a)
        {
            this.a = a;
            _kind = EFactoryKind.Sub1;
        }
        public void SomeMethod()
        {

        }
    }
    class SubFactory2 : IFactory
    {
        public EFactoryKind _kind { get; private set; } = EFactoryKind.End;
        private int a;

        public SubFactory2(int a)
        {
            this.a = a;
            _kind = EFactoryKind.Sub2;
        }
        public void SomeMethod()
        {

        }
    }

    //
    abstract class AbstractFactoryM
    {
        protected abstract IFactory GetFactory();
        public void SomethingParentMethod() // 인터페이스 외에도 필요한 공통적 작업 추가. 최상위 클래스로서 필요한 것들.
        {

        }

        public static AbstractFactoryM GetAbstractFactoryM(EFactoryKind _kind)
        {
            switch (_kind)
            {
                case EFactoryKind.Sub1:
                    return new InheritedSubFactory1();
                case EFactoryKind.Sub2:
                    return new InheritedSubFactory1();
                default:
                    return null;
            }
        }
    }

    class InheritedSubFactory1 : AbstractFactoryM
    {
        protected override IFactory GetFactory()
        {
            return new SubFactory1("sub1");
        }
    }

    class InheritedSubFactory2 : AbstractFactoryM
    {
        protected override IFactory GetFactory()
        {
            return new SubFactory2(2);
        }
    }
    #endregion [일반 팩토리 메소드]



    //public abstract class FactoryMethodClass
    //{ }


    //public interface IFactoryMethod
    //{ }

    //public class FactoryMethodCreatorClass
    //{
    //    public static FactoryMethodClass Create(eTest _enum)
    //    {
    //        FactoryMethodClass returnClass = null;
    //        switch (_enum)
    //        {
    //            case eTest.AA:
    //                returnClass = new AA();
    //                break;
    //            case eTest.BB:
    //                returnClass = new BB();
    //                break;
    //            default:
    //                break;
    //        }
    //        return returnClass;
    //    }

    //    public AA CreateAA()
    //    {
    //        AA aa = new AA();
    //        // 셋팅 내용
    //        return aa;
    //    }
    //}

    //public class AA : FactoryMethodClass { }
    //public class BB : FactoryMethodClass { }
}