using RabbitMQ.Client;
using System;
using System.Text;

namespace Gonder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                MesajGonder();
            }
        }

        
        public static void MesajGonder()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://xwkhbjsj:hJB6iqSOkuL9iRqDGbm7YyCR3LeHwG7h@octopus.rmq3.cloudamqp.com/xwkhbjsj");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuyruk", true, false, false);
            var mesaj = "Sena Tekin Mesaj.";
            var body = Encoding.UTF8.GetBytes(mesaj);
            channel.BasicPublish(String.Empty, "mesaj-kuyruk", null, body);

            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
