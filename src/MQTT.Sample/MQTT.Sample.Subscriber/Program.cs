using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT.Sample.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient client = new MqttClient("localhost", 1883, false, MqttSslProtocols.None, null, null);

            string clientId = Guid.NewGuid().ToString();
            byte f = client.Connect(clientId, "mqtt-test", "mqtt-test");

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // subscribe to the topic
            client.Subscribe(new string[] { "/home/test1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            Console.ReadKey();
        }
        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = System.Text.Encoding.UTF8.GetString(e.Message);
            Console.WriteLine(message);
        }
    }
}
