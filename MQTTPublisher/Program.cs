using MQTTnet;
using MQTTnet.Client;

namespace MQTTPublisher
{
    public class Program
    {
        static async Task Main()
        {
            var mqttFactory = new MqttFactory();
            var mqttClient = mqttFactory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
              .WithTcpServer("localhost", 1883) // connect to local broker
              .WithClientId("PublisherClient")
              .Build();

            await mqttClient.ConnectAsync(options);
            Console.WriteLine("Publisher connected.");

            var message = new MqttApplicationMessageBuilder()
               .WithTopic("test/topic")
               .WithPayload("Hello from Publisher!")
               .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
               .Build();

            await mqttClient.PublishAsync(message);
            Console.WriteLine("Message published.");

            await mqttClient.DisconnectAsync();
        }
    }
}
