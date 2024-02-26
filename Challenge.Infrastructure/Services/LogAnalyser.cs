using Challenge.Core;
using Challenge.Core.Entities;

namespace Challenge.Infrastructure.Services;

public class LogAnalyser: ILogAnalyser
{
    private readonly IEnumerable<LogDetails> _logDetails;

    public LogAnalyser(IEnumerable<LogDetails> logDetails)
    {
        _logDetails = logDetails;
    }
    public int NumberOfUniqueIpAddresses()
    {
        return _logDetails.Select(log => log.IpAddress).Distinct().Count();
    }

    public string[] TopUrls(int numberOfResults)
    {
        return _logDetails.GroupBy(log => log.Url)
            .OrderByDescending(group => group.Count())
            .Take(numberOfResults)
            .Select(group => group.Key)
            .ToArray();
    }

    public string[] MostActiveIpAddresses(int numberOfResults)
    {
        return _logDetails.GroupBy(log => log.IpAddress)
            .OrderByDescending(group => group.Count())
            .Take(numberOfResults)
            .Select(group => group.Key)
            .ToArray();
    }
}