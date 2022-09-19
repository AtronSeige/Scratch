using System.Net;
using System.Text;

try {

	//HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://fake.fak");
	//request.Method = "Get";
	//using (WebResponse gresponse = request.GetResponse()) {
	//	using (Stream responseStream = gresponse.GetResponseStream()) {
	//		using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8)) {
	//			string output = reader.ReadToEnd();
	//			Console.WriteLine(output);
	//		}
	//	}
	//}

	//HttpWebRequest request = (HttpWebRequest)HttpClient.Create("GetManifest");

	//HttpWebResponse response = (HttpWebResponse)request.GetResponse();

	//using (WebResponse gresponse = request.GetResponse()) {
	//	using (Stream responseStream = gresponse.GetResponseStream()) {
	//		using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8)) {
	//			string output = reader.ReadToEnd();
	//			Console.WriteLine(output);
	//		}
	//	}
	//}



} catch (Exception ex) {
	Console.WriteLine(ex.Message);
}

Console.WriteLine("Done");

Console.ReadLine();


//HttpWebRequest r = (HttpWebRequest)WebRequest.Create("http://www.demo.com");
//r.Method = "Get";
//HttpWebResponse res = (HttpWebResponse)r.GetResponse();
//Stream sr = res.GetResponseStream();
//StreamReader sre = new StreamReader(sr);

//string s = sre.ReadToEnd();
//Response.Write(s);



//private string OpenWebPage(string url) {
//	string response = string.Empty;
//	try {
//		HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(url);
//		HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
//		if (webresp.StatusCode == HttpStatusCode.OK) {
//			StreamReader strm = new StreamReader(webresp.GetResponseStream(), Encoding.UTF8);
//			response = strm.ReadToEnd();
//		}
//	} catch (Exception e) {
//		HandleException(e);
//	}
//	return response;
//}

//// Create a POST request to send our JSON payload
//var httpWebRequest = WebRequest.CreateHttp(url);
//httpWebRequest.ContentType = "application/json";
//httpWebRequest.Method = "POST";
//// set timeout to 5 seconds
//httpWebRequest.Timeout = 5000; // in milliseconds.
//using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
//	streamWriter.Write(payloadJson);
//	streamWriter.Flush();
//	streamWriter.Close();
//}
//// Send the request
//var response = (HttpWebResponse)httpWebRequest.GetResponse();


//HttpWebRequest wr = WebRequest.Create(Url) as HttpWebRequest;
//wr.Headers.Add("SOAPAction", SOAPAction);
//wr.ContentLength = content.Length;
//wr.Method = "POST";
//wr.ContentType = "text/XML;charset=utf-8";
//if (GZip) {
//	wr.AutomaticDecompression = DecompressionMethods.GZip;  // This may work for some actions that return the correct headers.
//															// It is harmless if the API methods are unable to interpret a response as GZip.
//	wr.Headers.Add("Accept-Encoding", "gzip,deflate");
//}
//wr.GetRequestStream().Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
//return wr;


//private HttpWebResponse GetResponse(HttpWebRequest request, string content = null) {
//	// Use the configured proxy, if any.
//	if (Proxy != null) {
//		request.Proxy = Proxy;
//	}

//	// Submit request body, if any.
//	if (content != null) {
//		byte[] requestContent = Encoding.UTF8.GetBytes(content);
//		request.ContentLength = requestContent.Length;

//		using (Stream requestStream = request.GetRequestStream()) {
//			requestStream.Write(requestContent, 0, requestContent.Length);
//		}
//	}
//	return (HttpWebResponse)request.GetResponse();
//}