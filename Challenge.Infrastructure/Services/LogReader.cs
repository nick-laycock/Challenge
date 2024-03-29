﻿using System.Text.RegularExpressions;
using Challenge.Core;
using Challenge.Core.Entities;
using Challenge.Services.Interfaces;
using log4net;

namespace Challenge.Infrastructure.Services;

public class LogReader : ILogReader
{
    private readonly IFileWrapper _fileWrapper;
    private readonly string _pattern = @"^(\S+) \S+ \S+ \[(\d{2}\/\w+\/\d{4}:\d{2}:\d{2}:\d{2} [+-]\d{4})\] ""(GET|POST|PUT|DELETE) (\S+) HTTP\/1\.\d"" (\d{3}) (\d+) ""(\S+)"" ""([^""]+)""";
    public LogReader(IFileWrapper fileWrapper)
    {
        _fileWrapper = fileWrapper ?? throw new ArgumentNullException(nameof(fileWrapper));
    }
     
    public IEnumerable<LogDetails> ReadLogs(string filePath)
    {
        try
        {
            var fileLogEntries = _fileWrapper.ReadAllLines(filePath);
            return ParseLogs(fileLogEntries);
        }
        catch (FileNotFoundException)
        {
            //TODO: Log the exception and decide if you want to throw it again or just return an empty result
            return new List<LogDetails>();
        }
    }

    private List<LogDetails> ParseLogs(string[] fileLogEntries)
    {
        List<LogDetails> logDetails = new List<LogDetails>();
        foreach (var log in fileLogEntries)
        {
            // Define a regular expression pattern to match the IP address and URL
                
            

            // Use Regex to match the pattern in the log entry
            Match match = Regex.Match(log, _pattern);

            // Check if the pattern is matched
            if (match.Success)
            {
                // Extract the IP address and URL from the matched groups
                string ipAddress = match.Groups[1].Value;
                string url = match.Groups[4].Value;

                logDetails.Add(new LogDetails(ipAddress, url));
            }
            else
            {
                Console.WriteLine("Log entry does not match the expected pattern.");
            }
        }

        return logDetails;
    }
}