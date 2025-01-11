using SwexFilter.Controllers;
using SwexFilter.Data;
using SwexFilter.Models;

namespace SwexFilter.Tests.Controllers;

public class FilterControllerTests
{
    [Theory]
    [InlineData(null, null, null, null, null, null, null, null, true)]
    public void ApplyFiltersToRune(bool isActive,
        string? name,
        int? RelativeScore,
        int? SubPropertiesPresence,
        bool ExcludeEnchantedRune,
        bool ExcludeGrindFromScore,
        bool KeepOnlyIfGemAvailable,
        bool KeepOnlyIfGrindAvailable,
        bool isTrue)
    {
        // Arrange
        var dataContext = new DataContext("filters.json", "runes.json");
        dataContext.Filters.Clear();
        dataContext.ImportRunes(SwexImportService.ImportRunes("Resources/FilterControllersTests.json"));
        var filterController = new FilterController(dataContext);

        dataContext.Filters.Add(new Filter
        {
            Name = name,
            IsActive = isActive,
            RelativeScore = RelativeScore,
            SubPropertiesPresence = SubPropertiesPresence,
            ExcludeEnchantedRune = ExcludeEnchantedRune,
            ExcludeGrindFromScore = ExcludeGrindFromScore,
            KeepOnlyIfGemAvailable = KeepOnlyIfGemAvailable,
            KeepOnlyIfGrindAvailable = KeepOnlyIfGrindAvailable
        });
        var runeToFilter = new SwexRune();
        // Act
        filterController.ApplyFiltersToRune(runeToFilter);
        // Assert
        Assert.Equal(isTrue, runeToFilter.FiltersPassed.Any(filter1 => filter1.Name.Equals(name)));
    }
}