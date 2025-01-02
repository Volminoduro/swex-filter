using SwexFilter.Models.Enums;

namespace SwexFilter.Models
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
        public RuneTypeStat? SubStat4 { get; set; }
        public int? SubStat4Value { get; set; }
        public int Score { get { return CalculateScore(); } }

        public string Monster { get; set; }

        private int CalculateScore()
        {

            double totalrolls = 0;
            if (SubStat1 != null && SubStat1Value != null)
                totalrolls += Math.Round((double)SubStat1Value / MaxStatValues.GetMaxSubStatRollValue((RuneTypeStat)SubStat1), 2);
            if (SubStat2 != null && SubStat2Value != null)
                totalrolls += Math.Round((double)SubStat2Value / MaxStatValues.GetMaxSubStatRollValue((RuneTypeStat)SubStat2), 2);
            if (SubStat3 != null && SubStat3Value != null)
                totalrolls += Math.Round((double)SubStat3Value / MaxStatValues.GetMaxSubStatRollValue((RuneTypeStat)SubStat3), 2);
            if (SubStat4 != null && SubStat4Value != null)
                totalrolls += Math.Round((double)SubStat4Value / MaxStatValues.GetMaxSubStatRollValue((RuneTypeStat)SubStat4), 2);
            if (InnateStat != null && InnateStatValue != null)
                totalrolls += Math.Round((double)InnateStatValue / MaxStatValues.GetMaxSubStatRollValue((RuneTypeStat)InnateStat), 2);

            // One Max roll = 20 score
            return (int)Math.Floor(totalrolls * 20);
        }
    }
}
