using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ScratchXML
{
	public static class XMLHelper
	{
		//This contains a Memory Leak.
		//See here for better code: https://stackoverflow.com/questions/369792/how-to-deserialize-only-part-of-an-xml-document-in-c-sharp
		public static T DeserializeXml<T>(this string @this, string innerStartTag = null)
		{
			using (StringReader stringReader = new StringReader(@this))
			using (XmlReader xmlReader = XmlReader.Create(stringReader))
			{
				if (innerStartTag != null)
				{
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
	}
}
