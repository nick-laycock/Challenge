namespace Challenge.Core.Entities;

public class LogDetails
{
    public LogDetails(string ipAddress, string url)
    {
        IpAddress = ipAddress;
        Url = url;
    }

    public string IpAddress { get; private set; }
    public string Url { get; private set; }
}