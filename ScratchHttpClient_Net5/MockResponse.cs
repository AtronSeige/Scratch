//using Newtonsoft.Json;
//using System;
//using System.IO;
//using System.Net;
//using System.Net.Sockets;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

//namespace ScratchHttpClient {
//	//Source: https://stackoverflow.com/a/25015432/375114
//	internal class MockResponse {

//		private JsonSerializerSettings jss;

//		public MockResponse() {
//			jss = new JsonSerializerSettings();
//			jss.NullValueHandling = NullValueHandling.Include;
//			jss.MissingMemberHandling = MissingMemberHandling.Ignore;
//			jss.ObjectCreationHandling = ObjectCreationHandling.Replace;
//		}


//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="httpStatus"></param>
//		/// <param name="responseObject"></param>
//		/// <returns></returns>
//		public WebResponse CreateWebResponse(HttpStatusCode httpStatus, MemoryStream responseObject) {
//			TcpListener l = new TcpListener(IPAddress.Loopback, 0);
//			l.Start();
//			int port = ((IPEndPoint)l.LocalEndpoint).Port;
//			l.Stop();

//			// Create a listener.
//			string prefix = "http://localhost:" + port + "/";
//			HttpListener listener = new HttpListener();
//			listener.Prefixes.Add(prefix);

//			try {
//				listener.Start();
//				listener.BeginGetContext((ar) => {
//					HttpListenerContext context = listener.EndGetContext(ar);
//					HttpListenerRequest request = context.Request;

//					// Obtain a response object.
//					HttpListenerResponse response = context.Response;

//					response.StatusCode = (int)httpStatus;

//					// Construct a response.
//					if (responseObject != null) {
//						byte[] buffer = responseObject.ToArray();

//						// Get a response stream and write the response to it.
//						Stream output = response.OutputStream;
//						output.Write(buffer, 0, buffer.Length);
//					}

//					response.Close();
//				}, null);

//				WebClient client = new WebClient();
//				try {
//					WebRequest request = WebRequest.Create(prefix);
//					request.Timeout = 30000;
//					return request.GetResponse();
//				} catch (WebException e) {
//					return e.Response;
//				}
//			} finally {
//				listener.Stop();
//			}
//		}

//		public HttpWebResponse GetFakeHttpWebResponse(HttpStatusCode httpStatus, MemoryStream responseObject) {

//			TcpListener l = new TcpListener(IPAddress.Loopback, 0);
//			l.Start();
//			int port = ((IPEndPoint)l.LocalEndpoint).Port;
//			l.Stop();

//			// Create a listener.
//			string prefix = "http://localhost:" + port + "/";
//			using (HttpListener listener = new HttpListener()) {
//				listener.Prefixes.Add(prefix);

//				try {
//					listener.Start();
//					listener.BeginGetContext((ar) => {
//						HttpListenerContext context = listener.EndGetContext(ar);
//						HttpListenerRequest request = context.Request;

//						// Obtain a response object.
//						HttpListenerResponse response = context.Response;

//						response.StatusCode = (int)httpStatus;

//						// Construct a response.
//						if (responseObject != null) {
//							byte[] buffer = responseObject.ToArray();

//							// Get a response stream and write the response to it.
//							using (Stream output = response.OutputStream) {
//								output.Write(buffer, 0, buffer.Length);
//							}
//						}

//						response.Close();
//					}, null);

//#pragma warning disable SYSLIB0014 // Type or member is obsolete
//					using (WebClient client = new WebClient()) {
//						WebResponse wr = null;
//						try {
//							WebRequest request = WebRequest.Create(prefix);
//							request.Timeout = 30000;
//							wr = request.GetResponse();

//							//HttpWebResponse wr2 = SerializationTesttoHttpWebResponse(wr);
//							//return wr2;

//							//WebResponse wr2 = SerializationTestToWebResponse(wr);
//							//return (HttpWebResponse)wr2;
							
//							//MockWebResponse wr2 = SerializationTestToMockWebResponse(wr);
							
//							HttpWebResponse wr2 = MockWebResponseTest(wr);
//							return wr2;

//							//HttpWebResponse wr2 = SerializationTest(wr);



//						} catch (WebException e) {
//							wr = e.Response;
//						}

