using MQTTnet;
using MQTTnet.Server;

namespace MQTTBroker
{
    public class Program
    {
        static async Task Main()
        {
            var mqttFactory = new MqttFactory();
            // Build server options
            var serverOptions = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithDefaultEndpointPort(1883)
                .Build();

            // Create server with options
            var mqttServer = mqttFactory.CreateMqttServer(serverOptions);

            // Start server
            await mqttServer.StartAsync();
            Console.WriteLine("Broker running on port 1883. Press Enter to exit...");
            Console.ReadLine();

            // Stop server
            await mqttServer.StopAsync();
        }
    }
}
