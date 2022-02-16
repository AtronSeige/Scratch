using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ScratchXML {
	public static class XMLHelper {
		//This contains a Memory Leak.
		//See here for better code: https://stackoverflow.com/questions/369792/how-to-deserialize-only-part-of-an-xml-document-in-c-sharp
		public static T DeserializeXml<T>(this string @this, string innerStartTag = null) {
			using (StringReader stringReader = new StringReader(@this))
			using (XmlReader xmlReader = XmlReader.Create(stringReader)) {
				if (innerStartTag != null) {
					xmlReader.ReadToDescendant(innerStartTag);
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(innerStartTag));
					return (T)xmlSerializer.Deserialize(xmlReader.ReadSubtree());
				}
				return (T)new XmlSerializer(typeof(T)).Deserialize(xmlReader);
			}
		}

		public static T DeserializeXml2<T>(this string @this) {

			// This is for security and should not be changed unless you *really* need to, and know what you are doing.
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings {
				DtdProcessing = DtdProcessing.Prohibit,
				XmlResolver = null
			};

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

			// Create an XmlReader that uses XmlNodeReader and applies the XmlReaderSettings for security.
			//using (XmlReader xmlReader = XmlReader.Create(new XmlNodeReader(xml), xmlReaderSettings)) {
			//	return (T)xmlSerializer.Deserialize(xmlReader);
			//}
			using (StringReader tr = new StringReader(@this)) {
				using (XmlReader xr = XmlReader.Create(tr)) {
					return (T)new XmlSerializer(typeof(T)).Deserialize(xr);
				}
			}
		}
		public static T DeserializeXml2<T>(this string @this, string rootAttribute) {

			// This is for security and should not be changed unless you *really* need to, and know what you are doing.
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings {
				DtdProcessing = DtdProcessing.Prohibit,
				XmlResolver = null
			};

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

			// Create an XmlReader that uses XmlNodeReader and applies the XmlReaderSettings for security.
			//using (XmlReader xmlReader = XmlReader.Create(new XmlNodeReader(xml), xmlReaderSettings)) {
			//	return (T)xmlSerializer.Deserialize(xmlReader);
			//}

			using (StringReader tr = new StringReader(@this)) {
				using (XmlReader xr = XmlReader.Create(tr)) {
					return (T)new XmlSerializer(typeof(T), new XmlRootAttribute(rootAttribute)).Deserialize(xr);
				}
			}
		}

		public static T DeserializeXml<T>(this XmlDocument self, string innerStartTag = null) {
			// This is for security and should not be changed unless you *really* need to, and know what you are doing.
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings {
				DtdProcessing = DtdProcessing.Prohibit,
				XmlResolver = null
			};

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

			// Create an XmlReader that uses XmlNodeReader and applies the XmlReaderSettings for security.
			using (XmlReader xmlReader = XmlReader.Create(new XmlNodeReader(self), xmlReaderSettings)) {
				return (T)xmlSerializer.Deserialize(xmlReader);
			}

		}

		public static XmlDocument SerializeToXmlDocument(this object self) {

			Type serializeType = self.GetType();
			XmlSerializer serializer = new XmlSerializer(serializeType);

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			//if (!includeXmlDeclaration) {
			//	// Omit the xml declaration in output.
			//	settings.OmitXmlDeclaration = true;
			//}

			using (StringWriter sw = new StringWriter()) {
				using (XmlWriter xw = XmlWriter.Create(sw, settings)) {
					//		if (!includeXmlNamespace) {
					// Serialize with namespaces removed.
					XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
					xns.Add(string.Empty, string.Empty);
					serializer.Serialize(xw, self, xns);
					//		} else {
					//			// Serialize using default namespace settings.
					//			serializer.Serialize(xw, objectToSerialize);
					//		}

					xw.Flush();
					XmlDocument returnDocument = new XmlDocument();
					returnDocument.LoadXml(sw.ToString());
					return returnDocument;
				}
			}
		}

		// Other Xml Serialization that could be better. Check
		// Jaco: Make this pretty.

		///// <summary>
		///// Deserialize an XmlDocument to an instance of <typeparamref name="T"/>.
		///// </summary>
		///// <typeparam name="T">The type to deserialize the Xml to.</typeparam>
		///// <param name="xml">The <see cref="XmlDocument"/> that represents the object.</param>
		///// <param name="xmlRootElement">The root element. Useful when parsing arrays. Optional.</param>
		///// <returns>An instance of <typeparamref name="T"/>.</returns>
		///// <exception cref="ArgumentNullException">Thrown when <paramref name="xml"/> is null.</exception>
		///// <exception cref="ArgumentException">Thrown when <paramref name="xml"/> is empty.</exception>
		//public static T DeserializeXmlTo<T>(XmlDocument xml, string xmlRootElement = null) {
		//	if (xml == null) {
		//		throw new ArgumentNullException("xml");
		//	}

		//	if (String.IsNullOrWhiteSpace(xml.OuterXml)) {
		//		throw new ArgumentException("xml is empty");
		//	}

		//	return DeserializeXML<T>(XmlReader.Create(new XmlNodeReader(xml), GetSafeXmlReaderSettings()), xmlRootElement);
		//}

		///// <summary>
		///// Deserialize a Xml string to an instance of <typeparamref name="T"/>.
		///// </summary>
		///// <typeparam name="T">The type to deserialize the Xml to.</typeparam>
		///// <param name="xml">The <see cref="string"/> that represents the object.</param>
		///// <param name="xmlRootElement">The root element. Useful when parsing arrays. Optional.</param>
		///// <returns>An instance of <typeparamref name="T"/>.</returns>
		///// <exception cref="ArgumentNullException">Thrown when <paramref name="xml"/> is null.</exception>
		//public static T DeserializeXmlStringTo<T>(string xml, string xmlRootElement = null) {
		//	if (xml == null) {
		//		throw new ArgumentNullException("xml");
		//	}

		//	using (StringReader stringReader = new StringReader(xml)) {
		//		return DeserializeXML<T>(XmlReader.Create(stringReader, GetSafeXmlReaderSettings()), xmlRootElement);
		//	}
		//}

		///// <summary>
		///// Deserialize the content of the <paramref name="xmlReader"/> to <typeparamref name="T"/>.
		///// </summary>
		///// <typeparam name="T">The type to deserialize the Xml to.</typeparam>
		///// <param name="xmlReader">The <see cref="XmlReader"/> that contains the Xml.</param>
		///// <param name="xmlRootElement">The root element. Useful when parsing arrays. Optional.</param>
		///// <returns>An instance of <typeparamref name="T"/>.</returns>
		//private static T DeserializeXML<T>(XmlReader xmlReader, string xmlRootElement = null) {
		//	if (!string.IsNullOrWhiteSpace(xmlRootElement)) {
		//		return (T)new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootElement)).Deserialize(xmlReader);

		//	} else {
		//		return (T)new XmlSerializer(typeof(T)).Deserialize(xmlReader);
		//	}
		//}

		///// <summary>
		///// Serialize and object to Xml.
		///// </summary>
		///// <param name="o">The object to be serialized.</param>
		///// <returns>An <see cref="XmlDocument"/> of the object.</returns>
		//private static XmlDocument SerializeToXMLDocument(object o) {
		//	return o.ToXmlSerialized(false, false);
		//}

		///// <summary>
		///// Returns settings that allow for safe parsing of Xml.
		///// </summary>
		///// <returns>A <see cref="XmlReaderSettings"/> with save settings.</returns>
		//private static XmlReaderSettings GetSafeXmlReaderSettings() {
		//	// This is for security and should not be changed unless you *really* need to, and know what you are doing.
		//	return new XmlReaderSettings {
		//		DtdProcessing = DtdProcessing.Prohibit,
		//		XmlResolver = null
		//	};
		//}
	}
}
