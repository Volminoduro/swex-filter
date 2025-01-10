namespace SwexFilter.Models.Enums;

public enum RuneTypeStat
{
    [RuneTypeStatInfo("HP Flat")] HpFlat = 1,
    [RuneTypeStatInfo("HP %")] HpPercentage = 2,
    [RuneTypeStatInfo("ATK Flat")] AtkFlat = 3,
    [RuneTypeStatInfo("ATK %")] AtkPercentage = 4,
    [RuneTypeStatInfo("DEF Flat")] DefFlat = 5,
    [RuneTypeStatInfo("DEF %")] DefPercentage = 6,
    [RuneTypeStatInfo("SPD")] Spd = 8,
    [RuneTypeStatInfo("CRI Rate")] CriRate = 9,
    [RuneTypeStatInfo("CRI DMG")] CriDmg = 10,
    [RuneTypeStatInfo("Resistance")] Resistance = 11,
    [RuneTypeStatInfo("Accuracy")] Accuracy = 12
}

[AttributeUsage(AttributeTargets.Field)]
public class RuneTypeStatInfoAttribute(string displayName) : Attribute
{
    public string DisplayName { get; } = displayName;

    public static RuneTypeStatInfoAttribute? GetInfo(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes =
            (RuneTypeStatInfoAttribute?[])fi.GetCustomAttributes(typeof(RuneTypeStatInfoAttribute), false);

        return attributes.Length > 0 ? attributes[0] : null;
    }
}