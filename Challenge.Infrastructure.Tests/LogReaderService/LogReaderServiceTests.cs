using Challenge.Core.Entities;
using Challenge.Infrastructure.Services;
using Challenge.Services.Interfaces;
using Moq;

namespace Challenge.Infrastructure.Tests;

public class LogReaderServiceTests
{
    [Fact]
    public void ReadLogs_ReturnsLogDetailsList_WhenFileExists()
    {
        var filePath = "sampleFilePath.txt";
        var mockFile = new Mock<IFileWrapper>();
        mockFile.Setup(x => x.ReadAllLines(filePath))
            .Returns(new[] { "Sample log entry 1", "Sample log entry 2" });

        var logReader = new LogReader(mockFile.Object);

        // Act
        var result = logReader.ReadLogs(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<LogDetails>>(result);
    }
    
    [Fact]
    public void ReadLogs_ReturnsEmptyList_WhenFileDoesNotExist()
    {
        // Arrange
        var filePath = "nonexistentFilePath.txt";
        var mockFile = new Mock<IFileWrapper>();
        mockFile.Setup(x => x.ReadAllLines(filePath))
            .Throws<FileNotFoundException>();

        var logReader = new LogReader(mockFile.Object);

        // Act
        var result = logReader.ReadLogs(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.Empty((List<LogDetails>)result);
    }
    
    [Fact]
    public void ReadLogs_ReturnsLogDetailsList_CorrectlyFromMockedOutput()
    {
        // Arrange
        var filePath = "sampleFilePath.txt";
        var mockFile = new Mock<IFileWrapper>();
        mockFile.Setup(x => x.ReadAllLines(filePath))
            .Returns(new[] { 
                "79.125.00.21 - - [10/Jul/2018:20:03:40 +0200] \"GET /newsletter/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/5.0)\"", 
                "50.112.00.11 - admin [11/Jul/2018:17:31:05 +0200] \"GET /hosting/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6\"",
                "72.44.32.10 - - [09/Jul/2018:15:48:07 +0200] \"GET / HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (compatible; MSIE 10.6; Windows NT 6.1; Trident/5.0; InfoPath.2; SLCC1; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 2.0.50727) 3gpp-gba UNTRUSTED/1.0\" junk extra"
            });
        
        // Act
        var logReader = new LogReader(mockFile.Object);

        // Act
        var result = logReader.ReadLogs(filePath);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());
        Assert.Equal("79.125.00.21", result.ElementAt(0).IpAddress);
        Assert.Equal("50.112.00.11", result.ElementAt(1).IpAddress);
        Assert.Equal("72.44.32.10", result.ElementAt(2).IpAddress);
        Assert.Equal("/newsletter/", result.ElementAt(0).Url);
        Assert.Equal("/hosting/", result.ElementAt(1).Url);
        Assert.Equal("/", result.ElementAt(2).Url);
    }
}