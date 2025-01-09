using Moongazing.SmartFileHandler.Interfaces;
using System.Globalization;

namespace Moongazing.SmartFileHandler.Processors
{
    public class CsvFileProcessor<T> : IFileProcessor<T> where T : class, new()
    {
        public async Task<IEnumerable<T>> ReadAsync(string filePath)
        {
            var result = new List<T>();
            using var reader = new StreamReader(filePath);
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            result = csv.GetRecords<T>().ToList();
            return await Task.FromResult(result);
        }

        public async Task WriteAsync(string filePath, IEnumerable<T> data)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(data);
            await writer.FlushAsync();
        }
    }
}