using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string channelKey = "33";
            List<string> ls = new List<string>
            {
                "C1","C2"
            };
            bool contains = ls.Contains(channelKey);









            for (double i = 1.0; i <= 2.0;)
            {
                Console.WriteLine($" {i}\t    {(int)i}");

                i += 0.1;
            }
            Console.WriteLine("*****************************");
            for (double i = 1.0; i <= 2.0;)
            {

                Console.WriteLine($" {i}\t    {Math.Round(i)}");

                i += 0.1;
            }

            Console.WriteLine(-.25 == -0.25);

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
