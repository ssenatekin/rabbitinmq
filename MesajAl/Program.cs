using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MesajAl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri=new Uri("amqps://xwkhbjsj:hJB6iqSOkuL9iRqDGbm7YyCR3LeHwG7h@octopus.rmq3.cloudamqp.com/xwkhbjsj");
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuyruk", true, false, false);

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("mesaj-kuyruk",true,consumer);

            consumer.Received += Consumer_Received;
            Console.ReadLine();

        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Gelen Mesaj:" + Encoding.UTF8.GetString(e.Body.ToArray()));
           
        }
    }
}
