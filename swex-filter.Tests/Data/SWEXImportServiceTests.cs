using Moq;
using SwexFilter.Data;
using SwexFilter.Models;

namespace SwexFilter.Tests.Data;
public class SWEXImportServiceTests
{
    // https://stackoverflow.com/questions/52415325/c-sharp-unit-testing-a-newtonsoft-json-model
    [Fact]
    public void ImportRunes()
    {

        // Arrange
        DataContext dataContext = new("", "");
        SWEXImportService sWEXImportService = new(dataContext);
        var Mock = new Mock<File>();
        Mock.

        // Act
        sWEXImportService.ImportRunes(It.IsAny<string>());

        // Assert
        Assert.True(dataContext.Filters.Contains(new SWEXRune()));
        // Cleanup
        Assert.Fail("todo");
    }
}
