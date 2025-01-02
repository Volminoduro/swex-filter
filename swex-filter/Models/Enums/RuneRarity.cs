using System.Reflection;

namespace SwexFilter.Models.Enums
{
    public enum RuneRarity
    {
        [RuneRarityInfo("Common", "1")]
        Common,
        [RuneRarityInfo("Magic", "2")]
        Magic,
        [RuneRarityInfo("Rare", "3")]
        Rare,
        [RuneRarityInfo("Hero", "4")]
        Hero,
        [RuneRarityInfo("Legendary", "5")]
        Legendary,
        [RuneRarityInfo("Ancient Common", "11")]
        AncientCommon,
        [RuneRarityInfo("Ancient Magic", "12")]
        AncientMagic,
        [RuneRarityInfo("Ancient Rare", "13")]
        AncientRare,
        [RuneRarityInfo("Ancient Hero", "14")]
        AncientHero,
        [RuneRarityInfo("Ancient Legendary", "15")]
        AncientLegendary
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RuneRarityInfoAttribute : Attribute
    {
        public string DisplayName { get; }
        public string JsonMapping { get; }

        public RuneRarityInfoAttribute(string displayName, string jsonMapping)
        {
            DisplayName = displayName;
            JsonMapping = jsonMapping;
        }

        public static RuneRarityInfoAttribute GetInfo(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            RuneRarityInfoAttribute[] attributes = (RuneRarityInfoAttribute[])fi.GetCustomAttributes(typeof(RuneRarityInfoAttribute), false);

            return attributes != null && attributes.Length > 0 ? attributes[0] : null;
        }
    }

}
