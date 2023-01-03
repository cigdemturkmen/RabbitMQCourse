
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//My Notes
// subscriber/consumer
// autoAck >>> auto acknowledge: when RabbitMQ ackknowledges that the message is received by the subscriber, the msg in the queue will be deleted automatically if autoAck == true. If false, you have to tell the queue when to delete the msg.
// In real life, make autoAck false because we dont want the msg to be deleted whether it is processed wrong. We want to make sure if it is processed correctly and then we can delete the msg in the queue.
// we can create the queue either in producer app or consumer app. If declared on both, QueueDeclare() parameters must be identical on both.
// otherwise, error will be thrown. If you are sure that the channel is declared in producer. You dont have to declare it here too.
var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://bmvwpzdl:oMIUQ5m6Gp7WXOkXwXHFsXF_unEXMC1l@chimpanzee.rmq.cloudamqp.com/bmvwpzdl");

using var connection = factory.CreateConnection();

var channel = connection.CreateModel(); // IModel

// channel.QueueDeclare("hello-queue", true, false, false);

var consumer = new EventingBasicConsumer(channel);

channel.BasicConsume("hello-queue", true, consumer);

consumer.Received += (object sender, BasicDeliverEventArgs e) =>
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());

    Console.WriteLine("Message: " + message);
};

Console.ReadLine();