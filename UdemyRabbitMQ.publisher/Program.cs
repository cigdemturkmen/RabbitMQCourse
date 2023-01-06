using RabbitMQ.Client;
using System.Text;

//My Notes
// puslisher/producer
// we normally keep the uri in appsettings.json
// If we send the msg directly to the queue, it is the default exchange.
// (queue)durable true >>> queues are saved physically. If rabbitmq restarts no queues will be lost. 
// (queue)durable false >>>  queues are kept on memory. If rabbitmq restarts all queues will be lost.
// (queue)exclusive true >>> making a queue exclusive makes is accesible only from the channel it is created.
// (queue)autoDelete true >>> If the last consumer that is connected to the queue is down, the queue will be deleted automatically.

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://bmvwpzdl:oMIUQ5m6Gp7WXOkXwXHFsXF_unEXMC1l@chimpanzee.rmq.cloudamqp.com/bmvwpzdl");

using var connection = factory.CreateConnection(); // we can create multiple channels over one connection

var channel = connection.CreateModel(); // We will connect to rabbitMQ through a channel.

channel.QueueDeclare("hello-queue", true, false, false); // we can create the queue either in producer app or consumer app. If declared on both, QueueDeclare() parameters must be identical on both. otherwise, error will be thrown.


// sending 50 messages to the queue.
Enumerable.Range(1, 50).ToList().ForEach(x =>
{
    string msg = $"Message {x}";

    var messageBody = Encoding.UTF8.GetBytes(msg);

    channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);

    Console.WriteLine($"Message sent: {msg} ");
});

Console.ReadLine();

