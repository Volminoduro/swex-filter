using System.Text.Json;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Data;

public class SwexImportService
{
    private static string GetJsonData(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static List<SwexRune> ImportRunes(string filePath)
    {
        var jsonContent = GetJsonData(filePath);
        var root = JsonSerializer.Deserialize<JsonRoot>(jsonContent);
        var allRunes = new List<SwexRune>();

        foreach (var monster in root.unit_list)
            allRunes.AddRange(monster.runes.Select(rune => new SwexRune
            {
                Id = rune.Id,
                Monster =
                    JsonMappingService.Instance.UnitNameMapping.GetValueOrDefault(monster.id, string.Empty),
                Set = EnumExtensions.GetEnumValueFromKey<RuneSet>(rune.SetId)
            }));

        allRunes.AddRange(root.runes.Select(rune => new SwexRune { Id = rune.Id, Monster = string.Empty }));

        return allRunes;
    }

    private class JsonRoot
    {
        public List<Monster> unit_list { get; set; }
        public List<SwexRune> runes { get; set; }
    }
}