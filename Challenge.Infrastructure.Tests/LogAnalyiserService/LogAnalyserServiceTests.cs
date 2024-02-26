using System.Collections.Generic;
using Challenge.Core;
using Challenge.Core.Entities;
using Challenge.Infrastructure.Services;
using Xunit;

namespace Challenge.Infrastructure.Tests;

public class LogAnalyserTests
{
    [Fact]
    public void NumberOfUniqueIpAddresses_ReturnsCorrectCount()
    {
        // Arrange
        var logDetails = new List<LogDetails>
        {
            new LogDetails("192.168.0.1", "/page1"),
            new LogDetails("192.168.0.2", "/page2"),
            new LogDetails("192.168.0.1", "/page3"),
            new LogDetails("192.168.0.3", "/page4")
        };

        var logAnalyser = new LogAnalyser(logDetails);

        // Act
        var result = logAnalyser.NumberOfUniqueIpAddresses();

        // Assert
        Assert.Equal(3, result); // 3 unique IP addresses in the example data
    }

    [Fact]
    public void TopUrls_ReturnsCorrectUrls()
    {
        // Arrange
        var logDetails = new List<LogDetails>
        {
            new LogDetails("192.168.0.1", "/page1"),
            new LogDetails("192.168.0.2", "/page1"),
            new LogDetails("192.168.0.1", "/page3"),
            new LogDetails("192.168.0.3", "/page3"),
            new LogDetails("192.168.0.1", "/page5")
        };

        var logAnalyser = new LogAnalyser(logDetails);

        // Act
        var result = logAnalyser.TopUrls(2);

        // Assert
        Assert.Equal(new[] { "/page1", "/page3" }, result);
    }

    [Fact]
    public void MostActiveIpAddresses_ReturnsCorrectAddresses()
    {
        // Arrange
        var logDetails = new List<LogDetails>
        {
            new LogDetails("192.168.0.1","/page1"),
            new LogDetails("192.168.0.2", "/page2" ),
            new LogDetails( "192.168.0.1", "/page3" ),
            new LogDetails( "192.168.0.3", "/page4" ),
            new LogDetails("192.168.0.1", "/page5" )
        };

        var logAnalyser = new LogAnalyser(logDetails);

        // Act
        var result = logAnalyser.MostActiveIpAddresses(2);

        // Assert
        Assert.Equal(new[] { "192.168.0.1", "192.168.0.2" }, result);
    }
}
