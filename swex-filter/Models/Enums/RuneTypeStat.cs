namespace SwexFilter.Models.Enums;

public enum RuneTypeStat
{
    // TODO Description et on met le jsonMapping avec = 1
    [RuneTypeStatInfo("HP Flat", "1")] HpFlat,
    [RuneTypeStatInfo("HP %", "2")] HpPercentage,
    [RuneTypeStatInfo("ATK Flat", "3")] AtkFlat,
    [RuneTypeStatInfo("ATK %", "4")] AtkPercentage,
    [RuneTypeStatInfo("DEF Flat", "5")] DefFlat,
    [RuneTypeStatInfo("DEF %", "6")] DefPercentage,
    [RuneTypeStatInfo("SPD", "8")] Spd,
    [RuneTypeStatInfo("CRI Rate", "9")] CriRate,
    [RuneTypeStatInfo("CRI DMG", "10")] CriDmg,
    [RuneTypeStatInfo("Resistance", "11")] Resistance,
    [RuneTypeStatInfo("Accuracy", "12")] Accuracy
}

[AttributeUsage(AttributeTargets.Field)]
public class RuneTypeStatInfoAttribute(string displayName, string jsonMapping) : Attribute
{
    public string DisplayName { get; } = displayName;
    public string JsonMapping { get; } = jsonMapping;

    public static RuneTypeStatInfoAttribute? GetInfo(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes =
            (RuneTypeStatInfoAttribute?[])fi.GetCustomAttributes(typeof(RuneTypeStatInfoAttribute), false);

        return attributes.Length > 0 ? attributes[0] : null;
    }
}