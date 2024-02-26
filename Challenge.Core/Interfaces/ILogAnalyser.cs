namespace Challenge.Core;

public interface ILogAnalyser
{
    int NumberOfUniqueIpAddresses();

    string[] TopUrls(int numberOfResults);

    string[] MostActiveIpAddresses(int numberOfResults);
}   