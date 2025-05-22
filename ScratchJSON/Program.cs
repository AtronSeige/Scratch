using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace ScratchJSON {
	internal class Program {
		static void Main(string[] args) {

			//XmlToJson();
			//QueryJson();
			//CreateJson();
			//JObjectExcception();
			//DeserializeXmlNode(null);
			//DeserializeXmlNode(string.Empty);
			//DeserializeXmlNode("{}");
			//DeserializeXmlNode("<html/>");
			//DeserializeXmlNode();
			//DeserializeXmlNode();
			//RawToObject();

			CreateJsonFile();
			ReadJsonFile();
			SerializeObjectToJson();
			DeserializeJsonToTestClass();

			Console.ReadLine();
		}

		

		private static void DeserializeXmlNode(string responseBody) {
			try {
				XmlDocument doc = JsonConvert.DeserializeXmlNode(responseBody ?? string.Empty, "ProntoAvenueResponse");
			}catch (Exception ex) {
				Console.WriteLine(ex);
			}

		}

		static void XmlToJson() {

			XmlDocument doc = new();

			doc.LoadXml("<prontoorder xmlns:jsonns=\"http://james.newtonking.com/projects/json\"><customer_reference>11932</customer_reference><account_code>0033014</account_code><warehouse_code>201</warehouse_code><priority_code>5</priority_code><rep_code>FEM</rep_code><territory_code>310</territory_code><date>04-03-2022</date><addresses xmlns:jsonns=\"http://james.newtonking.com/projects/json\" jsonns:Array=\"true\"><address_type>DA</address_type><address1 /><address2>1 queen str</address2><address4>CDB</address4><address5>VIC</address5><address6>AUS</address6><address7>Melbourne</address7><postcode>3000</postcode><phone>123456789</phone></addresses><lines xmlns:jsonns=\"http://james.newtonking.com/projects/json\" jsonns:Array=\"true\"><line_type>SN</line_type><external_id>3011</external_id><item_code>165837BLAXS</item_code><item_price>440.0000</item_price><item_price_tax_code>T</item_price_tax_code><ordered_qty>1</ordered_qty></lines><lines xmlns:jsonns=\"http://james.newtonking.com/projects/json\" jsonns:Array=\"true\"><line_type>SC</line_type><item_price>0.0000</item_price><item_price_tax_code>T</item_price_tax_code><charge_type_flag>0</charge_type_flag><line_description>Standard Delivery</line_description></lines><payments xmlns:jsonns=\"http://james.newtonking.com/projects/json\" jsonns:Array=\"true\"><amount>440.0000</amount><store_id>310</store_id><terminal_no>1</terminal_no><money_type>V</money_type></payments></prontoorder>");

			string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

			Console.WriteLine(json);
		}

		static void QueryJson() {
			string json = @"{'invoice_no':'      11932','status_code':'17','lines':[{'sequence':1,'type':'SN','external_id':3011},{'sequence':2,'type':'SC'}],'order_number':'11932','result':'Order inserted with status of \'Rdy to Print Invoice\''}";

			JObject jsonObject = JObject.Parse(json);

			Console.WriteLine("invoice_no: " + (string)jsonObject["invoice_no"]);
			Console.WriteLine("result: " + (string)jsonObject["result"]);

			JArray lines = (JArray)jsonObject["lines"];
			foreach (JObject line in lines) {
				Console.WriteLine("sequence: " + (string)line["sequence"]);
				Console.WriteLine("type: " + (string)line["type"]);
				Console.WriteLine("external_id: " + (string)line["external_id"]);
			}
		}

		static void CreateJson() {
			string test1 = "hi";
			int test2 = 2;
			JObject jsonObject = new JObject();
			jsonObject.Add(new JProperty("greet", test1));
			jsonObject.Add(new JProperty("num", test2));

			Console.WriteLine(jsonObject.ToString());
			Console.WriteLine("done");
		}

		static void ConvertClassToJSON() {
			TestClass tc = new TestClass();
			tc.ID = 1;
			tc.Name = "Jaco";

			TestClass2 tc2_ZA = new TestClass2();
			tc2_ZA.ID = 1;
			tc2_ZA.Value = "ZA";

			TestClass2 tc2_NZ = new TestClass2();
			tc2_NZ.ID = 1;
			tc2_NZ.Value = "NZ";

		}

		static void JObjectExcception() {

			try {
				

				string json;
				JObject jsonObject;

				// This throws System.ArgumentNullException
				//json = null;
				//jsonObject = JObject.Parse(json);

				// This throws Newtonsoft.Json.JsonReaderException
				//json = "";
				//jsonObject = JObject.Parse(json);

				// Invalid JSON.
				// This throws Newtonsoft.Json.JsonReaderException

				json = "{\"hello\":\"";
				jsonObject = JObject.Parse(json);

				json = "{\"Message\": {\"Code\": \"500\", \"Description\": \"Invalid Username or Password\"},\"Payload\": { \"ClaimID\": 0, \"Username\": \"duskd2c.viare.ws@consortiumclemenger.com.au\", \"Password\": \"***REDACTED***\", \"AuthenticationToken\": \"00000000-0000-0000-0000-000000000000\", \"AccountID\": 34468, \"CampaignClaim\": null}}";

				 jsonObject = JObject.Parse(json);


				string code = jsonObject?["Message"]?["Code"]?.Value<string>();
				string what = jsonObject?["Message"]?["what"]?.Value<string>();
				string ooh = jsonObject?["ooh"]?["what"]?.Value<string>();

			} catch (Exception ex) {
				Console.WriteLine($"Shits fucked: {ex}");
			}

		}

		static void CreateJsonFile() {
			// Create a new json file in the Resources folder.
			if (!Directory.Exists("Resources")) {
				Directory.CreateDirectory("Resources");
			}
			string json = "{\"hello\":\"world\"}";
			File.WriteAllText("Resources\\test.json", json);
		}

		static void ReadJsonFile() {
			// Read a json file from the Resources folder.
			string json = File.ReadAllText("Resources\\test.json");
			Console.WriteLine(json);
		}

		static void DeserializeJsonToTestClass() {
			// Deserialize the json file to a TestClass object.
			string json = File.ReadAllText("Resources\\test.json");
			TestClass tc = JsonConvert.DeserializeObject<TestClass>(json);
			Console.WriteLine(tc.Name);
			Console.WriteLine(tc.TC2.First().Value);
		}

		static void SerializeObjectToJson() {

			if (!Directory.Exists("Resources")) {
				Directory.CreateDirectory("Resources");
			}

			if (File.Exists("Resources\\test.json")) {
				File.Delete("Resources\\test.json");
			}

			TestClass tc = new() {
				ID = 1,
				Name = "Jaco"
			};
			TestClass2 tc2_ZA = new() {
				ID = 1,
				Value = "ZA"
			};
			TestClass2 tc2_NZ = new (){
				ID = 1,
				Value = "NZ"
			};
			tc.TC2 = [tc2_ZA, tc2_NZ];

			string json = JsonConvert.SerializeObject(tc);
			File.WriteAllText("Resources\\test.json", json);
		}

		public class TestClass {
			public int ID { get; set; }
			public string Name { get; set; }
			public List<TestClass2> TC2 { get; set; }
		}

		public class TestClass2 {
			public int ID { get; set; }

			public string Value { get; set; }
		}

		private static void RawToObject() {
			// Populate the Response object.

			string content = "{\"status\": \"OK\",\"placements\": [{\"viewCategoryApiDesktop-CategoryDesktop_sp1\": [{\"format\": \"sponsored_products\",\"products\": [{\"ProductName\": \"Country Road Puffer Jacket\",\"ProductId\": \"22363680\",\"ProductPage\": \"//b.sg1.as.criteo.com/rm?dest=https%3a%2f%2fwww.uat.davidjones.com%2fProduct%2f22351154&sig=1-BH1g6Z2k1J1oy0vcLaatNFFI8OFjToSJDuyv1C0Xecw&rm_e=OCiPyTiQrnxu7MW72ho2BhG6hfZI7R3QDtEVa4Tm5FgQkRXDspChhWI-lhSqas2sn-mz5HtjLzyXHRwUNNM9HfaKBXY9RhLrLvTaP3KtbOe36EC_kThmGsr7y8PVuRw7kaEHPAP83560lzdJgRxUGxbZcRYFC39zN-RGdmfnEANUEV1D4IcAbnI6_HY2o3MRBS1c4tCUMMKRQQaUIe5HZjlTPbF9UY4vBhaeo_yO3f-83MssZN0yIvpgHoXdjBYcddxmXxiFWb1XU9IB75QdtpIUsyLhUhhQnRM_PJTLGYQBX5OyHBqc06Vbb2hcs0Mk9myPrZWfF7bK2ITq1PyxRh7fAKXJZPJmfBhCWXnZqurTaARKv9l0Ae58FY9WUru_A5PEFE9tyACK4VWT3ZgrJA&ev=4\",\"Image\": \"https://www.uat.davidjones.com/Productimages/Large/1/1919678_18973216_2137806.jpg\",\"Rating\": \"-1\",\"Price\": \"299.00\",\"ComparePrice\": \"299.00\",\"Shipping\": \"\",\"PromoText\": \"\",\"ParentSKU\": \"22351154\",\"ClientAdvertiserId\": \"1\",\"AdvertiserId\": \"0\",\"RenderingAttributes\": \"{\\\"brand\\\":\\\"country road\\\",\\\"issellersku\\\":\\\"0\\\",\\\"mapViolation\\\":\\\"0\\\",\\\"nothing\\\":\\\"hello\\\",\\\"numberOfReviews\\\":\\\"0\\\",\\\"shippingCost\\\":\\\"0\\\",\\\"taxonomy_text\\\":\\\"brand>country road>women\\\"}\",\"OnLoadBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=QEdzihNMK6KnNThJTDtgt39PXh3I_StNG2lk2LDaj3ZzizS4TKj8Y6YRDFy3T8e5Z5wGD5nqOM6vherqvrslarOZWADEFH6GeWpZholiaGmPtHv0PZjt6ljOHHdN5xSfFaR5UQYfo25Z4ooO7rZaMlXA1ouVIYlX30e_PbjfnK6FM4cH3e_xDP1bkXdySCmd0jZOFBf1ypVxEueMETItkkMgs1PND4r5UhuGQsBnZmNp3QNFeXaN5Lm9-TqP7ndLM3E8SIqw6QoUR-GR6VgNsKPjUcQ9EG75T6wDbiC19CXvq1v-O3j_Mb4m5jvSx9oqXPU5aJmdCNK21LWR8OfygOBxWOWplZnatIhEgOBsUEs&ev=4\",\"OnViewBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=uTUb4nomWol7OywvL7LAhzVy93P574719W0WZ1cUP66OlK1btfPCVjeL0WKHE1hVtmMXipOpO4KDwigdr7Jca79DxfAohei85yhoFpNKQC5uC0Vno3Poez8AAGax5RR6nBpyE-dLnRTc16fjMADoZphFAT3iVy4CVLH6RZh-mMdttesClW4UtbKjYfpuW53ZV1s_ypTu0wqHlRQrMHhVxW6GlpUDbSjQefSn_qHxok4tKZ3wmfBfKhPSCVPfJ9Dz_Mvw0tJ1DDrvFKJr2YetBLNPN4vmWPckXIYZmL62QAULDv2uv3Zw0lZhIGiwvE8ecbjc6s2Q9mRSwA5NHPpVs25qzfYCLtYBt0-nM46wDqKcFpCzflEET5A0Gk4K7EuqjAOlE_Mlfg34OhRGypzaFA&ev=4\",\"OnClickBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=Q-zpVFH2Fgl8GH-jjKVsnOfYhtiVvXKeK6dV4gFlMf0xu6A6rNIRblhbnYmb6VyszEAsKNI5-bSKjhsQ9fLG_rsxewa9w8QZjmmf9RImQ7N63YtNCUHpE0FQjJ3zskMr3QIRvvoWI8u1SsvEXajFh7P_7lZi33z3uSuU-B4r6Ko2_qEJgIwsP3C9kLOYJKN0DlUIB9GX8NwJHxiUuuoFUMlCzC-5Z6Kt6zuuRPNtcaqkZDKQLBHvj59YXlh-mTpgCpiUKLjCpGbPr-NccU7X6ALaovnobx462ekK3kEkJuDBmJ5-muEF8JZ3KBwz3mH_Bl2laC7_Gja3T4aCoPi8_JgX4v00y6hNHwaqvHsTXuR9rosRJ9Vg5OeQXJYtCNj8wjzSZa9O6d1ZMyrI0SS6WA&ev=4\",\"OnBasketChangeBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=D_4VG9Gepki40iaGFiIG22NTSGDT405rILKiVppb3nE6H9-ammtpQEGQCqp9BYgOAwVz3EduimrGDF-cs372r5ikNNWK2h_01QHPiQnjaDVdyY4oSP978pN5DGcsr6j1bNqnPvrL-AtZqAG7UoxRc87kMdlzbAB6RuF2EFIFPXBbUimgWq3nO4p0VwFEdgnfTxspbg2DcOaYD4yej9s8aBR_sYSh3rp4ntX40fG3VAJXrjdEFHpTckv7Qngiap6l17D-30MA1jXBElopy4zVbAIm4voE16_inPqB1ecXcA9kE0ICHNOrudQZi8slFF4I9I7i2QYXZAbx9fs9zMVy3NI9DZAeH-iwc_s9-Out1V_iL_Q91FUB4nJdvZdqhS7dAGJX0U7O4yWiyhNjatlvgflAZ-7Y7P_4RCCCbLKfAvE&ev=4\",\"OnWishlistBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=aOw6OqSBK5K4U8FN3J6Lu8L1AtWwm5_vmm1m1qN--XbWSIbRDXDpy3dIz6Oe7AbCTn-kNV2BXJw5IG-hSOXdyQDyLjVatp0Q05oKvilifqSERc-1DJzZuRFas7yToFCGgpr6ZnFEvTVLawsX2u3IQHxS55X_wGnSwB3cgsKqs2YE4aOKpDTOvrAF_JFQ4oyF_qdOSFuYcLCRJuNwK-xq2E3j4FxgVIt9FPQvyKGH9d_zsSgmSTcr-2lhAt6ugWhOUDYB7jyEHjzXcNiPfCEK4PWikiRxJhGsrl5hN6RqU96Nw8m0ljqBhBjprvZdJQ3VEn-0R8sCjm29neOmEpcA_JNxVKFrsCveT13xC77MY4L3-9zIF9eod5AcQPeLlCY7V5NyDztm6-Sk6iTXx4N5-XxWzQWuKXPGnUo1FGcIhcw&ev=4\"},{\"ProductName\": \"Country Road Polo Shirt\",\"ProductId\": \"21817094\",\"ProductPage\": \"//b.sg1.as.criteo.com/rm?dest=https%3a%2f%2fwww.uat.davidjones.com%2fProduct%2f21817087&sig=1-hMH0dsYzxdivllSryXkTc6ksmtzErhV6CO9N7_grgwc&rm_e=CX5p6yu3ImxkfdY3bKV1kEGEdpVTNQVjqqr1q0EWFLkdKiGCINR0MQlO6ybnu5-5HzA-wzJzCiSdjgrArxkh_cZ6hFchqyy6wLoIGfSdovcYGrmtrznlkYy7LHTlCTTn9JJ9ujEvJb4ki88ofB7NF02RKvg7P7jIa4rICuC9AqEGkfPZpVL-VMLEz3U3KWRARozJte5BdSQ0rE_ZFAY8y13y-VUVz-vBliXgxnCmGB7xb2eMfHuloSg5RU1KBMv2TM9Drn2QLWzKL-SPz7BtU_zjIHdspGNjwXMkHUBGLUjbSzmiu6ISS481sLYWbeLJqvQnc1c5ZKda_7pTv73Kk0KMW_i37-xn7cwBaNdFORwz9YBIfnUxGNBqTKWJugPdq1blh0z05Tg2j04R5-RVsQ&ev=4\",\"Image\": \"https://www.uat.davidjones.com/Productimages/Large/1/1797411_13155970_1252440.jpg\",\"Rating\": \"-1\",\"Price\": \"9.95\",\"ComparePrice\": \"9.95\",\"Shipping\": \"\",\"PromoText\": \"\",\"ParentSKU\": \"21817087\",\"ClientAdvertiserId\": \"1\",\"AdvertiserId\": \"0\",\"RenderingAttributes\": \"{\\\"brand\\\":\\\"country road\\\",\\\"issellersku\\\":\\\"0\\\",\\\"mapViolation\\\":\\\"0\\\",\\\"nothing\\\":\\\"hello\\\",\\\"numberOfReviews\\\":\\\"0\\\",\\\"shippingCost\\\":\\\"0\\\",\\\"taxonomy_text\\\":\\\"kids>edit>australian brands\\\"}\",\"OnLoadBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=efF9QYGAfalBGIiTQj7VNEAYQ87Mpl1LPbvMmB14W8xUtmTZZJtd9q0hjdVtp9ae9DbHqbqkZS_J3LNh-SdG6ouxFWpdWvKl2MTuE3H4dLNX0WOyqcZIygjq7IDA11KF1fOtKDiWWjDXcqWvdPEdkk3E2hd-V_CO-HMmSrhscu9MzG85ylIPX2zzmw4StUc5lilCGic5J5Lgn3ecrvgFPwd95EVPH3L5Xl1PXlRMqlqJejvI0tiLTHXxBvJ91xepszSN3vqRWcig7Bo5gm6EjGnK8jzmTO0x1WGzLQPun4LH6ZKg2U-d7-Cv_Km3yTOMB4fEPmrz29VbvMO2RRLHKErzPdcV1BtfBvfaz0jZoTs&ev=4\",\"OnViewBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=PEuw-9Hqx1yzW2phBA2iewqi4O2HNxwfNiDF7SnIV_VRVEURn1CnR0YhM13xrwBwQCa0bJgnGiYdtWwPdDfVPXgxGbbUf-6kzew9n6GMmcjVTdSROqAzWddahyLl80R42fKzXUIzHY_fWnfRTXnsdKTRL37jqjtoez40VIldIlqg7ucYT-btFwgqdSr65y417IY8raKWwca6Yph2HQF-IPEYE_ZvV__ad-yR06LtzUiwZgm81r0fC5wqAskq2dgOrN88R8uiMTRFgV1KvaTDpbDGNLcnTmMqytbU8wJWHxqJN7q3wCaMY8JfAL0CP00YGbQmJQ4YrtxrVZvCaQglUXs1--M3tOXYLhhOvW1CC-8uV5usisDQGTuCf43xHnHoLHr0QJcRNsUTJbI_PygMSA&ev=4\",\"OnClickBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=EdzudluppPc2wCHWLQLdldEYBYOsICDYbNAkIdrLg7ElQsF9mvup34oM00zRaDWuTUZ3qaiglEgnFf0iAthgD4g43izPapg-iP-BXczWL-8TlSkhYndm2BNDZjSz_yIaUaU1DBrvASADGt4sfBaTXxkY8nMkhCfQLQMS77_EM4MAv4Ted8SqsnHpW049Ax_i5ZjtGN4k7HEhcBNYOhYCZkBnt50Pat9fknbdTntGjon5Sj6yeT5boRdaLgHIN6z90EAqhNb9y0aWYspk92azQsXPvPuCx65JXTYU-Ikz2RTmsyFXEWp1ZZSoB120tPBhov5dm245IgayFOkS7Rj9_iFr77Sjpvlvj2tcpt_Sly1ZcMDjLUOVaohYe3xKFpm_eSf2NGKh__DM0q7nKEWyFlC_fVx1B6OJLYr6YZFHAz4&ev=4\",\"OnBasketChangeBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=N4AwKfz71DY5G4AWWR3XTEdFYLDt1LhX1MWECJImvaWAx0jyUOK-7CMrKtQXXn_hdwSFNhoKezZEtny7MypZ2iQZ54usPICe-pBmcUQCv9B729Ym_2zgWSY83Tb1t9MacyOFByX5UpThjlbR5QivAFlNL4FdB5Ib23e5nSDvdUqZ0ILk7vpzBksnX2d_q9VEdtDEFhqNIA8tBCaJj6k_8jwLIetn6eWMlX7t5Gy_fNACmYo9QSjfUbWUECqTkLFnXujyB3p7Vdt8XT8hZ30hQyLukjf1_unSzHyfQeN_Xs5mSOMRIz-PVyaHehZsHaLh6GSpHm9gpuB7EWJeH7IY2RMZuF6mdybbIFtkLfj8NAB0sxAoiooU43Y1vlDfTLH0Gd3cH0edsBMfkGlH6jLnfkJKSMoUUkiPLV9xtwOcWa0&ev=4\",\"OnWishlistBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=qnUW97OdKp7zCZNvVAOWeePC4gmg-rrJz5xcz85-hHTWjbveQMtNgCuuxbbBllQT688lpgDMYYVXTHtX_3EI1FP3S-QZzO-r9LlMFQAGstLHVIJ6oaf9BjtNJSWKIUn167AR5nTiFgrA7fPUTMIgeJ99nQs-t8_qH7jmd5Zmi-sctMTd0lCPXzYtduLlCS84Ha68-u0aBkwXJVKSgh8zB602XKK8X6g_6g7Yzjp8DTECJYpmjwVT8n2bvD9X69mlKPCKuAFcvC_aSw8zvssu0C4UYjS6vaPyy73Sa-XlloWAkGFStCrzmNohc9kDasUGD0lpDcUZcytX_6wNJNV3E6I5y0t5nTHbShUGQzfSFey-mLAE7XNOCZmi5VSFdABoGB2CxaxXH-k9igi_GXiBWA&ev=4\"},{\"ProductName\": \"Country Road Logo Socks\",\"ProductId\": \"22323464\",\"ProductPage\": \"//b.sg1.as.criteo.com/rm?dest=https%3a%2f%2fwww.uat.davidjones.com%2fProduct%2f22323462&sig=1-tMlLUygz_0vNVbHXX5ItAeunDykY69by-L6vmFwBPJM&rm_e=Esf62BkS_7atI2Qy1OvnCw6oLF7XvkJZGStculrlPCTJbB32uzXe511841UzBvdc4PUt38TL3yoVwipu2CmX9ERrtlwZwE5NTzs_51SzR4ZYOKjvsN_3s-8Ny_eR2hcj2S1Y6jY9H187VDqQJfkXWEDQ27ORsdAaDFjTJAKaFETXrhJ3kQnFZuMj0_CND_Myr8rnmrPGlnnURtd1rt13wowyBi9JbGdbycSG8M3b-eKf9K6yFEhLP_RJaMqcPUywJdlGSSHpyzc47iXm1Y78VELBwnMmvHAxweFzSBAyjzmo3blwTkU08h8zLXXEmDRGugqZi7-5sfY_V4MDCcgX3CFzXVQJHRT14wqYzNvdt-AaMyuZf-NWHlgf9MIRFCvXaS7OGx0hJiIT4Kum-uZEiw&ev=4\",\"Image\": \"https://www.uat.davidjones.com/Productimages/Large/1/1914279_18763445_1836504.jpg\",\"Rating\": \"-1\",\"Price\": \"12.95\",\"ComparePrice\": \"12.95\",\"Shipping\": \"\",\"PromoText\": \"\",\"ParentSKU\": \"22323462\",\"ClientAdvertiserId\": \"1\",\"AdvertiserId\": \"0\",\"RenderingAttributes\": \"{\\\"brand\\\":\\\"country road\\\",\\\"issellersku\\\":\\\"0\\\",\\\"mapViolation\\\":\\\"0\\\",\\\"nothing\\\":\\\"hello\\\",\\\"numberOfReviews\\\":\\\"0\\\",\\\"shippingCost\\\":\\\"0\\\",\\\"taxonomy_text\\\":\\\"brand>country road>men\\\"}\",\"OnLoadBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=hhS8ctO8vXE4Kg94aBEd5gVuR6ynYAemFks4w1ok5WX7iFdxOz-64hDWdIgPJHtib-fXxt4jptwkLaeiTdL10fBq0Y1kWUO2EgC6MLzxx2A9cIhoqmBZEp6zm3S3liUpFDB5WAA2ZVEq5uG3p4N6bXPijk70hryu_rZ4Q4-l1hEYXiW2NHZqWeNTqxkwddISfc_cGM5DHOo7STan7zDgVzjIwEwke7e_FW_Wq6KhtyEY_Jqsk5UnqkQrSoCKKusbqiS9owXZWtk2zcTtchwbL3yw4xeWStJmxQtSrN8yUHHkulR4VlV6mSTvVfj2Scl5pbIOfyEeNMsxN69fIY_2Zi05u0SGT3In9jbaOJG3qJE&ev=4\",\"OnViewBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=LJWeohiqu_nXa6D13UbthoJZeG9juK4Lv5MkazZmCLu_YdNQETW-j3_daPMCFay6WlgqvbYW1l03e3wSI2qVniS5Si7nFC7ajBtZ4Fz8MEdk03Pb6qqTHLELtZUkovxsot3OwUAZna_nKHZqF2XvqBK1m4d8ZK8-3VN02KQfKDimBUpsJV9LONMXyclMJcExs2Wfrle4AU_i4TnCPaLo_9qNiWxbD49VBV81e50roBOxE1qsnGdSqiPcK1PrwvEEmDIUYDY_JZj7oC2MrQ6ClVHgqdvrHRhO2jUZgKOVsQjUGPLOHXDLBXrhB4Et5q2ntn4gn5wfZDNeLKRgeV0cY_w6uS7q4nLLxNpT42iGEs8qsKH1dXTXeaCE-skLBx_M406NBCzkUmNpGSgvc8pTkA&ev=4\",\"OnClickBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=fyVWj0nPlzg6JXeBvnAWn7ZursObqUd9qrzPJ5E6IPc_CFhzeJbg1rR2xwqCxOu4MUyDfYth_KU54ezOtBg2Tyq9gOa6u7Im3OmdwFULSqctU3IwWh4qlo9cTKvddq7IBA8IbRlE54E5xICyBGSjf5UlvqUcG8Hi-22cgXP96G1_nO9IOh3DZj4qW6xU3cB_DuVKwH3s7VmzNiDBS7MHcWJffyw7aTkH0gDGvc0ZK7WWoYs7Btq5a0pUUTuGm5Uq4gFRo78IBZzMaEr63tvDuN559UuF7Xt1T1ff4F3N6AB3csr_l4RQBMbD2Xcy4iCukqSCLiwA27Xi4_bWGkJKIDAaZqvXRwaH6_6rYRbEylAsTSpHwokZJ-1jMl-I-3MHH2KM5TZSrzNgtX9lfBxKvg&ev=4\",\"OnBasketChangeBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=Igfaqsyko95TbvcxmDUzXmJ92R6q460e6wknpTtqe6E0Ow5bwA11phVVbmvvAUsaHylM_khhPYWWtymgxJ3xgnYet0OV_L6612HO9LEVl0lPuejZm4wHnzm7Bqv2BAEOB7L5wCj26ZrU8dFgwyEiaXrW4qV3TOSgKfixidwbwbqsUxSdR2cCuXLSAqPHIdn48j9_0MSr_Nak8EtmyWv9atP23o9MJAIw9DgT7YLim5ob2UXyTjj1TMJYHqSg1EMq7m_Hm3vNO5jNigx0IKXHQ75XzeBMsLpbZTy-qavOBE-bcpyy-C4Xf8WnWHKcvVTFKQXYhsmzL4mj1_XnAj0qJlDpH9G_6c7aDqDh0r2oH3S7enVkIbIMLXOHrs3yK0d7Ejg3pCExyjIqs35DlAPhfCppqbORfakO1_ElMHlZXKs&ev=4\",\"OnWishlistBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=Tyipr35bMSf6RC6asouAHlMqCLLXE71a9p7JDTRYrQ7NhCPZcCRPZBHfZOZHriQ7KBPKe0i7FKbmanS5VDqL-_1Ao_jcfuQ-M0DXZjAw4zh_Xwt3qpgmGjeYg2ojSCeBHhaft3X04J32u15XxGqWT_KMWe1DdP9rbcsNvj7rRB9yqYl10qae23_CyVEQw76c_hWNd2_oclw8M-ti1O617_L521tOhgPOs8GNnq4W_13nGFk92QSdh9Knayxwv8Gsnhatqzo9JjnDek-pk9NrPooAIXCn4emdHUBk_yrujJKc3BTLLPHrpAc9agJqC2lZ-tUBaZ8OwEK7v--9rMvJvJrXEfnIxv4dikajLwVBO96iPaiuV2r765mxBKpbz86mjwkUMx1t23OSV_jdRUgWKQ&ev=4\"}],\"rendering\": \"\",\"OnLoadBeacon\": \"//b.sg1.as.criteo.com/rm?fid=1240&hl_qs_cmp=cOye5J8hq5sHUykp4q4G4vUfm9-_YjUTnJiojzPbor-hyUzj_04y2OdIu0IXbsZBnoqFoOnfa7lvsGY1x5rXWqJxsZ67ONybBZUJro3LMcm_v-ASDfN67O99E-Fp4jTvOLKBSuy_Y-02YO34bYdg4hzZKZEDjUYR9XOyaMyOXhNDa_zEQmOzXAEJ9jMx7IT1eGvz6btRJ1_XBDO9DCo1ns0ycflMYK5mffWGJJU3RoL0MX-mTX-2f7TArm0ZjMgzVNmVshbOL3vJqaGvkG172ZBHIvC4GhtLVnEXWAlOsAB0xJQuYoPKa_D0xQV3osO41DFB39YhqcqJH0_5NTqQzZYEZx-7Uo6o-f00dLRXewlwmpDrn6DePiJX2qKlxXkF-KMJqEzuuG85Aa_XbrEO24zLQCCNBpPOOPNv0Zmiv95egchcj8HE7t3klHwsbTfRGXVQ7-Iny60TyEKmzi69nNKgDiaiwwT5vEZY5CgU_2MOJf55vFkMNDPtKKv4rvps2lO-Z6dPiM3idaWszMVp25hBtPZB0QpzW-vlT1h3Nx0&ev=4&criteopartnerid=111016&action=page&origc=A&pid=0d04e589-8498-4c19-b332-c7179166e35d&rn=37520547&rm_e=aBu6ej7FHNUBXyfPRzWK5Xv06sWPcp_xUifxb5URdLB5N7AY4dKDHoMq3dGPIyL0MKXEG5jX0Qn0hTn0sfvQL-vI5vE0qaYtTF8LeHO_DM4KIlkgg_MapuQUXQYE_ZF-QySlTEtjVYOjak9YoLYpBMRMpKe_KWchmlWLVFCIwwMdM61DkEPC5Lof0CbRZ2S1DeqJxgn4CsfRraBekKE2ebFH4mNA1_HcsZpO0KwIfpHgouaQGahUn4CYS2UUanCk\",\"OnViewBeacon\": \"//b.sg1.as.criteo.com/rm?rm_e=30N3rTI8Hyc-St8S_fasqnTRpXvfLM0VQkwDQUYkRlnAGu-0VAAalKSRjAfnI2GcMhAGcQ8Z2yhhDcgXWVkQIYA3y-YonyxLHB1L4XaAcG6tBKTE7OPL8vXOxXQz9NKK6F64dLpyK9aqw-Gg7OC4a45nPm2AYvXVD049Oo7Q8kUULnbMzsLfySQ31cSXNeABrpRkPve93ymeURfNcrIxZYDT0v5j_4hQx9riGZnst2YBUzcpF6ICfETjSFJOUVgUiFEmKUXmOl2NCKK12ME3m0ooAxd8ANMVvgCnQTXnl_4AdHbagZCERoai0SAk8RzWZTsNkQHiwyw9luBDI7pZLQ&ev=4\",\"OnClickBeacon\": \"\"}]}],\"page-uid\": \"d943e32d-1341-4e7e-995e-43df8e901e5a\"}";
			ResponseBase responseBase = JsonConvert.DeserializeObject<ResponseBase>(content);

			foreach (var placement in responseBase.Placements) {
				Console.WriteLine(placement.PlacementType);
				foreach (var advertisement in placement.Advertisements) {
					Console.WriteLine(advertisement.Format);
					foreach (var product in advertisement.Products) {
						Console.WriteLine(product.ProductName);
					}
				}
			}
		}

		public class ResponseBase {
			[JsonProperty("status")]
			public string Status;

			//[JsonProperty("placements")]
			//public RawPlacement RawPlacements;

			[JsonProperty("placements")]
			[JsonExtensionData]
			public JObject RawPlacements;


			[OnDeserialized]
			private void OnDeserialized(StreamingContext context) {
				// SAMAccountName is not deserialized to any property
				// and so it is added to the extension data dictionary
				JToken x = this.RawPlacements["placements"];
				Placement[] placements = x.ToObject<Placement[]>();
			}


			[JsonIgnore]
			public Placement[] Placements {
				get {
					// If there is data to process and it has not been processed before.
					//if (this.placements == null && this.RawPlacements?.JSONDictionary?.Count > 0) {
					//	this.placements = new Placement[this.RawPlacements.JSONDictionary.Count];
					//	for (int i = 0; i < this.RawPlacements.JSONDictionary.Count; i++) {
					//		this.placements[i] = new Placement(this.RawPlacements.JSONDictionary.ElementAt(i));
					//	}
					//}

					// If there is data to process and it has not been processed before.
					//if (this.placements == null && this.RawPlacements?.Count > 0) {

					//	foreach (KeyValuePair<string, JToken> tokenOuter in this.RawPlacements) {

					//		KeyValuePair<string, JToken> tokenOuterValue = tokenOuter.Value.ToObject<KeyValuePair<string, JToken>>();

					//		foreach (KeyValuePair<string, JToken> token in tokenOuterValue) {
					//			string key = token.Key;
					//			Advertisement[] advertisements = token.Value.ToObject<Advertisement[]>();
					//			this.placements.Add(new Placement(token.Key, token.Value.ToObject<Advertisement[]>()));
					//			//obj.Properties1.Add(token.Key, token.Value.ToObject<PropertiesClass>());
					//		}
					//	}
						

						//JObject my_obj = JsonConvert.DeserializeObject<JObject>(this.RawPlacements.Values());




						//// The RawPlacements object will start with the "placements" Key, so we have to get the content inside that.
						//KeyValuePair<string, JToken> kvpPlacements = this.RawPlacements.ElementAt(0);
						//if (kvpPlacements.Value != null) {

						//	foreach (JToken t in kvpPlacements.Value[0].Values()) {
						//		Console.WriteLine(t.ToString());
						//		Advertisement[] p1 = t.ToObject<Advertisement[]>();
						//	}

						//	foreach (JToken t2 in kvpPlacements.Value[0].Values()) {

						//		Advertisement[] ad2 = t2.ToObject<Advertisement[]>();
						//		Placement pl = new Placement(t2., ad2);
						//	}

						//	//Placement pl = new Placement(kvpPlacements.Key, kvpPlacements.Value[0].Values())


						//	// We have to convert the JToken into a Dictionary<string, JToken> JSONDictionary;
						//	//Dictionary<string, JToken> dictionary = kvpPlacements.Value.ToObject<Dictionary<string, JToken>>();

						//	//foreach (JToken jt in kvpPlacements.Value) {
						//	//	Placement pl = new Placement("test", jt);
						//	//		jt.ToObject<Placement>();
						//	//}

						//	//Dictionary<string, JToken> x = kvpPlacements.Value.ToObject< Dictionary<string, JToken>>();
						//	//Placement[] pls = kvpPlacements.Value.ToObject<Placement[]>();

						//	//this.placements = new Placement[kvpPlacements.Value.Count];
						//	//for (int i = 0; i < this.RawPlacements.Count; i++) {
						//	//	// Grab the placements KeyValue pair.
						//	//	KeyValuePair<string, JToken> kvp = this.RawPlacements.ElementAt(i);
						//	//	this.placements[i] = new Placement(this.RawPlacements.ElementAt(i));
						//	//}
						//}
					//}


					return this.placements;
				}
			}
			//private Placement[] placements = null;
			private Placement[] placements = null;

			/// <summary>
			/// A list of messages explaining why the request was not successful.
			/// </summary>
			[JsonProperty("errors")]
			public string[] Errors;

			/// <summary>
			/// A unique page identifier provided by Criteo.
			/// </summary>
			[JsonProperty("page-uid")]
			public string PageUID;

			/// <summary>
			/// A flag to indicate if the request was successful.
			/// </summary>
			[JsonIgnore]
			public bool IsOk { get { return (!string.IsNullOrEmpty(this.Status) && this.Status != "Error"); } }

			/// <summary>
			/// The content of the Criteo response.
			/// </summary>
			[JsonIgnore]
			public string ResponseContent;

			/// <summary>
			/// The URL that was called.
			/// </summary>
			[JsonIgnore]
			public string URL;

			/// <summary>
			/// The <see cref="CriteoTypes"/> if request that was made.
			/// </summary>
			[JsonIgnore]
			public CriteoTypes CriteoType;

			/// <summary>
			/// A list of all the <see cref="Product">s that were returned by Criteo.
			/// </summary>
			[JsonIgnore]
			private HashSet<Product> allCriteoProducts;

			/// <summary>
			/// A list of all the Foreign Identities in <see cref="allCriteoProducts"/>.
			/// </summary>
			[JsonIgnore]
			private HashSet<string> allProductItemForeignIdentities;

			/// <summary>
			/// A flag indicating if this <see cref="ResponseBase"/> has <see cref="Placements"/> and if at least one of them is valid.
			/// </summary>
			[JsonIgnore]
			public bool IsValid {
				get {
					if (this.Placements?.Length == 0) {
						return false;
					} else {
						// If at least one Placement is valid, then the ResponseBase is valid.
						return this.Placements.Any(a => a.IsValid);
					}
				}
			}

			/// <summary>
			/// Return a list of all the Foreign Identities in <see cref="allCriteoProducts"/>.
			/// </summary>
			/// <remarks>This calls <see cref="GetAllCriteoProducts"/> if <see cref="allCriteoProducts"/> has not been populated.</remarks>
			/// <returns>A unique list of all the Foreign Identities in <see cref="allCriteoProducts"/>.</returns>
			internal HashSet<string> GetAllProductItemForeignIdentities() {
				if (this.allProductItemForeignIdentities == null) {
					GetAllCriteoProducts();
				}

				return this.allProductItemForeignIdentities;
			}

			/// <summary>
			/// Return a list of all the <see cref="Product"/>s in the Criteo response.
			/// </summary>
			/// <returns>A unique list of all the <see cref="Product"/>s in the Criteo response</returns>
			internal HashSet<Product> GetAllCriteoProducts() {
				if (this.allCriteoProducts == null) {

					this.allCriteoProducts = new HashSet<Product>();
					this.allProductItemForeignIdentities = new HashSet<string>();

					if (this.Placements != null && this.Placements.Any()) {
						foreach (Placement placement in this.Placements) {
							if (placement.Advertisements != null && placement.Advertisements.Any()) {
								foreach (Advertisement advertisement in placement.Advertisements) {
									if (advertisement.Products != null && advertisement.Products.Any()) {
										foreach (Product product in advertisement.Products) {
											if (product != null && !string.IsNullOrWhiteSpace(product.ProductItemForeignIdentity)) {
												this.allCriteoProducts.Add(product);
												this.allProductItemForeignIdentities.Add(product.ProductItemForeignIdentity);
											}
										}
									}
								}
							}
						}
					}
				}

				return this.allCriteoProducts;
			}
		}

		public class Placement {

			/// <summary>
			/// The type of placement that this represents.
			/// </summary>
			[JsonIgnore]
			public readonly string PlacementType;

			/// <summary>
			/// A list of Advertisements that are related to this placement.
			/// </summary>
			[JsonIgnore]
			public Advertisement[] Advertisements;

			/// <summary>
			/// A flag indicating if this <see cref="Placement"/> has <see cref="Advertisements"/> and if at least one of them is valid.
			/// </summary>
			[JsonIgnore]
			public bool IsValid {
				get {
					if (this.Advertisements?.Length == 0) {
						return false;
					} else {
						// If at least one Advertisement is valid, then the placement is valid.
						return this.Advertisements.Any(a => a.IsValid);
					}
				}
			}

			/// <summary>
			/// Constructor.
			/// </summary>
			public Placement() { }

			/// <summary>
			/// Constructor.
			/// </summary>
			/// <param name="rawPlacement">The <see cref="RawPlacement"/> data received from Criteo.</param>
			public Placement(KeyValuePair<string, JToken> rawPlacement) : this(rawPlacement.Key, rawPlacement.Value) {
			
			}

			/// <summary>
			/// Constructor.
			/// </summary>
			/// <param name="placementType">The type of placement.</param>
			/// <param name="raw">The <see cref="JToken"/> is a list of <see cref="Placement"/> objects.</param>
			public Placement(string placementType, JToken raw) {
				this.PlacementType = placementType;
				if (raw != null) {

					//Dictionary<string, JToken> JSONDictionary = (Dictionary<string, JToken>)raw;

					//raw.

					//Dictionary<string, JToken> JSONDictionary = raw.ToObject<Dictionary<string, JToken>();


					this.Advertisements = raw.ToObject<Advertisement[]>();
				}
			}

			public Placement(string placementType, Advertisement[] advertisements) {
				this.PlacementType = placementType;
				this.Advertisements = advertisements;
			}
			}
		public class Advertisement {

			/// <summary>
			/// The format of the Advertisement.
			/// </summary>
			[JsonProperty("format")]
			public string Format;

			/// <summary>
			/// A list of <see cref="Product"/>s that are relevant to this Advertisement.
			/// </summary>
			[JsonProperty("products")]
			public Product[] Products;

			/// <summary>
			/// For Criteo Internal use.
			/// </summary>
			[JsonProperty("rendering")]
			public string Rendering;

			/// <summary>
			/// Indicates that the product has rendered/should be displayed on the page (even if it is not yet visible).
			/// </summary>
			[JsonProperty("OnLoadBeacon")]
			public string OnLoadBeacon;

			/// <summary>
			/// Indicates that the ad has been viewed (viewed = 50% of the ad in viewport for 1 second).
			/// </summary>
			[JsonProperty("OnViewBeacon")]
			public string OnViewBeacon;

			/// <summary>
			/// Click tracking without redirection.
			/// </summary>
			[JsonProperty("OnClickBeacon")]
			public string OnClickBeacon;

			/// <summary>
			/// Indicates that a user clicked the Call to Action (CTA) button with the file option.
			/// </summary>
			[JsonProperty("onFileClickBeacon")]
			public string OnFileClickBeacon;

			/// <summary>
			/// A flag indicating if this Advertisement has at least one product.
			/// </summary>
			[JsonIgnore]
			public bool IsValid => this.Products?.Length > 0;

			/// <summary>
			/// Constructor.
			/// </summary>
			public Advertisement() { }

			/// <summary>
			/// Constructor.
			/// </summary>
			/// <param name="format">The format name of the advertisement.</param>
			public Advertisement(string format) : this() {
				this.Format = format;
			}
		}

		public class Product {

			/// <summary>
			/// Product Item Foreign Identity of the product that matches what Criteo has in the product feed.
			/// </summary>
			[JsonProperty("ProductId")]
			public string ProductItemForeignIdentity;

			/// <summary>
			/// ProductName that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("ProductName")]
			public string ProductName;

			/// <summary>
			/// Image that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("Image")]
			public string Image;

			/// <summary>
			/// Rating that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("Rating")]
			public string Rating;

			/// <summary>
			/// Price that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("Price")]
			public string Price;

			/// <summary>
			/// ComparePrice that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("ComparePrice")]
			public string ComparePrice;

			/// <summary>
			/// Shipping that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("Shipping")]
			public string Shipping;

			/// <summary>
			/// PromoText that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("PromoText")]
			public string PromoText;

			/// <summary>
			/// ParentSKU that is in the feed, describing the <see cref="ProductItemForeignIdentity"> above.
			/// </summary>
			[JsonProperty("ParentSKU")]
			public string ParentSKU;

			/// <summary>
			/// Values in the feed that are not standard, but are needed to render the ad.
			/// </summary>
			[JsonProperty("RenderingAttributes")]
			public string RenderingAttributes;

			/// <summary>
			/// Criteo Internal ID.
			/// </summary>
			[JsonProperty("ClientAdvertiserId")]
			public string ClientAdvertiserId;

			/// <summary>
			/// Criteo ID of the advertiser who sent the ad.
			/// </summary>
			[JsonProperty("AdvertiserId")]
			public string AdvertiserId;

			/// <summary>
			/// Click Tracking that redirects to the Product Details page.
			/// </summary>
			[JsonProperty("ProductPage")]
			public string ProductPage;

			/// <summary>
			/// Indicates that the product has rendered/should be displayed on the page (even if it is not yet visible).
			/// </summary>
			[JsonProperty("OnLoadBeacon")]
			public string OnLoadBeacon;

			/// <summary>
			/// Indicates that the ad has been viewed (viewed = 50% of the ad in viewport for 1 second).
			/// </summary>
			[JsonProperty("OnViewBeacon")]
			public string OnViewBeacon;

			/// <summary>
			/// Click tracking without redirection.
			/// </summary>
			[JsonProperty("OnClickBeacon")]
			public string OnClickBeacon;

			/// <summary>
			/// When the user adds, removes, or changes the quantity of the product in their basket from the product tile.
			/// </summary>
			[JsonProperty("OnBasketChangeBeacon")]
			public string OnBasketChangeBeacon;

			/// <summary>
			/// Indicates that a user clicked the Add to Wishlist button of the product.
			/// </summary>
			[JsonProperty("OnWishlistBeacon")]
			public string OnWishlistBeacon;
		}

		public enum CriteoTypes {
			/// <summary>
			/// Called from payment page.
			/// </summary>
			TRACKTRANSACTION,
			/// <summary>
			/// Called from the Cart.
			/// </summary>
			VIEWBASKET,
			/// <summary>
			/// Called from Product Listing pages.
			/// </summary>
			VIEWCATEGORY,
			/// <summary>
			/// Called from the home page.
			/// </summary>
			VIEWHOME,
			/// <summary>
			/// Called from Product Detail page.
			/// </summary>
			VIEWITEM,
			/// <summary>
			/// Called when a customer does a search.
			/// </summary>
			VIEWSEARCHRESULT
		}
	}
}
