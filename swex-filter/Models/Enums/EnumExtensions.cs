namespace SwexFilter.Models.Enums;

public static class EnumExtensions
{
    public static T GetEnumValueFromKey<T>(int key) where T : Enum
    {
        if (Enum.IsDefined(typeof(T), key)) return (T)(object)key;

        throw new ArgumentException("Invalid key", nameof(key));
    }
}