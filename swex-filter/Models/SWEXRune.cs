using SwexFilter.Models.Enums;

namespace SwexFilter.Models
{
    public class SWEXRune
    {
        public List<Filter> FiltersPassed { get; set; } = [];
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

        public Dictionary<string, RuneSubProperty> RuneSubProperties
        {
            get
            {
                Dictionary<string, RuneSubProperty> runeSubProperties = [];
                if (InnateStat.HasValue && InnateStatValue.HasValue)
                {
                    runeSubProperties.Add("Innate", new RuneSubProperty
                    {
                        RuneTypeStat = InnateStat.Value,
                        Value = InnateStatValue.Value
                    });
                }
                if (SubStat1.HasValue && SubStat1Value.HasValue)
                {
                    runeSubProperties.Add("SubStat1", new RuneSubProperty
                    {
                        RuneTypeStat = SubStat1.Value,
                        Value = SubStat1Value.Value
                    });
                }
                if (SubStat2.HasValue && SubStat2Value.HasValue)
                {
                    runeSubProperties.Add("SubStat2", new RuneSubProperty
                    {
                        RuneTypeStat = SubStat2.Value,
                        Value = SubStat2Value.Value
                    });
                }
                if (SubStat3.HasValue && SubStat3Value.HasValue)
                {
                    runeSubProperties.Add("SubStat3", new RuneSubProperty
                    {
                        RuneTypeStat = SubStat3.Value,
                        Value = SubStat3Value.Value
                    });
                }
                if (SubStat4.HasValue && SubStat4Value.HasValue)
                {
                    runeSubProperties.Add("SubStat4", new RuneSubProperty
                    {
                        RuneTypeStat = SubStat4.Value,
                        Value = SubStat4Value.Value
                    });
                }

                return runeSubProperties;
            }
        }

        public int Score
        {
            get
            {
                double totalScore = 0;
                foreach (var runeSubProperty in RuneSubProperties)
                {
                    totalScore += MaxStatValues.GetScoreRollValue(runeSubProperty.Value.RuneTypeStat, runeSubProperty.Value.Value);
                }

                return (int)Math.Round(totalScore);
            }
        }

        public string? Monster { get; set; }

    }
}
