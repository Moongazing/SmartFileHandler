using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.SmartFileHandler.Interfaces;

public interface IFileProcessor<T>
{
    Task<IEnumerable<T>> ReadAsync(string filePath);
    Task WriteAsync(string filePath, IEnumerable<T> data);
}
