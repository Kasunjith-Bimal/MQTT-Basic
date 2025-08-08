using MQTTnet;
using MQTTnet.Client;
using System.Text;

namespace MQTTSubscriber
{
    public class Program
    {
        static async Task Main()
        {
            var mqttFactory = new MqttFactory();
            var mqttClient = mqttFactory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .WithClientId("SubscriberClient")
                .Build();

            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"[Received] Topic: {e.ApplicationMessage.Topic}, Message: {payload}");
                return Task.CompletedTask;
            };

            await mqttClient.ConnectAsync(options);
            Console.WriteLine("Subscriber connected.");

            await mqttClient.SubscribeAsync("test/topic");
            Console.WriteLine("Subscribed to test/topic");

            Console.ReadLine(); // keep app running
        }
    }
}
