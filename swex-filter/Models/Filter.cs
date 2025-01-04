using SwexFilter.Models.Enums;

namespace SwexFilter.Models
{
    public class Filter
    {
        public bool IsActive { get; set; }

        public string? Name { get; set; }
        public int? RelativeScore { get; set; }

        public int? SubPropertiesPresence { get; set; }

        public List<RuneTypeStat> SubPropertiesWanted { get; set; } = [];

        // Useful for first time gemming the rune
        public bool ExcludeEnchantedRune { get; set; } = true;

        // Useful for first time grinding the rune
        public bool ExcludeGrindFromScore { get; set; } = true;

        public bool KeepOnlyIfGemAvailable { get; set; } = true;

        public bool KeepOnlyIfGrindAvailable { get; set; } = true;

        // QoL : Rune set filter, rune slot, Main stat

    }
}
