using System.Net;

// Using WebRequest is deprecated. Use HTTPClient

Console.WriteLine("Hello");

HttpWebResponse response = MockHttpWebResponse();

if (response != null) {
	Console.WriteLine("Yay!");

} else {
	Console.WriteLine(":(");
}

Console.WriteLine("Done");
Console.ReadLine();

HttpWebResponse MockHttpWebResponse() {

	//HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("https://localhost");

	//HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
	//// Insert code that uses the response object.
	//HttpWResp.Close();

	//return HttpWResp;
	return null;
}