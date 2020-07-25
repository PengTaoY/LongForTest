
using System;

namespace DelegatExample
{
    public delegate double Calc(double x, double y);
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Calc calc1 = new Calc(calculator.Add);
            double x = 100;
            double y = 200;
            double c;

            c = calc1.Invoke(x, y);
            Console.WriteLine(c);




            Console.WriteLine("Hello World!");
        }
    }

    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Muli(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
    }
}
