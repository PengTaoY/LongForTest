using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMQFactory = new ConnectionFactory()
            {
                HostName = "4",
                Port = 5672,
                UserName = "",
                Password = ""
            };
            using (var connection = rabbitMQFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue:"hello",
                                        durable:false,
                                        exclusive:false,
                                        autoDelete:false,
                                        arguments:null
                        );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                      {
                          var body = ea.Body.ToArray();
                          var message = Encoding.UTF8.GetString(body);
                          Console.WriteLine($" [x] Received {message}");
                      };
                    channel.BasicConsume(queue: "hello",
                                        autoAck: true,
                                        consumer: consumer
                                        );
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }

        }
    }
}
