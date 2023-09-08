using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchFile {
	/// <summary>
	/// This is the model we receive from SSI for a PrintLabel API call.
	/// </summary>
	internal class PrintLabelResponse {

		/// <summary>
		/// The unique Starshipit numeric identifier for the order.
		/// </summary>
		[JsonProperty("order_id")]
		public int StarshipitOrderID { get; set; }

		/// <summary>
		/// The iSAMS order identifier.
		/// </summary>
		[JsonProperty("order_number")]
		public string OrderID { get; set; }

		/// <summary>
		/// Name of the carrier used for shipment delivery.
		/// </summary>
		[JsonProperty("carrier_name")]
		public string CarrierName { get; set; }

		/// <summary>
		/// List of tracking numbers.
		/// </summary>
		[JsonProperty("tracking_numbers")]
		public List<string> TrackingNumbers { get; set; }

		/// <summary>
		/// List of base64 string which can be converted to PDF files for printing.
		/// </summary>
		[JsonProperty("labels")]
		public List<string> Labels { get; set; }

		/// <summary>
		/// List of label type codes which will match the label in order.
		/// </summary>
		/// <remarks>
		/// Not implemented in current version.
		/// </remarks>
		[JsonProperty("label_types")]
		public List<string> LabelTypes { get; set; }

		/// <summary>
		/// Determines whether the request was successfully submitted.
		/// </summary>
		[JsonProperty("success")]
		public bool Success { get; set; }

		/// <summary>
		/// List of detailed errors.
		/// </summary>
		[JsonProperty("errors")]
		public List<Error> Errors { get; set; }

	}
}
