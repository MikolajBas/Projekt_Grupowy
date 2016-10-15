using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Common.Serializers
{
    public class DataSerializer
    {
        public DataSerializer()
        {
        }

        public T Deserialize<T>(string data)
        {
            try
            {
                var stream = GenerateStream(data);

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Serialize<T>(T obj)
        {
            try
            {
                var writer = new StringWriter();

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MemoryStream GenerateStream(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }
    }
}
