using SwexFilter.Data;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Tests.Data;

public class SwexImportServiceTests
{
    [Fact]
    public void ImportRunes()
    {
        // Arrange
        const string filePath = "Resources/sampleTestFile.json";
        var swexRune = new SwexRune
        {
            Id = 47916329687,
            Slot = RuneSlot.Slot1,
            Rarity = RuneRarity.Legendary,
            Stars = RuneStars.Six,
            Set = RuneSet.Fight,
            Level = 15,
            MainStat = RuneTypeStat.AtkFlat,
            MainStatValue = 160,
            InnateStat = new RuneSubProperty { RuneTypeStat = RuneTypeStat.CriRate, Value = 6 },
            SubStat1 = new RuneSubProperty { RuneTypeStat = RuneTypeStat.HpPercentage, Value = 8 },
            SubStat2 = new RuneSubProperty { RuneTypeStat = RuneTypeStat.Accuracy, Value = 19 },
            SubStat3 = new RuneSubProperty { RuneTypeStat = RuneTypeStat.CriDmg, Value = 18 },
            SubStat4 = new RuneSubProperty { RuneTypeStat = RuneTypeStat.Spd, Value = 6 },
            Monster = "Icaru"
        };
        // Act
        var runes = SwexImportService.ImportRunes(filePath);
        // Assert
        Assert.Single(runes.Where(rune => rune.Equals(swexRune)).ToList());
    }
}