using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ScratchXML.Models {
	/// <summary>
	/// Object representing an Order to be sent to the Pronto Avenue endpoint.
	/// </summary>
	[XmlRoot("ProntoOrder")]
	public class CreateSalesOrder_Request {
		/// <summary>
		/// Unique Debtor ID.
		/// </summary>
		[XmlElement("AccountCode")]
		public string AccountCode { get; set; }

		/// <summary>
		/// Branch code of order's dispatch point store.
		/// </summary>
		[XmlElement("BranchCode")]
		public string BranchCode { get; set; }

		/// <summary>
		/// iSAMS OrderID.
		/// </summary>
		[XmlElement("OrderID")]
		public int OrderID { get; set; }

		/// <summary>
		/// iSAMS OrderID (repeated for duplicate check on Pronto's side).
		/// </summary>
		public int OrderID2 {
			get { return this.OrderID; }
			set { this.OrderID = value; }
		}

		/// <summary>
		/// iSAMS OrderID repeated 
		/// Used by child/split orders to reference Parent order.
		/// </summary>
		public int OrderID3 {
			get { return this.OrderID; }
			set { this.OrderID = value; }
		}

		/// <summary>
		/// Sale priority code.
		/// </summary>
		/// <remarks>Configurable in tblWebsites_Config_File</remarks>
		[XmlElement("SalePriority")]
		public string SalePriority { get; set; }

		/// <summary>
		/// Employee code.
		/// </summary>
		/// <remarks>Configurable in tblWebsites_Config_File</remarks>
		[XmlElement("EmployeeCode")]
		public string EmployeeCode { get; set; }

		/// <summary>
		/// Territory Code
		/// </summary>
		/// <remarks>Configurable in tblWebsites_Config_File</remarks>
		[XmlElement("TerritoryCode")]
		public string TerritoryCode { get; set; }

		/// <summary>
		/// Date
		/// </summary>
		/// <remarks>The date the order was placed in AEST</remarks>
		[XmlElement("Date")]
		public string Date { get; set; }

		/// <summary>
		/// List of order addresses.
		/// </summary>
		/// <remarks>At this stage this is only ever one address - the order delivery address.</remarks>
		[XmlArray("Addresses")]
		[XmlArrayItem("ProntoAddress")]
		public List<CreateSalesOrderAddress_Request> Addresses { get; set; }

		/// <summary>
		/// List of order lines. This includes orderitems, freight and order-based and item-based discounts.
		/// </summary>
		[XmlArray("Lines")]
		[XmlArrayItem("ProntoLine")]
		public List<CreateSalesOrderLine_Request> Lines { get; set; }

		/// <summary>
		/// List of order payment transactions.
		/// </summary>
		[XmlArray("Payments")]
		[XmlArrayItem("ProntoPayment")]
		public List<CreateSalesOrderPayment_Request> Payments { get; set; }
	}

	/// <summary>
	/// Object representing an Order Address to be sent to the Pronto Avenue endpoint.
	/// </summary>
	[XmlRoot("ProntoAddress")]
	public class CreateSalesOrderAddress_Request {
		/// <summary>
		/// Type of address.
		/// </summary>
		/// <remarks>Always "DA" indicating a delivery address.</remarks>
		[XmlElement("AddressType")]
		public string AddressType { get; set; }

		/// <summary>
		/// iSAMS Company field.
		/// </summary>
		[XmlElement("Company")]
		public string Company { get; set; }

		/// <summary>
		/// iSAMS Street address field.
		/// </summary>
		[XmlElement("Street")]
		public string Street { get; set; }

		/// <summary>
		/// iSAMS Extra Information field.
		/// </summary>
		[XmlElement("ExtraInformation")]
		public string ExtraInformation { get; set; }

		/// <summary>
		/// iASMS Suburb field.
		/// </summary>
		[XmlElement("Suburb")]
		public string Suburb { get; set; }

		/// <summary>
		/// iSAMS State field.
		/// </summary>
		[XmlElement("State")]
		public string State { get; set; }

		/// <summary>
		/// iSAMS Country field.
		/// </summary>
		[XmlElement("Country")]
		public string Country { get; set; }

		/// <summary>
		/// iSAMS City field.
		/// </summary>
		[XmlElement("City")]
		public string City { get; set; }

		/// <summary>
		/// iSAMS postcode field.
		/// </summary>
		[XmlElement("Postcode")]
		public string Postcode { get; set; }

		/// <summary>
		/// iSAMS phone field.
		/// </summary>
		[XmlElement("ContactPhone")]
		public string ContactPhone { get; set; }
	}

	/// <summary>
	/// Object representing an Order Item/Freight/Discount line to be sent to the Pronto Avenue endpoint.
	/// </summary>
	[XmlRoot("ProntoLine")]
	public class CreateSalesOrderLine_Request {
		/// <summary>
		/// Indicates the Pronto Avenue line type.
		/// </summary>
		/// <remarks>
		/// SN - Order Item
		/// SS - Discount
		/// SC - Freight
		/// </remarks>
		[XmlElement("LineType")]
		public string LineType { get; set; }

		/// <summary>
		/// iSAMS Order Item ID.
		/// </summary>
		[XmlElement("OrderItemID")]
		public string OrderItemID { get; set; }

		/// <summary>
		/// iSAMS product item Foreign Identity.
		/// </summary>
		[XmlElement("ForeignIdentity")]
		public string ForeignIdentity { get; set; }

		/// <summary>
		/// Unit price excluding discount.
		/// </summary>
		[XmlElement("UnitPrice")]
		public decimal UnitPrice { get; set; }

		/// <summary>
		/// Item tax code.
		/// </summary>
		[XmlElement("TaxCode")]
		public string TaxCode { get; set; }

		/// <summary>
		/// Quantity of the item.
		/// </summary>
		[XmlElement("Quantity")]
		public int Quantity { get; set; }

		/// <summary>
		/// Pronto Charge Type Flag.
		/// </summary>
		/// <remarks>"0" for freight, null for everything else.</remarks>
		[XmlElement("ChargeTypeFlag")]
		public string ChargeTypeFlag { get; set; }

		/// <summary>
		/// Description of the line.
		/// </summary>
		/// <remarks>
		/// Item-level discount lines will contain the orderitem ID here.
		/// Otherwise this will contain the freight provider name or a description of the line (such as "order-based discount").
		/// </remarks>
		[XmlElement("LineDescription")]
		public string LineDescription { get; set; }
	}

	/// <summary>
	/// Object representing a Payment to be sent to the Pronto Avenue endpoint.
	/// </summary>
	[XmlRoot("ProntoPayment")]
	public class CreateSalesOrderPayment_Request {
		/// <summary>
		/// Amount the payment was for.
		/// </summary>
		[XmlElement("Amount")]
		public decimal Amount { get; set; }

		/// <summary>
		/// ID of online warehouse branch.
		/// </summary>
		[XmlElement("StoreID")]
		public string StoreID { get; set; }

		/// <summary>
		/// Terminal Number.
		/// </summary>
		/// <remarks>Currently always 1 unless configured otherwise.</remarks>
		[XmlElement("TerminalNumber")]
		public string TerminalNumber { get; set; }

		/// <summary>
		/// Payment Method Code.
		/// </summary>
		/// <remarks>
		/// AE - Amex
		/// DC - Diners
		/// M - Master Card
		/// V - Visa Card
		/// PP - PayPal
		/// AF - Afterpay
		/// ZP - Zip Pay
		/// Y - Electronic Funds Transfer Cred
		/// AP - Apple Pay
		/// AL - ALIPAY
		/// UP - Union Pay
		/// </remarks>
		// JACO: Update list to include new types?
		[XmlElement("PaymentMethod")]
		public string PaymentMethod { get; set; }
	}
}
