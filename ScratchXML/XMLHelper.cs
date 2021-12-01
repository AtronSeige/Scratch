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
	}
}
