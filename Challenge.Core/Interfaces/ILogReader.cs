using Challenge.Core.Entities;

namespace Challenge.Core;

public interface ILogReader
{
    IEnumerable<LogDetails> ReadLogs(string fileName);
}