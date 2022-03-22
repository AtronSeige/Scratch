using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Xml;

namespace ScratchJSON {
	internal class Program {
		static void Main(string[] args) {

			//XmlToJson();
			QueryJson();
			Console.ReadLine();
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
	}
}
