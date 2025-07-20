using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace KafkaChatApp
{
    public class ChatPublisher
    {
        public static async Task RunAsync()
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using var producer = new ProducerBuilder<Null, string>(config).Build();

            Console.WriteLine("Enter message (type 'exit' to quit):");
            while (true)
            {
                var msg = Console.ReadLine();
                if (msg?.ToLower() == "exit") break;

                await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = msg });
                Console.WriteLine($"Message sent: {msg}");
            }
        }
    }
}
