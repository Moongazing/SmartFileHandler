namespace Moongazing.SmartFileHandler;

public class FileProcessingService<T> where T : class, new()
{
    private readonly FileProcessorFactory<T> factory;

    public FileProcessingService()
    {
        factory = new FileProcessorFactory<T>();
    }

    public async Task ProcessFileAsync(string filePath)
    {
        var fileType = Path.GetExtension(filePath).TrimStart('.');
        var processor = factory.GetProcessor(fileType);

        var data = await processor.ReadAsync(filePath);
        Console.WriteLine($"Processed {data.Count()} records from {filePath}");

        var outputFilePath = Path.Combine(Path.GetDirectoryName(filePath)!, $"output_{Path.GetFileName(filePath)}");
        await processor.WriteAsync(outputFilePath, data);
    }
}
