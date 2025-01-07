using SwexFilter.Data;
using SwexFilter.Models;

namespace SwexFilter.Tests.Data;

public class SwexImportServiceTests
{
    [Fact]
    public void ImportRunes()
    {
        // Arrange
        var filePath = "Resources/sampleTestFile.json";
        // Act
        var runes = SwexImportService.ImportRunes(filePath);
        // Assert
        Assert.Contains(new SwexRune(), runes);
    }
}