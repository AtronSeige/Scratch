using System;
using System.Net.Http;

namespace ScratchHttpClient_Net5 {
	internal class App {
		public App() {
		}

		internal void Run() {

			string url = "https://uat.test.local/some/other/page?page=0&per_page=1&updated_since=2";

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);

			HttpResponseMessage response = client.GetAsync("").Result;
		}
	}
}