using Xunit;
using Moq;
using Challenge.Core.Entities;
using Challenge.Core;
public class ProgramTests
{
    [Fact]
    public void TestTopUrls()
    {
        // Arrange
        var logs = GetSampleLog();
        var mock = new Mock<ILogAnalyser>();
        mock.Setup(analyser => analyser.TopUrls(3)).Returns(new [] { "http://example.com" });

        var analyser = mock.Object;

        // Act
        var topUrls = analyser.TopUrls(3);

        // Assert
        Assert.Single(topUrls);
        Assert.Equal("http://example.com", topUrls[0]);
    }

    private IEnumerable<LogDetails> GetSampleLog() {
        return new List<LogDetails>
        {
            new LogDetails("192.168.0.1", "http://example.com")
        };
    }
}