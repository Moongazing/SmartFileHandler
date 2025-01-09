using Moongazing.SmartFileHandler;

namespace Moongazing.SmartFileHandler.SampleUsing;

class Program
{
    static async Task Main(string[] args)
    {
        var service = new FileProcessingService<MyDataClass>();
        await service.ProcessFileAsync("data.csv");
        await service.ProcessFileAsync("data.json");
        await service.ProcessFileAsync("data.xml");
    }
}

public class MyDataClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
}