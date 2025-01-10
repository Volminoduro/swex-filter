using System.Text.Json;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Data;

public class DataContext
{
    private readonly string _filtersFilePath;
    private readonly string _runesFilePath;

    public DataContext(string FiltersFilePath, string RunesFilePath)
    {
        _filtersFilePath = FiltersFilePath;
        _runesFilePath = RunesFilePath;
        LoadData();
        AddSampleRunes();
        AddSampleFilters();
    }

    public IList<SwexRune> Runes { get; private set; } = [];
    public IList<Filter> Filters { get; private set; } = [];

    public void AddRune(SwexRune rune)
    {
        Runes.Add(rune);
        SaveData();
    }

    public void UpdateRune(SwexRune rune)
    {
        var existingRune = Runes.FirstOrDefault(r => r.Id == rune.Id);
        if (existingRune is null) return;
        existingRune.Set = rune.Set;
        existingRune.Slot = rune.Slot;
        existingRune.Stars = rune.Stars;
        existingRune.Rarity = rune.Rarity;
        existingRune.Level = rune.Level;
        existingRune.MainStat = rune.MainStat;
        existingRune.MainStatValue = rune.MainStatValue;
        existingRune.InnateStat = rune.InnateStat;
        existingRune.SubStat1 = rune.SubStat1;
        existingRune.SubStat2 = rune.SubStat2;
        existingRune.SubStat3 = rune.SubStat3;
        existingRune.SubStat4 = rune.SubStat4;
        existingRune.Monster = rune.Monster;
        SaveData();
    }

    public void DeleteRune(int id)
    {
        var rune = Runes.FirstOrDefault(r => r.Id == id);
        if (rune is null) return;
        Runes.Remove(rune);
        SaveData();
    }

    public void ImportRunes(IEnumerable<SwexRune> runes)
    {
        Runes.Clear();
        foreach (var rune in runes) Runes.Add(rune);
        SaveData();
    }

    public void AddFilter(Filter filter)
    {
        Filters.Add(filter);
        SaveData();
    }

    public void UpdateFilter(Filter filter)
    {
        var existingFilter = Filters.FirstOrDefault(f => f.Name == filter.Name);
        if (existingFilter is null) return;
        existingFilter.IsActive = filter.IsActive;
        existingFilter.RelativeScore = filter.RelativeScore;
        existingFilter.SubPropertiesPresence = filter.SubPropertiesPresence;
        existingFilter.SubPropertiesWanted = filter.SubPropertiesWanted;
        existingFilter.ExcludeEnchantedRune = filter.ExcludeEnchantedRune;
        existingFilter.ExcludeGrindFromScore = filter.ExcludeGrindFromScore;
        existingFilter.KeepOnlyIfGemAvailable = filter.KeepOnlyIfGemAvailable;
        existingFilter.KeepOnlyIfGrindAvailable = filter.KeepOnlyIfGrindAvailable;
        SaveData();
    }

    public void DeleteFilter(string name)
    {
        var filter = Filters.FirstOrDefault(f => f.Name == name);
        if (filter is null) return;
        Filters.Remove(filter);
        SaveData();
    }

    private void SaveData()
    {
        File.WriteAllText(_filtersFilePath, JsonSerializer.Serialize(Filters));
        File.WriteAllText(_runesFilePath, JsonSerializer.Serialize(Runes));
    }

    private void LoadData()
    {
        if (File.Exists(_filtersFilePath))
            Filters = JsonSerializer.Deserialize<List<Filter>>(File.ReadAllText(_filtersFilePath)) ?? [];

        if (File.Exists(_runesFilePath))
            Runes = JsonSerializer.Deserialize<List<SwexRune>>(File.ReadAllText(_runesFilePath)) ?? [];
    }

    private void AddSampleRunes()
    {
        if (Runes.Any()) return;

        Runes.Add(new SwexRune
        {
            Id = 1,
            Set = RuneSet.Violent,
            Slot = RuneSlot.Slot1,
            Stars = RuneStars.Six,
            Rarity = RuneRarity.Legendary,
            Level = 15,
            MainStat = RuneTypeStat.AtkPercentage,
            MainStatValue = 63,
            SubStat1 = new RuneSubProperty { RuneTypeStat = RuneTypeStat.HpPercentage, Value = 20, GrindAmount = 5 },
            SubStat2 = new RuneSubProperty { RuneTypeStat = RuneTypeStat.CriRate, Value = 5 },
            SubStat3 = new RuneSubProperty
                { RuneTypeStat = RuneTypeStat.DefPercentage, Value = 5, GrindAmount = 5, IsEnchanted = true }
        });

        SaveData();
    }

    private void AddSampleFilters()
    {
        if (Filters.Any()) return;

        Filters.Add(new Filter
        {
            Name = "Legendary Violent Runes",
            IsActive = true
        });

        Filters.Add(new Filter
        {
            Name = "High SPD Runes",
            IsActive = false
        });

        Filters.Add(new Filter
        {
            Name = "Swift Runes with CRI Rate",
            IsActive = true
        });

        SaveData();
    }
}