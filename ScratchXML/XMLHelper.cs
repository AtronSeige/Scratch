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
			using (var stringReader = new StringReader(@this))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				if (innerStartTag != null)
				{
					xmlReader.ReadToDescendant(innerStartTag);
					var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(innerStartTag));
					return (T)xmlSerializer.Deserialize(xmlReader.ReadSubtree());
				}
				return (T)new XmlSerializer(typeof(T)).Deserialize(xmlReader);
			}
		}
	}
}
