using RabbitMQ.Client;
using System.Text;

//My Notes
// puslisher/producer
// we normally keep the uri in appsettings.json
// durable true >>> queues are saved physically. If rabbitmq restarts no queues will be lost. 
// durable false >>>  queues are kept on memory. If rabbitmq restarts all queues will be lost.
// exclusive true >>> making a queue exclusive makes is accesible only from the channel it is created.
// autoDelete true >>> If the last consumer that is connected to the queue is down, the queue will be deleted automatically.

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://bmvwpzdl:oMIUQ5m6Gp7WXOkXwXHFsXF_unEXMC1l@chimpanzee.rmq.cloudamqp.com/bmvwpzdl");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel(); // We will connect to rabbitMQ through a channel.

channel.QueueDeclare("hello-queue", true, false, false);

string msg = "hello world";

var messageBody = Encoding.UTF8.GetBytes(msg);

channel.BasicPublish(string.Empty,"hello-queue",null,messageBody);

Console.WriteLine("Message sent");

Console.ReadLine();

