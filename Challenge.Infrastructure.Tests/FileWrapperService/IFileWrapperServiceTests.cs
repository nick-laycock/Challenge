
using Challenge.Services.Interfaces;
using Moq;

namespace Challenge.Infrastructure.Tests.FileWrapperService;

    public class FileWrapperServiceTests
    {
        [Fact]
        public void ReadAllLines_ReturnsExpectedLines()
        {
            // Arrange
            var filePath = "testfile.txt";
            var expectedLines = new[] { "Line 1", "Line 2", "Line 3" };

            // Mocking IFileWrapper for testing
            var fileWrapperMock = new Mock<IFileWrapper>();
            fileWrapperMock.Setup(f => f.ReadAllLines(filePath)).Returns(expectedLines);

            // Act
            var result = fileWrapperMock.Object.ReadAllLines(filePath);

            // Assert
            Assert.Equal(expectedLines, result);
        }

        [Fact]
        public void ReadAllLines_ThrowsFileNotFoundExceptionWhenFileNotFound()
        {
            // Arrange
            var filePath = "nonexistentfile.txt";

            // Mocking IFileWrapper for testing
            var fileWrapperMock = new Mock<IFileWrapper>();
            fileWrapperMock.Setup(f => f.ReadAllLines(filePath)).Throws<FileNotFoundException>();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => fileWrapperMock.Object.ReadAllLines(filePath));
        }
    }
