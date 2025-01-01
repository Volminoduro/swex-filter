using MyApp.Models.Enums;

namespace RuneManager.Models
{
    public class SWEXRune
    {
        public List<Filter> Filters { get; set; } = new List<Filter>();
        public int ID { get; set; }
        public RuneSet Set { get; set; }
        public RuneSlot Slot { get; set; }
        public RuneStars Stars { get; set; }
        public RuneRarity Rarity { get; set; }
        public int Level { get; set; }
        public RuneTypeStat MainStat { get; set; }
        public int MainStatValue { get; set; }
        public RuneTypeStat? InnateStat { get; set; }
        public int? InnateStatValue { get; set; }
        public RuneTypeStat? SubStat1 { get; set; }
        public int? SubStat1Value { get; set; }
        public RuneTypeStat? SubStat2 { get; set; }
        public int? SubStat2Value { get; set; }
        public RuneTypeStat? SubStat3 { get; set; }
        public int? SubStat3Value { get; set; }
        public RuneTypeStat SubStat4 { get; set; }
        public int? SubStat4Value { get; set; }
        public int Efficiency { get; set; }
        public string Monster { get; set; }
    }
}
