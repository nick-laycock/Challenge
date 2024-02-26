using Challenge.Infrastructure.Services;

namespace Challenge.Application;

public class Program
{
    public static void Main(string[] args)
    {
        // Validate args length before use

        string filePath = "data.log";
        var reader = new LogReader(new FileWrapperService());
        var logs = reader.ReadLogs(filePath);
        var logAnalyser = new LogAnalyser(logs);
        string[] topUrls = logAnalyser.TopUrls(3);
        
        Console.WriteLine($"Top 3 URLs: {string.Join(", ", logAnalyser.TopUrls(3))}");
        Console.WriteLine($"Unique IP Address count: {string.Join(", ", logAnalyser.NumberOfUniqueIpAddresses())}");
        Console.WriteLine($"Unique IP Address count: {string.Join(", ", logAnalyser.MostActiveIpAddresses(3))}");
    }
}