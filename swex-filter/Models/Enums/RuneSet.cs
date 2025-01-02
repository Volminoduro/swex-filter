using System.Reflection;

namespace SwexFilter.Models.Enums
{
    public enum RuneSet
    {
        [RuneSetInfo("Energy", "1")]
        Energy,
        [RuneSetInfo("Guard", "2")]
        Guard,
        [RuneSetInfo("Swift", "3")]
        Swift,
        [RuneSetInfo("Blade", "4")]
        Blade,
        [RuneSetInfo("Rage", "5")]
        Rage,
        [RuneSetInfo("Fatal", "8")]
        Fatal,
        [RuneSetInfo("Despair", "10")]
        Despair,
        [RuneSetInfo("Vampire", "11")]
        Vampire,
        [RuneSetInfo("Violent", "13")]
        Violent,
        [RuneSetInfo("Focus", "6")]
        Focus,
        [RuneSetInfo("Endure", "7")]
        Endure,
        [RuneSetInfo("Will", "15")]
        Will,
        [RuneSetInfo("Nemesis", "14")]
        Nemesis,
        [RuneSetInfo("Shield", "16")]
        Shield,
        [RuneSetInfo("Revenge", "17")]
        Revenge,
        [RuneSetInfo("Destroy", "18")]
        Destroy,
        [RuneSetInfo("Fight", "19")]
        Fight,
        [RuneSetInfo("Determination", "20")]
        Determination,
        [RuneSetInfo("Enhance", "21")]
        Enhance,
        [RuneSetInfo("Accuracy", "22")]
        Accuracy,
        [RuneSetInfo("Tolerance", "23")]
        Tolerance,
        [RuneSetInfo("Seal", "24")]
        Seal,
        [RuneSetInfo("Intangible", "25")]
        Intangible
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RuneSetInfoAttribute : Attribute
    {
        public string DisplayName { get; }
        public string JsonMapping { get; }

        public RuneSetInfoAttribute(string displayName, string jsonMapping)
        {
            DisplayName = displayName;
            JsonMapping = jsonMapping;
        }

        public static RuneSetInfoAttribute GetInfo(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            RuneSetInfoAttribute[] attributes = (RuneSetInfoAttribute[])fi.GetCustomAttributes(typeof(RuneSetInfoAttribute), false);

            return attributes != null && attributes.Length > 0 ? attributes[0] : null;
        }
    }
}
