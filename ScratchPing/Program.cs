using System;
using System.Net.NetworkInformation;

namespace ScratchPing
{
	class Program
	{
        static void Main(string[] args)
        {
            if (PingHost("hex"))
            {
                System.Console.WriteLine("I could ping HEX!");
            }

            Console.ReadLine();
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}
