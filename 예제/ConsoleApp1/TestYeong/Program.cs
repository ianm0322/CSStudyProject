using System;

namespace TestYeong
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMethod();
            Console.WriteLine("忍殺");
        }

        static void TestMethod()
        {
            using (var item = new Test())
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 50)
                        return;
                }
            }
        }
    }

    class Test : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("야! 라! 레! 타!");
        }
    }
}
