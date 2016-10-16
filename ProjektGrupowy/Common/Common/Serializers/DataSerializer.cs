using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using Common.Logging;

namespace Common.Serializers
{
    public class DataSerializer
    {
        private readonly Logger _logger = new Logger("Common.Serializers.DataSerializer");

        public DataSerializer()
        {
        }

        public T Deserialize<T>(string data)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                return (T)serializer.Deserialize(data, typeof(T));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }

        public string Serialize<T>(T obj)
        {
            try
            {
                var serializer = new JavaScriptSerializer();
                return serializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }


        public T XmlDeserialize<T>(string data)
        {
            try
            {
                var stream = GenerateStream(data);

                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }

        public string XmlSerialize<T>(T obj)
        {
            try
            {
                var writer = new StringWriter();

                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
        }

        private MemoryStream GenerateStream(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? string.Empty));
        }
    }
}
