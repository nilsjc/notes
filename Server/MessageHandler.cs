using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Server
{
    public class MessageHandler : IMessageHandler
    {
        private readonly ConnectionFactory _factory;
        private readonly IAsyncBasicConsumer _basicConsumer;
        public MessageHandler()
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
        }
        public async Task<Message> GetMessageFromQueue(string queue)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            throw new NotImplementedException();
        }

        public async void PutMessageOnQueue(Message message, string queue)
        {
            var jsonMessage = System.Text.Json.JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonMessage);
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queue, body: body);
        }
    }
}
/*
var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
    arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
    return Task.CompletedTask;
};

await channel.BasicConsumeAsync("hello", autoAck: true, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
*/