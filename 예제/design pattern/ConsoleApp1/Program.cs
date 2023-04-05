using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 생성 패턴
            /* 싱승톤 패턴
             */
            // 구조 패턴
            /* 어댑터 
             * 브릿지
             */
            // 행위 패턴
            /* 커맨드
             * 책임 연쇄
             * 반복자
             * 중재자 
             * 메멘토
             * 
             */
        }
    }

    class StateMachine
    {

    }

    interface IState
    {
        public IState State { get; set;}

        public void Do();

        public void Next();
    }

    class AttackState : IState
    {
        public void Do()
        {
            Console.WriteLine("ATTACK");
        }

        public void Next()
        {

        }
    }

    class StreyState : IState
    {
        public void Do()
        {
            Console.WriteLine
        }
    }
}
