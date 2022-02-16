using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScratchNetworking {
	internal class App {
		public App() {
			
		}

		public void Run() {
			IPtoDecimal("127.0.0.1");
			IPtoDecimal("192.168.1.1");
			IPtoDecimal("10.0.0.1");
			IPtoDecimal("255.255.255.255");

			Console.ReadLine();
		}

		private void IPtoDecimal(string ipAddress) {

			decimal ip = 0;

			//Test if you can convert the ip address to a real address
			if (IPAddress.TryParse(ipAddress, out IPAddress addr)) {
				// is the address in the correct AddressFamily (Address for IP version 4.)
				if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
					ip = (decimal)(uint)IPAddress.NetworkToHostOrder(System.BitConverter.ToInt32(addr.GetAddressBytes(), 0));
				}
			}

			Console.WriteLine($"IP Address {ipAddress} converted to Decimal is {ip}");
			
			
		}
	}
}
