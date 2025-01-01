using MyApp.Models.Enums;

namespace RuneManager.Models
{
    public class Filter
    {
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public RuneSet? Set { get; set; }
        public RuneSlot? Slot { get; set; }
        public RuneRarity? Rarity { get; set; }

        public RuneStars? Stars { get; set; }
        public int? MinLevel { get; set; }
        public int? MaxLevel { get; set; }
        public RuneTypeStat? MainStat { get; set; }
        public int? MinMainStatValue { get; set; }
        public int? MaxMainStatValue { get; set; }
        public RuneTypeStat? InnateStat { get; set; }
        public int? MinInnateStatValue { get; set; }
        public int? MaxInnateStatValue { get; set; }
        public RuneTypeStat? SubStat1 { get; set; }
        public int? MinSubStat1Value { get; set; }
        public int? MaxSubStat1Value { get; set; }
        public RuneTypeStat? SubStat2 { get; set; }
        public int? MinSubStat2Value { get; set; }
        public int? MaxSubStat2Value { get; set; }
        public RuneTypeStat? SubStat3 { get; set; }
        public int? MinSubStat3Value { get; set; }
        public int? MaxSubStat3Value { get; set; }
        public RuneTypeStat? SubStat4 { get; set; }
        public int? MinSubStat4Value { get; set; }
        public int? MaxSubStat4Value { get; set; }

    }
}
