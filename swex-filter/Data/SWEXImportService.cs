using System.Text.Json;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Data;

public static class SwexImportService
{
    private static string GetJsonData(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static List<SwexRune> ImportRunes(string filePath)
    {
        var jsonContent = GetJsonData(filePath);
        var root = JsonSerializer.Deserialize<JsonRoot>(jsonContent);

        foreach (var monster in root.unit_list)
        foreach (var rune in monster.runes)
        {
            rune.Monster = JsonMappingService.Instance.UnitNameMapping.GetValueOrDefault(monster.id, string.Empty);
            rune.Set = EnumExtensions.GetEnumValueFromKey<RuneSet>(rune.SetKey);
            rune.Slot = EnumExtensions.GetEnumValueFromKey<RuneSlot>(rune.SlotKey);
            rune.Stars =
                EnumExtensions.GetEnumValueFromKey<RuneStars>(rune.RarityKey > 10 ? rune.StarsKey - 10 : rune.StarsKey);
            rune.Rarity = EnumExtensions.GetEnumValueFromKey<RuneRarity>(rune.RarityKey);

            rune.MainStat = EnumExtensions.GetEnumValueFromKey<RuneTypeStat>(rune.MainStatJson[0]);
            rune.MainStatValue = rune.MainStatJson[1];

            rune.InnateStat = rune.InnateStatJson[0] != 0
                ? new RuneSubProperty
                {
                    RuneTypeStat = EnumExtensions.GetEnumValueFromKey<RuneTypeStat>(rune.InnateStatJson[0]),
                    Value = rune.InnateStatJson[1],
                    IsEnchanted = false,
                    GrindAmount = 0
                }
                : null;

            rune.SubStat1 = MapSubProperty(rune.SubStatsJson[0]);
            rune.SubStat2 = MapSubProperty(rune.SubStatsJson[1]);
            rune.SubStat3 = MapSubProperty(rune.SubStatsJson[2]);
            rune.SubStat4 = MapSubProperty(rune.SubStatsJson[3]);
        }

        // Adding to list afters updating, better memory allocation
        var allRunes = new List<SwexRune>();
        foreach (var monster in root.unit_list) allRunes.AddRange(monster.runes);

        allRunes.AddRange(root.runes.Select(rune => new SwexRune { Id = rune.Id, Monster = string.Empty }));

        return allRunes;
    }

    private static RuneSubProperty? MapSubProperty(List<int> secEff)
    {
        return secEff[0] != 0
            ? new RuneSubProperty
            {
                RuneTypeStat = EnumExtensions.GetEnumValueFromKey<RuneTypeStat>(secEff[0]),
                Value = secEff[1],
                IsEnchanted = secEff[2] != 0,
                GrindAmount = secEff[3]
            }
            : null;
    }

    private class JsonRoot
    {
        public List<Monster> unit_list { get; set; }
        public List<SwexRune> runes { get; set; }
    }
}