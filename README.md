# SmartFileHandler

**SmartFileHandler** is a .NET library designed to process CSV, JSON, and XML files efficiently. It supports automatic file type detection, converting data into generic lists, and line-by-line processing for large files. The library is designed with modern programming patterns and supports asynchronous operations for better performance.

---

## Features

- **Automatic File Type Detection**: Automatically identifies the file type (CSV, JSON, or XML) based on its extension.
- **Generic List Conversion**: Converts data into strongly-typed generic lists for easier processing.
- **Large File Support**: Processes large files line by line to optimize memory usage.
- **Asynchronous Operations**: Provides async methods for file reading and writing to improve responsiveness.
- **Extensibility**: Built with SOLID principles and design patterns (Factory, Strategy) for easy expansion.

---

## Installation

To use **SmartFileHandler** in your .NET project, add the required NuGet packages:

### 1. CsvHelper (for CSV processing)
```bash
dotnet add package CsvHelper

2. Newtonsoft.Json (for JSON processing)

dotnet add package Newtonsoft.Json

3. System.Xml (built-in for XML processing)

No additional package installation is needed for XML functionality.
Getting Started
Example Usage

// Import necessary namespaces
using SmartFileHandler;

public class Program
{
    static async Task Main(string[] args)
    {
        var service = new FileProcessingService<MyDataClass>();
        
        // Process a CSV file
        await service.ProcessFileAsync("data.csv");

        // Process a JSON file
        await service.ProcessFileAsync("data.json");

        // Process an XML file
        await service.ProcessFileAsync("data.xml");
    }
}

public class MyDataClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
}

FileProcessorFactory

FileProcessorFactory dynamically selects the appropriate processor based on the file type.

Supported File Types:

    CSV: Processes .csv files using CsvHelper.
    JSON: Processes .json files using Newtonsoft.Json.
    XML: Processes .xml files using System.Xml.

Project Structure

    Interfaces: Defines IFileProcessor<T> for common operations.
    Processors:
        CsvFileProcessor<T>: Handles CSV files.
        JsonFileProcessor<T>: Handles JSON files.
        XmlFileProcessor<T>: Handles XML files.
    Factory: FileProcessorFactory provides a centralized way to get file processors.
    Service: FileProcessingService<T> integrates file processing with the factory.

Asynchronous Support

All methods are designed to work asynchronously to handle large files efficiently:

    ReadAsync: Reads file data into a generic list.
    WriteAsync: Writes data from a generic list into a file.

Extending the Library

You can add support for other file types (e.g., Excel, YAML) by implementing the IFileProcessor<T> interface and extending the FileProcessorFactory.

Example:

public class ExcelFileProcessor<T> : IFileProcessor<T> where T : class, new()
{
    // Implementation for Excel files
}

Contributing

Contributions are welcome! Please open an issue or submit a pull request with your ideas or improvements.
License

This project is licensed under the MIT License. See the LICENSE file for details.
Acknowledgments

    CsvHelper: For CSV parsing.
    Newtonsoft.Json: For JSON serialization and deserialization.
    System.Xml: For XML processing.
