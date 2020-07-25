using System;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Action action = new Action(calculator.Report);
            calculator.Report();
            action.Invoke();

            Func<int, int, int> funcAdd = new Func<int, int, int>(calculator.Add);
            int x = 100;
            int y = 200;

            int z = funcAdd.Invoke(x, y);
            Console.WriteLine(z);

            Console.WriteLine("Hello World!");
        }

        class Calculator
        {
            public void Report()
            {
                Console.WriteLine("This is a void func");
            }

            public int Add(int a, int b)
            {
                return a + b;
            }

        }


    }
}
