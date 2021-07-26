using ScratchNamedPipeSeverEntities;
using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;

namespace ScratchNamedPipeSeverReceiver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //StartStringReceiver();
            StartMessageReceiver();
        }

        private static void StartStringReceiver()
        {
            Console.WriteLine("I am the string receiver!");
            var server = new NamedPipeServerStream("TestNPString");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            while (true)
            {
                var line = reader.ReadLine();
                if (line != null)
                    Console.WriteLine("Reversed: " + String.Join("", line.Reverse()));
                //writer.WriteLine("Received");
                //writer.Flush();
            }
        }

        private static void StartMessageReceiver()
        {
            Console.WriteLine("I am the messagereceiver!");
            var server = new NamedPipeServerStream("TestNPMessage");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            while (true)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var m = Message.Deserialize(line);
                    Console.WriteLine($"Raw: {line}");
                    Console.WriteLine($"Message: [{m.Id}] [{m.DateSent}] [{m.Value}]");
                }
                //writer.WriteLine("Received");
                //writer.Flush();
            }
        }



        private void SetupConnection()
        {

        }
    }
}
