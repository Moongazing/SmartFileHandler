using Moongazing.SmartFileHandler.Interfaces;
using Moongazing.SmartFileHandler.Processors;

namespace Moongazing.SmartFileHandler;

public class FileProcessorFactory<T> where T : class, new()
{
    public IFileProcessor<T> GetProcessor(string fileType)
    {
        return fileType.ToLower() switch
        {
            "csv" => new CsvFileProcessor<T>(),
            "json" => new JsonFileProcessor<T>(),
            "xml" => new XmlFileProcessor<T>(),
            _ => throw new NotSupportedException("Unsupported file type.")
        };
    }
}
