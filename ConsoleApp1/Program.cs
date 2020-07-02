using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            TestModel testModel = new TestModel
            {
                Name = "张三",
                Id = 3
            };
            Console.WriteLine(nameof(testModel));


            Console.WriteLine("Hello World!");
        }

        class TestModel
        {
            public string Name { get; set; }

            public int Id { get; set; }
        }
    }
}
