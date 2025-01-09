using Moongazing.SmartFileHandler.Interfaces;
using System.Xml.Serialization;

namespace Moongazing.SmartFileHandler.Processors
{
    public class XmlFileProcessor<T> : IFileProcessor<T> where T : class, new()
    {
        public async Task<IEnumerable<T>> ReadAsync(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using var reader = new FileStream(filePath, FileMode.Open);
            return (List<T>)(serializer.Deserialize(reader) ?? new List<T>());
        }

        public async Task WriteAsync(string filePath, IEnumerable<T> data)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using var writer = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(writer, data);
            await writer.FlushAsync();
        }
    }
}