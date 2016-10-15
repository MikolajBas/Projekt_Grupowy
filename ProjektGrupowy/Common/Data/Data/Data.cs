using System.Xml.Serialization;

namespace Data.Data
{
    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement("Ip")]
        public string ip;

        [XmlElement("Url")]
        public string url;
    }
}
