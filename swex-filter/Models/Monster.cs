using System.Text.Json.Serialization;

namespace SwexFilter.Models;

public record Monster
{
    [JsonPropertyName("unit_master_id")] public long id { get; set; }

    public List<SwexRune> runes { get; set; }
}