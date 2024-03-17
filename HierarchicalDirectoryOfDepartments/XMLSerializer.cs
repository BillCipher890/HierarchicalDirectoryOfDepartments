using HierarchicalDirectoryOfDepartments.Models.HierarhyModels;
using System.Xml.Serialization;

namespace HierarchicalDirectoryOfDepartments
{
    public static class XMLSerializer
    {
        public static MemoryStream SerializeToXML<T>(T model)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, model);
            memoryStream.Position = 0;
            return memoryStream;
        }

        public static List<Company> DeserializeFromXML(IFormFile file)
        {
            if (file == null)
                throw new Exception("File is broken!");

            using MemoryStream memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            memoryStream.Position = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Company>));
            return (List<Company>)serializer.Deserialize(memoryStream);
        }
    }
}
