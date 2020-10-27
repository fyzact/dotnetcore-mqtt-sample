using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT.Sample.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            //create client istance
            MqttClient client = new MqttClient("localhost", 1883, false, MqttSslProtocols.None, null, null);
            string clientId = Guid.NewGuid().ToString();
            //connected
            client.Connect(clientId, "mqtt-test", "mqtt-test");

            while (true)
            {
                //publis message
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message)) break;
                client.Publish("/home/test1", Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
