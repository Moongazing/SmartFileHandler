using Moongazing.SmartFileHandler.Interfaces;
using Newtonsoft.Json;
using System.Xml;

namespace Moongazing.SmartFileHandler.Processors;

public class JsonFileProcessor<T> : IFileProcessor<T> where T : class, new()
{
    public async Task<IEnumerable<T>> ReadAsync(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
    }

    public async Task WriteAsync(string filePath, IEnumerable<T> data)
    {
        var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
        await File.WriteAllTextAsync(filePath, json);
    }
}