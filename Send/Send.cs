using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMQFactory = new ConnectionFactory()
            {
                HostName = "4725.13",
                Port = 5672,
                UserName = "",
                Password = ""
            };
            using (var connection = rabbitMQFactory.CreateConnection())
            //创建信道
            using (var channel = connection.CreateModel())
            {
                //声明一个队列
                channel.QueueDeclare(queue: "world",  //消息队列名称
                                    durable: false,     //是否缓存
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
                string message = "";
                while (message != "exit")
                {
                    Console.WriteLine("请输入消息内容：");
                    message = Console.ReadLine();
                    //消息内容
                    var body = Encoding.UTF8.GetBytes(message);
                    //发送消息
                    channel.BasicPublish(exchange: "",
                                        routingKey: "world",
                                        basicProperties: null,
                                        body: body);
                    Console.WriteLine($" [x] Sent {message}");
                }


            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
