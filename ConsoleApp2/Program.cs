using System;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);

                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }



            Console.WriteLine("Hello World!");
        }

        class TestModel
        {
            public string Name { get; set; }

            public int Id { get; set; }
        }
    }
}
