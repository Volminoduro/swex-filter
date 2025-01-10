namespace SwexFilter.Models.Enums;

public enum RuneRarity
{
    [RuneRarityInfo("Common")] Common = 1,
    [RuneRarityInfo("Magic")] Magic = 2,
    [RuneRarityInfo("Rare")] Rare = 3,
    [RuneRarityInfo("Hero")] Hero = 4,
    [RuneRarityInfo("Legendary")] Legendary = 5,

    [RuneRarityInfo("Ancient Common")] AncientCommon = 11,
    [RuneRarityInfo("Ancient Magic")] AncientMagic = 12,
    [RuneRarityInfo("Ancient Rare")] AncientRare = 13,
    [RuneRarityInfo("Ancient Hero")] AncientHero = 14,
    [RuneRarityInfo("Ancient Legendary")] AncientLegendary = 15
}

[AttributeUsage(AttributeTargets.Field)]
public class RuneRarityInfoAttribute(string displayName) : Attribute
{
    public string DisplayName { get; } = displayName;

    public static RuneRarityInfoAttribute? GetInfo(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes =
            (RuneRarityInfoAttribute?[])fi.GetCustomAttributes(typeof(RuneRarityInfoAttribute), false);

        return attributes.Length > 0 ? attributes[0] : null;
    }
}