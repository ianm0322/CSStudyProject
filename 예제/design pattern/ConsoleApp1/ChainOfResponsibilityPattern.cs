using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ITestMain
{
    void Run();
}

namespace ConsoleApp1
{
    class ChainOfResponsibilityPattern : ITestMain
    {
        public void Run()
        {
            Handler c1 = new ConcreteHandler1();
            Handler c2 = new ConcreteHandler2();
            Handler c3 = new ConcreteHandler3();
            c1.Next = c2;
            c2.Next = c3;
            // 위 과정을 관리자 클래스를 구현하여 정리할 수 있다.

            c1.Process(eCommandType.Cmd2, "처리하라!");
        }
    }

    public enum eCommandType
    {
        Cmd1,
        Cmd2,
        Cmd3,
        End
    }

    public abstract class Handler
    {
        public Handler Next { get; set; }
        public abstract void Process(eCommandType commandType, string request);
    }

    public class ConcreteHandler1 : Handler
    {
        public override void Process(eCommandType commandType, string request)
        {
            if(commandType == eCommandType.Cmd1)
            {
                // Command 1 처리
            }
            else
            {
                this.Next.Process(commandType, request);
            }
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void Process(eCommandType commandType, string request)
        {
            if (commandType == eCommandType.Cmd2)
            {
                // Command 2 처리
            }
            else
            {
                this.Next.Process(commandType, request);
            }
        }
    }

    public class ConcreteHandler3 : Handler
    {
        public override void Process(eCommandType commandType, string request)
        {
            if (commandType == eCommandType.Cmd3)
            {
                // Command 3 처리
            }
        }
    }
}
