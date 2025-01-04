using SwexFilter.Models.Enums;

namespace SwexFilter.Models
{
    public class RuneSubProperty
    {
        public RuneTypeStat RuneTypeStat { get; set; }
        public int Value { get; set; }
        public bool IsEnchanted { get; set; }
        public int GrindAmount { get; set; }
    }
}