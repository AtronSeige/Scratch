using ScratchNamedPipeSeverEntities;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace ScratchNamedPipeSeverSender
{
    class Program
    {


        static void Main(string[] args)
        {
            //wait a bot for the server to start
            Task.Delay(1000).Wait();

            //StartSender();
            StartMessageSender();
        }

        static void StartSender()
        {
            Console.WriteLine("I am the sender");
            //Client
            var client = new NamedPipeClientStream("TestNPString");
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            while (true)
            {
                Console.WriteLine("Type something and press enter");
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) break;
                writer.WriteLine(input);
                writer.Flush();
                //Console.WriteLine(reader.ReadLine());
            }
        }

        static void StartMessageSender()
        {
            Console.WriteLine("I am the sender");
            //Client
            var client = new NamedPipeClientStream("TestNPMessage");
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            int id = 1;

            while (true)
            {
                var m = new Message() { Id = id, DateSent = DateTime.Now, Value = DateTime.Now.ToString() };
                id++;
                //Console.WriteLine("Type something and press enter");
                //string input = Console.ReadLine();
                if (id > 10) break;
                writer.WriteLine(m.Serialize());
                writer.Flush();
                //Console.WriteLine(reader.ReadLine());
            }
        }

        void CheckForMessage()
        {

        }

        void ProcessMessage()
        {

        }
    }
}
