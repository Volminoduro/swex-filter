using System.Text.Json;

namespace SwexFilter.Data;

public sealed class JsonMappingService
{
    private const string PathToMappingJsonFile = "Resources/mapping.json";
    private static readonly Lazy<JsonMappingService> Lazy = new(() => new JsonMappingService());

    private JsonMappingService()
    {
        RootElement = JsonDocument.Parse(File.ReadAllText(PathToMappingJsonFile)).RootElement;
        InitUnitNameMapping();
    }

    private JsonElement RootElement { get; }
    public static JsonMappingService Instance => Lazy.Value;
    public Dictionary<long, string> UnitNameMapping { get; private set; }

    private void InitUnitNameMapping()
    {
        var unitNames = new Dictionary<long, string>();
        foreach (var kvp in RootElement.GetProperty("monster").GetProperty("names").EnumerateObject())
            if (long.TryParse(kvp.Name, out var id))
                unitNames[id] = kvp.Value.GetString() ?? throw new InvalidOperationException();

        UnitNameMapping = unitNames;
    }
}