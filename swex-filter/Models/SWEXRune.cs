using System.Text.Json.Serialization;
using SwexFilter.Models.Enums;

namespace SwexFilter.Models;

public class SwexRune : IEquatable<SwexRune>
{
    public List<Filter> FiltersPassed { get; set; } = [];

    [JsonPropertyName("rune_id")] public long Id { get; set; }

    [JsonPropertyName("set_id")] public int SetKey { get; set; }
    public RuneSet Set { get; set; }

    [JsonPropertyName("slot_no")] public int SlotKey { get; set; }
    public RuneSlot Slot { get; set; }
    [JsonPropertyName("class")] public int StarsKey { get; set; }
    public RuneStars Stars { get; set; }
    [JsonPropertyName("rank")] public int RarityKey { get; set; }
    public RuneRarity Rarity { get; set; }
    [JsonPropertyName("upgrade_curr")] public int Level { get; set; }

    [JsonPropertyName("pri_eff")] public List<int> MainStatJson { get; set; }
    public RuneTypeStat MainStat { get; set; }
    public int MainStatValue { get; set; }

    [JsonPropertyName("prefix_eff")] public List<int> InnateStatJson { get; set; }
    public RuneSubProperty? InnateStat { get; set; }
    [JsonPropertyName("sec_eff")] public List<List<int>> SubStatsJson { get; set; }
    public RuneSubProperty? SubStat1 { get; set; }
    public RuneSubProperty? SubStat2 { get; set; }
    public RuneSubProperty? SubStat3 { get; set; }
    public RuneSubProperty? SubStat4 { get; set; }

    private List<RuneSubProperty?> RuneSubProperties => [InnateStat, SubStat1, SubStat2, SubStat3, SubStat4];

    public int Score
    {
        get
        {
            var totalScore = RuneSubProperties.Where(property =>
                property != null && property.RuneTypeStat.HasValue && property.Value.HasValue).Sum(
                property =>
                    MaxStatValues.GetScoreRollValue(property.RuneTypeStat.Value, property.Value.Value));

            return (int)Math.Round(totalScore);
        }
    }

    public string? Monster { get; set; }

    public bool Equals(SwexRune? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Set == other.Set && Slot == other.Slot && Stars == other.Stars &&
               Rarity == other.Rarity && Level == other.Level && MainStat == other.MainStat &&
               MainStatValue == other.MainStatValue && Equals(InnateStat, other.InnateStat) &&
               Equals(SubStat1, other.SubStat1) && Equals(SubStat2, other.SubStat2) &&
               Equals(SubStat3, other.SubStat3) && Equals(SubStat4, other.SubStat4) && Monster == other.Monster;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SwexRune)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add((int)Set);
        hashCode.Add((int)Slot);
        hashCode.Add((int)Stars);
        hashCode.Add((int)Rarity);
        hashCode.Add(Level);
        hashCode.Add((int)MainStat);
        hashCode.Add(MainStatValue);
        hashCode.Add(InnateStat);
        hashCode.Add(SubStat1);
        hashCode.Add(SubStat2);
        hashCode.Add(SubStat3);
        hashCode.Add(SubStat4);
        hashCode.Add(Monster);
        return hashCode.ToHashCode();
    }
}