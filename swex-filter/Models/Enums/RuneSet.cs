namespace SwexFilter.Models.Enums;

public enum RuneSet
{
    [RuneSetInfo("Energy")] Energy = 1,
    [RuneSetInfo("Guard")] Guard = 2,
    [RuneSetInfo("Swift")] Swift = 3,
    [RuneSetInfo("Blade")] Blade = 4,
    [RuneSetInfo("Rage")] Rage = 5,
    [RuneSetInfo("Fatal")] Fatal = 8,
    [RuneSetInfo("Despair")] Despair = 10,
    [RuneSetInfo("Vampire")] Vampire = 11,
    [RuneSetInfo("Violent")] Violent = 13,
    [RuneSetInfo("Focus")] Focus = 6,
    [RuneSetInfo("Endure")] Endure = 7,
    [RuneSetInfo("Will")] Will = 15,
    [RuneSetInfo("Nemesis")] Nemesis = 14,
    [RuneSetInfo("Shield")] Shield = 16,
    [RuneSetInfo("Revenge")] Revenge = 17,
    [RuneSetInfo("Destroy")] Destroy = 18,
    [RuneSetInfo("Fight")] Fight = 19,
    [RuneSetInfo("Determination")] Determination = 20,
    [RuneSetInfo("Enhance")] Enhance = 21,
    [RuneSetInfo("Accuracy")] Accuracy = 22,
    [RuneSetInfo("Tolerance")] Tolerance = 23,
    [RuneSetInfo("Seal")] Seal = 24,
    [RuneSetInfo("Intangible")] Intangible = 25
}

[AttributeUsage(AttributeTargets.Field)]
public class RuneSetInfoAttribute(string displayName) : Attribute
{
    public string DisplayName { get; } = displayName;

    public static RuneSetInfoAttribute? GetInfo(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes =
            (RuneSetInfoAttribute?[])fi.GetCustomAttributes(typeof(RuneSetInfoAttribute), false);

        return attributes.Length > 0 ? attributes[0] : null;
    }
}