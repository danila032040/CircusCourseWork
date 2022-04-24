using System;
using System.IO;
using System.Xml.Serialization;
using CircusDataAccessLibrary.Helpers.Interfaces;

namespace CircusDataAccessLibrary.Helpers.Implementations
{
    public class XmlConverter : IXmlConverter
    {
        public string ConvertToXml<T>(T obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var sw = new StringWriter();
            xmlSerializer.Serialize(sw, obj);
            return sw.ToString();
        }

        public T ConvertFromXml<T>(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var sw = new StringReader(xml);
            return  (T?) xmlSerializer.Deserialize(sw) ?? throw new ArgumentException($"{nameof(xml)} isn`t a Xml format string.");
        }
    }
}