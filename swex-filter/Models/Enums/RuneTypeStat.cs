using System.Reflection;

namespace SwexFilter.Models.Enums
{
    public enum RuneTypeStat
    {
        [RuneTypeStatInfo("HP Flat", "1")]
        HPFlat,
        [RuneTypeStatInfo("HP %", "2")]
        HPPercentage,
        [RuneTypeStatInfo("ATK Flat", "3")]
        ATKFlat,
        [RuneTypeStatInfo("ATK %", "4")]
        ATKPercentage,
        [RuneTypeStatInfo("DEF Flat", "5")]
        DEFFlat,
        [RuneTypeStatInfo("DEF %", "6")]
        DEFPercentage,
        [RuneTypeStatInfo("SPD", "8")]
        SPD,
        [RuneTypeStatInfo("CRI Rate", "9")]
        CRIRate,
        [RuneTypeStatInfo("CRI DMG", "10")]
        CRIDMG,
        [RuneTypeStatInfo("Resistance", "11")]
        Resistance,
        [RuneTypeStatInfo("Accuracy", "12")]
        Accuracy
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RuneTypeStatInfoAttribute : Attribute
    {
        public string DisplayName { get; }
        public string JsonMapping { get; }

        public RuneTypeStatInfoAttribute(string displayName, string jsonMapping)
        {
            DisplayName = displayName;
            JsonMapping = jsonMapping;
        }

        public static RuneTypeStatInfoAttribute GetInfo(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            RuneTypeStatInfoAttribute[] attributes = (RuneTypeStatInfoAttribute[])fi.GetCustomAttributes(typeof(RuneTypeStatInfoAttribute), false);

            return attributes != null && attributes.Length > 0 ? attributes[0] : null;
        }
    }
}
