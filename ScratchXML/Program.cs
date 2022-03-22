﻿using Microsoft.CSharp;
using ScratchXML.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ScratchXML
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//TestLoadXML();
				//TestClaimReserve();
				//TestXmlDocument();

				//TestDeserializeCreateSalesOrder();

				//TestCollectionOfCustomer();

				ProntoOrderXML();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}

		private static void TestCollectionOfCustomer() {
			string xml = @"
				<Customers>
					<Customer>
						<Customer_ID>1</Customer_ID>
						<Customer_Name>Jaco</Customer_Name>
					</Customer>
					<Customer>
						<Customer_ID>2</Customer_ID>
						<Customer_Name>Jannie</Customer_Name>
					</Customer>
					<Customer>
						<Customer_ID>3</Customer_ID>
						<Customer_Name>Pietie</Customer_Name>
					</Customer>
				</Customers>
				";

			// This allows us to extract the Customer from the Customers, even though we do not have a Customers XML Element.

			//List<Customer> customers = xml.DeserializeXml<List<Customer>>();
			List<Customer> customers = xml.DeserializeXml2<List<Customer>>("Customers");

			Console.WriteLine(customers.Count());
		}

		private static void TestDeserializeCreateSalesOrder() {
			string xml = @"<ProntoOrder>
  <OrderID>11858</OrderID>
  <AccountCode>0033014</AccountCode>
  <BranchCode></BranchCode>
  <SalePriority>5</SalePriority>
  <EmployeeCode>1</EmployeeCode>
  <TerritoryCode>310</TerritoryCode>
  <Date>26-11-2021</Date>
  <Addresses>
    <ProntoAddress>
      <AddressType>DA</AddressType>
      <Company />
      <Street>534 Columbo Street</Street>
      <Suburb>blooper</Suburb>
      <State>South Island</State>
      <Country>NZL</Country>
      <City>Christchurch</City>
      <Postcode>8011</Postcode>
      <ContactPhone>123456789</ContactPhone>
    </ProntoAddress>
  </Addresses>
  <Lines>
    <ProntoLine>
      <LineType>SN</LineType>
      <OrderItemID>2912</OrderItemID>
      <ForeignIdentity>163879BLA2</ForeignIdentity>
      <UnitPrice>754.5500</UnitPrice>
      <TaxCode>Z</TaxCode>
      <Quantity>1</Quantity>
    </ProntoLine>
    <ProntoLine>
      <LineType>SC</LineType>
      <UnitPrice>50.0000</UnitPrice>
      <TaxCode>Z</TaxCode>
      <ChargeTypeFlag>0</ChargeTypeFlag>
      <LineDescription>NZ Express</LineDescription>
    </ProntoLine>
  </Lines>
  <Payments>
    <ProntoPayment>
      <Amount>804.5500</Amount>
      <StoreID>310</StoreID>
      <TerminalNumber>1</TerminalNumber>
      <PaymentMethod>V</PaymentMethod>
    </ProntoPayment>
  </Payments>
</ProntoOrder>";

			CreateSalesOrder_Request cso = xml.DeserializeXml<CreateSalesOrder_Request>();

			Console.WriteLine(cso.OrderID);
			Console.WriteLine("Addresses " + cso.Addresses.Count);
			Console.WriteLine("Addresses 0 Street " + cso.Addresses[0].Street);
			Console.WriteLine("Lines " + cso.Lines.Count);
			Console.WriteLine("Lines " + cso.Lines[0].ForeignIdentity);
			Console.WriteLine("Payments " + cso.Payments.Count);
			Console.WriteLine("Payments 0 " + cso.Payments[0].Amount);

			Console.ReadLine();

		}

		static void TestClaimReserve() {

			// Single Claim
			string xml = "<Claim><ClaimNo>123</ClaimNo><Reserves><Reserve><Value>100</Value></Reserve><Reserve><Value>200</Value></Reserve></Reserves></Claim>";

			Claim c = xml.DeserializeXml2<Claim>();

			if (c != null) {
				Console.WriteLine(c.ClaimNo);
			}

			// List of 2 Claims in ClaimWrapper
			xml = "<Claims><Claim><ClaimNo>123</ClaimNo><Reserves><Reserve><Value>100</Value></Reserve><Reserve><Value>200</Value></Reserve></Reserves></Claim><Claim><ClaimNo>123</ClaimNo><Reserves><Reserve><Value>100</Value></Reserve><Reserve><Value>200</Value></Reserve></Reserves></Claim></Claims>";

			ClaimWrapper claims = xml.DeserializeXml<ClaimWrapper>();

			if (claims != null) {
				Console.WriteLine("List of claims");
				claims.Claims.ForEach(x => Console.WriteLine(x.ClaimNo));
			}

			// List of 3 Claims in ClaimWrapper, different deserializer
			xml = "<Claims><Claim><ClaimNo>123</ClaimNo><Reserves><Reserve><Value>100</Value></Reserve><Reserve><Value>200</Value></Reserve></Reserves></Claim><Claim><ClaimNo>123</ClaimNo><Reserves><Reserve><Value>100</Value></Reserve><Reserve><Value>200</Value></Reserve></Reserves></Claim></Claims>";

			claims = xml.DeserializeXml2<ClaimWrapper>();

			if (claims != null) {
				Console.WriteLine("List of claims");
				claims.Claims.ForEach(x => Console.WriteLine(x.ClaimNo));
			}

			var rs = xml.DeserializeXml<List<Reserve>>("Reserves");

			if (rs != null) {
				foreach (var r in rs) {
					Console.WriteLine(r.Value);
				}
			}
		}

		static void TestXmlDocument() {
			// Single Claim
			XmlDocument xml = new XmlDocument();
			xml.LoadXml("<Claim><ClaimNo>123</ClaimNo><Reserves><Reserve><Value>100</Value></Reserve><Reserve><Value>200</Value></Reserve></Reserves></Claim>");

			Claim c = xml.DeserializeXml<Claim>();

			if (c != null) {
				Console.WriteLine(c.ClaimNo);
			}
		}

		static void ValidateXMLwithXSD()
		{
			try
			{

				string path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
				string name1 = "Animal_v1";
				string name2 = "Animal_v2";


				//Validate XMLv1 against XSDv1
				ValidateXMLAgainstXSD(path, name1);

				//Compile the XSDv1 -> Classv1
				Type type1 = CreateTypeFromXSD(path, name1);

				//DEserialize XMLv1 into Classv1 -> Objectv1
				var finalResult = Activator.CreateInstance(type1);

				//Compile XSDv2 -> Classv2

				//Map Objectv1 to Classv2 -> Objectv2

				//Serialize Objectv2 to XML

				//Display XML

			}
			catch (Exception ex)
			{
				DisplayError(ex);

			}
			finally
			{
				Console.WriteLine("Process Complete. Press any key to stop execution.");
				Console.ReadLine();
			}
		}

		private static Type CreateTypeFromXSD(string path, string name1)
		{
			CSharpCodeProvider cspro = new CSharpCodeProvider();

			CompilerParameters cparam = new CompilerParameters(new[] { "mscorlib.dll", "System.dll", "System.Xml.dll" })
			{
				GenerateInMemory = true,
				GenerateExecutable = false
			};

			string c1 = File.ReadAllText($"{path}\\{name1}.cs");

			CompilerResults cResult = cspro.CompileAssemblyFromSource(cparam, c1);

			if (cResult.Errors.Count > 0)
			{
				DisplayErrors(cResult.Errors);
				return null;
			}

			// then load your dll file, get type and object from class
			Assembly assembly = cResult.CompiledAssembly;
			//Type myType = assembly.GetType(assembly.DefinedTypes.First());
			Type myType = assembly.DefinedTypes.First();

			return myType;
		}

		private static void ValidateXMLAgainstXSD(string path, string filename)
		{
			string xmlFile = $"{path}\\{filename}.xml";
			string xsdFile = $"{path}\\{filename}.xsd";

			//Verify that XML exists
			if (!File.Exists(xmlFile)) throw new FileNotFoundException("File Not Found", xmlFile);

			//Verify that XSD exists
			if (!File.Exists(xsdFile)) throw new FileNotFoundException("File Not Found", xsdFile);

			XmlSchemaSet schema = new XmlSchemaSet();
			schema.Add("", xsdFile);

			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ValidationType = ValidationType.Schema;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
			settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
			settings.Schemas.Add(schema);

			settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);


			XmlReader rd = XmlReader.Create(xmlFile, settings);

			//Validation takes place as the document is loaded.
			XDocument doc = XDocument.Load(rd);
			//doc.Validate(schema, ValidationEventHandler);

		}

		private static void DisplayError(Exception ex)
		{
			Console.WriteLine("ERROR:");

			while (ex != null)
			{
				Console.WriteLine("Message " + ex.Message);
				Console.WriteLine();
				Console.WriteLine("StackTrace " + ex.StackTrace);
				Console.WriteLine("-------------------------------------------------");
				ex = ex.InnerException;
			}
		}

		private static void DisplayErrors(CompilerErrorCollection exs)
		{
			Console.WriteLine("ERROR:");
			foreach (CompilerError ex in exs)
			{
				Console.WriteLine(ex.ErrorText);
			}
		}

		private static void ValidationEventHandler(object sender, ValidationEventArgs e)
		{
			XmlSeverityType type = XmlSeverityType.Warning;
			if (Enum.TryParse<XmlSeverityType>("Error", out type))
			{
				if (type == XmlSeverityType.Error)
					throw new Exception(e.Message);

			}
		}

		private static void TestLoadXML() {

			XmlDocument x = new XmlDocument();
			string xml = null;

			try {
				x.LoadXml(xml);
				Console.WriteLine($"LoadXml Results [{xml}] > [{x.OuterXml}]");
			} catch (Exception ex) {
				Console.WriteLine($"LoadXml Exception {ex.Message} with [{xml}]");
			}

			try {
				xml = string.Empty;
				x.LoadXml(xml);
				Console.WriteLine($"LoadXml Results [{xml}] > [{x.OuterXml}]");
			} catch (Exception ex) {
				Console.WriteLine($"LoadXml Exception {ex.Message} with [{xml}]");
			}

			try {
				xml = "not valid xml";
				x.LoadXml(xml);
				Console.WriteLine($"LoadXml Results [{xml}] > [{x.OuterXml}]");
			} catch (Exception ex) {
				Console.WriteLine($"LoadXml Exception {ex.Message} with [{xml}]");
			}

			try {
				xml = "<partial><xml/>";
				x.LoadXml(xml);
				Console.WriteLine($"LoadXml Results [{xml}] > [{x.OuterXml}]");
			} catch (Exception ex) {
				Console.WriteLine($"LoadXml Exception {ex.Message} with [{xml}]");
			}

			try {
				xml = "<valid><xml>is</xml></valid>";
				x.LoadXml(xml);
				Console.WriteLine($"LoadXml Results [{xml}] > [{x.OuterXml}]");
			} catch (Exception ex) {
				Console.WriteLine($"LoadXml Exception {ex.Message} with [{xml}]");
			}

			//try {
			//	xml = "";
			//	x.LoadXml(xml);
			//	Console.WriteLine($"LoadXml Results [{xml}] > [{x.OuterXml}]");
			//} catch (Exception ex) {
			//	Console.WriteLine($"LoadXml Exception {ex.Message} with [{xml}]");
			//}

		}

		private static void ProntoOrderXML() {

			//Build a payload for testing
			int childCount = 3;
			string payloadXml = "<payload><orderID>1430526</orderID><externalReferences array=\"true\" /><childOrderID>1430529</childOrderID>";

			for (int i = 0; i < childCount; i++) { 
				payloadXml += $"<vouchers array=\"true\"><id>{i+1}</id><quantity>{i+1}</quantity></vouchers>"; 
			}

			payloadXml += "</payload>";

			XmlDocument payload = new XmlDocument();
			payload.LoadXml(payloadXml);

			// Get the vouchers from the payload
			XmlNodeList vouchers = payload.SelectNodes("/payload/vouchers");

			XmlDocument prontoOrder = new XmlDocument();

			XmlAttribute jsonNS = prontoOrder.CreateAttribute("xmlns:jsonns");
			jsonNS.Value = "http://james.newtonking.com/projects/json";

			XmlAttribute jsonArr = prontoOrder.CreateAttribute("jsonns:Array");
			jsonArr.Value = "true";

			XmlElement root = prontoOrder.CreateElement("prontoorder");
			root.SetAttributeNode(jsonNS);

			XmlElement customer_reference = prontoOrder.CreateElement("customer_reference");
			customer_reference.InnerText = "123"; //OrderID

			XmlElement unique_order_number = prontoOrder.CreateElement("unique_order_number");
			unique_order_number.InnerText = "123"; //OrderID

			XmlElement invoice_no = prontoOrder.CreateElement("invoice_no");
			invoice_no.InnerText = "123"; //OrderID

			XmlElement account_code = prontoOrder.CreateElement("account_code");
			account_code.InnerText = "123"; //Pronto Debtor

			XmlElement warehouse_code = prontoOrder.CreateElement("warehouse_code");
			warehouse_code.InnerText = "123"; //Store Branch Code

			XmlElement priority_code = prontoOrder.CreateElement("priority_code");
			priority_code.InnerText = "123"; //???

			XmlElement rep_code = prontoOrder.CreateElement("rep_code");
			rep_code.InnerText = "123"; //???

			XmlElement territory_code = prontoOrder.CreateElement("territory_code");
			territory_code.InnerText = "123"; //???

			XmlElement date = prontoOrder.CreateElement("date");
			date.InnerText = "123"; //Order date

			root.AppendChild(customer_reference);
			root.AppendChild(unique_order_number);
			root.AppendChild(invoice_no);
			root.AppendChild(account_code);
			root.AppendChild(warehouse_code);
			root.AppendChild(priority_code);
			root.AppendChild(rep_code);
			root.AppendChild(territory_code);
			root.AppendChild(date);

			prontoOrder.AppendChild(root);

			

			/* XML To Match
			 * 
				<prontoorder xmlns:jsonns="http://james.newtonking.com/projects/json">
				  <customer_reference>12151</customer_reference>
				  <unique_order_number>12151</unique_order_number>
				  <invoice_no>12151</invoice_no>
				  <account_code>0033014</account_code>
				  <warehouse_code>100</warehouse_code>
				  <priority_code>5</priority_code>
				  <rep_code>1</rep_code>
				  <territory_code>310</territory_code>
				  <date>22-03-2022</date>
				  <addresses xmlns:jsonns="http://james.newtonking.com/projects/json" jsonns:Array="true">
					<address_type>DA</address_type>
					<address1>eStar Online UAT</address1>
					<address2>1 Queen Street</address2>
					<address4>Melbourne</address4>
					<address5>VIC</address5>
					<address6>AUS</address6>
					<address7>Melbourne</address7>
					<postcode>3000</postcode>
					<phone>+0000</phone>
				  </addresses>
				  <lines xmlns:jsonns="http://james.newtonking.com/projects/json" jsonns:Array="true">
					<line_type>SN</line_type>
					<item_code>E-GIFT</item_code>
					<item_price>50.0000</item_price>
					<item_price_tax_code>F</item_price_tax_code>
					<ordered_qty>1</ordered_qty>
				  </lines>
				  <payments xmlns:jsonns="http://james.newtonking.com/projects/json" jsonns:Array="true">
					<amount>50.0000</amount>
					<store_id>310</store_id>
					<terminal_no>1</terminal_no>
					<money_type>V</money_type>
				  </payments>
				</prontoorder>
			 */

			Console.WriteLine(prontoOrder.InnerXml);

			//foreach (XmlNode voucher in vouchers) {
			//	Console.WriteLine(voucher.SelectSingleNode("id").InnerText);
			//	Console.WriteLine(voucher.SelectSingleNode("quantity").InnerText);
			//}
		}
	}
}
