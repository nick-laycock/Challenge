using Challenge.Application;
using Challenge.Infrastructure.Services;
using Challenge.Services.Interfaces;
using Xunit;
using Moq;

namespace Challenge.Console.Tests
{
    public class LogAnalyserTests
    {
        [Fact]
        public void Main_ExecutesSuccessfully()
        {
            // Arrange
            var filePath = "test.log";

            // Act
            Program.Main(new string[] { filePath });

            // Assert
            // Add assertions if needed based on the side effects or output of the Main method
        }
    }
}
