using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CommandPattern : ITestMain
    {
        public void Run()
        {
            Receiver receiver = new Receiver(); // 내가 활용하려는 클래스
            Command command = new ConcreteCommand(receiver);    // 커맨드에 내가 활용하려는 클래스 정보 넣음.
            Invoker invoker = new Invoker();    // 커맨드 실행시킬 Invoker

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    abstract class Command
    {
        protected Receiver receiver;    // 수신자
        
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
        public abstract void Undo();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            // Wait(10s); 같은 코드를 넣으면 코드 실행 시간을 제어할 수 있고,
            // 
            receiver.Action();
        }

        public override void Undo()
        {
            // 실행 취소 기능을 구현하면, Command를 기억하는 History Collection이 해당 작업을 취소할 수 있다.
        }
    }

    class Receiver
    {
        public  void Action()
        {

        }
    }

    class Invoker
    {
        List<Command> _command = new List<Command>();

        public void SetCommand(Command command)
        {
            command.Equals(command);
        }

        public void ExecuteCommand()
        {
            for (int i = 0; i < _command.Count; i++)
            {
                _command[i].Execute();
            }
        }
    }
}