//						return (HttpWebResponse)wr;
//					}
//#pragma warning restore SYSLIB0014 // Type or member is obsolete

//				} finally {
//					listener.Stop();
//				}
//			}
//		}

//		private WebResponse SerializationTestToWebResponse(WebResponse response) {
//			if (response is null) {
//				throw new ArgumentNullException(nameof(response));
//			}

//			try {

//				string json = JsonConvert.SerializeObject(response, Formatting.Indented, jss);

//				Console.WriteLine(json);

//				// Try to deserialize into WebResponse
//				WebResponse wr = JsonConvert.DeserializeObject<WebResponse>(json,jss);

//				return wr;

//			} catch (Exception up) {
//				Console.WriteLine(up.ToString());
//				throw up;
//			}
//		}

//		private HttpWebResponse SerializationTesttoHttpWebResponse(WebResponse response) {
//			if (response is null) {
//				throw new ArgumentNullException(nameof(response));
//			}

//			try {

//				JsonSerializerSettings jss = new JsonSerializerSettings();
//				jss.NullValueHandling = NullValueHandling.Include;


//				string json = JsonConvert.SerializeObject(response, Formatting.Indented, jss);

//				Console.WriteLine(json);

				
//				// Try to deserialize into HttpWebResponse
//				HttpWebResponse hwr = JsonConvert.DeserializeObject<HttpWebResponse>(json, jss);

//				return hwr;


//			} catch (Exception up) {
//				Console.WriteLine(up.ToString());
//				throw up;
//			}
//		}

//		private MockWebResponse SerializationTestToMockWebResponse(WebResponse response) {
//			if (response is null) {
//				throw new ArgumentNullException(nameof(response));
//			}

//			try {

//				MockWebResponse mwr = new MockWebResponse();
//				mwr = (MockWebResponse)response;

//				string json = JsonConvert.SerializeObject(mwr, Formatting.Indented, jss);

//				Console.WriteLine(json);

//				// Try to deserialize into HttpWebResponse
//				MockWebResponse hwr = JsonConvert.DeserializeObject<MockWebResponse>(json, jss);

//				return hwr;


//			} catch (Exception up) {
//				Console.WriteLine(up.ToString());
//				throw up;
//			}
//		}

//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="response"></param>
//		/// <returns></returns>
//		/// <exception cref="ArgumentNullException"></exception>
//		/// <remarks>https://docs.microsoft.com/en-us/dotnet/framework/network-programming/deriving-from-webresponse</remarks>
//		private HttpWebResponse MockWebResponseTest(WebResponse response) {
//			if (response is null) {
//				throw new ArgumentNullException(nameof(response));
//			}

//			try {

//				//SerializationInfo si = new SerializationInfo(typeof(MockType), (Ifnew BinaryFormatter() );

//				MockWebResponse mwr = new MockWebResponse();

//				mwr.Headers.Add("hi");
//				mwr.ContentType = "application/json";
				
//				WebResponse wr = (WebResponse)mwr;

//				// this breaks. :(
//				HttpWebResponse hwr = (HttpWebResponse)wr;

//				return hwr;


//			} catch (Exception up) {
//				Console.WriteLine(up.ToString());
//				throw up;
//			}
//		}

//		public class MockWebResponse : WebResponse {

			
//			public override long ContentLength { get; set; }
			
//			public override string ContentType { get; set; }
			
//			public override WebHeaderCollection Headers { get; }
			
//			public override bool IsFromCache { get; }
			
//			public override bool IsMutuallyAuthenticated { get; }
			
//			public override Uri ResponseUri { get; }
			
//			public override bool SupportsHeaders { get; }

//			public override void Close() { 
//				base.Close();
//			}
			
//			public override Stream GetResponseStream() {
//				return base.GetResponseStream();
//			}
			
//			protected override void Dispose(bool disposing) {
//				base.Dispose(disposing);
//			}
			
//			protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext) {
//				base.GetObjectData(serializationInfo, streamingContext);
//			}



//			public MockWebResponse() : base() {

//			}

//			public MockWebResponse(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) {
//			}
//		}

//		public class MockType {
//			public int ID { get; set; }
//			public string Bubbles { get; set; }
//		}
//	}
//}
