using System;
using System.IO;
using System.Net;
using System.Text;

namespace ScratchHttpClient {
	internal class App {

		private string estar = "https://www.estaronline.com";

		public App() {
		}

		internal void Run() {
			//Test1();
			//Test2();
			//Test3();
			//Test4();
			Test5();
		}

		//private static void Test1() {
		//	string url = "https://uat.test.local/some/other/page?page=0&per_page=1&updated_since=2";

		//	HttpClient client = new HttpClient();
		//	client.BaseAddress = new Uri(url);

		//	HttpResponseMessage response = client.GetAsync("").Result;
		//}

		//private void Test2() {
		//	MockResponse mr = new MockResponse();

		//	WebResponse webResponse = mr.CreateWebResponse(HttpStatusCode.OK, null);

		//	if (webResponse != null) {
		//		Console.WriteLine("YAY!!!! for CreateWebResponse");
		//	} else {
		//		Console.WriteLine("sadness for CreateWebResponse");
		//	}
		//}



		//private void Test3() {
		//	HttpWebResponse response = MockWebResponse();

		//	if (response != null) {
		//		Console.WriteLine("YAY!!!!");
		//	} else {
		//		Console.WriteLine("sadness");
		//	}
		//}

		//private HttpWebResponse MockWebResponse() {
		//	HttpClient client = new HttpClient();

		//	HttpResponseMessage meg = client.GetAsync(estar).Result;

		//	HttpWebResponse response = null;

		//	return response;
		//}


		//private void Test4() {
		//	MockResponse mr = new MockResponse();

		//	HttpWebResponse httpWebResponse = mr.GetFakeHttpWebResponse(HttpStatusCode.OK, null);

		//	if (httpWebResponse != null) {
		//		Console.WriteLine("YAY!!!! for MockHttpWebResponse");
		//	} else {
		//		Console.WriteLine("sadness for MockHttpWebResponse");
		//	}
		//}

		private void Test5() {

			string response = "my response string here";
			WebRequest.RegisterPrefix("test", new TestWebRequestCreate());
			TestWebRequest request = TestWebRequestCreate.CreateTestRequest(response);
			string url = "test://MyUrl";

			WebResponse wr = null;
			try {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
				WebRequest wReq = WebRequest.Create(url);
#pragma warning restore SYSLIB0014 // Type or member is obsolete

				using (WebResponse gresponse = wReq.GetResponse()) {
					using (Stream responseStream = gresponse.GetResponseStream()) {
						using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8)) {
							string output = reader.ReadToEnd();
							Console.WriteLine(output);
						}
					}
				}
			} catch (WebException e) {
				wr = e.Response;
			}
		}
	}
}