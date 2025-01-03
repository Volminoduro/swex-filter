namespace SwexFilter.Models.Enums
{
    public static class MaxStatValues
    {
        private static readonly Dictionary<RuneTypeStat, int> maxSubStatValues = new Dictionary<RuneTypeStat, int>
        {
            { (RuneTypeStat.HPPercentage), 40 },
            { (RuneTypeStat.HPFlat), 1875 },
            { (RuneTypeStat.ATKPercentage), 40 },
            { (RuneTypeStat.ATKFlat), 100 },
            { (RuneTypeStat.DEFPercentage), 40 },
            { (RuneTypeStat.DEFFlat), 100 },
            { (RuneTypeStat.SPD), 30 },
            { (RuneTypeStat.CRIRate), 30 },
            { (RuneTypeStat.CRIDMG), 35 },
            { (RuneTypeStat.Resistance), 40 },
            { (RuneTypeStat.Accuracy), 40 },
        };

        public static int GetMaxSubStatValue(RuneTypeStat stat)
        {
            return maxSubStatValues.TryGetValue(stat, out var value) ? value : 0;
        }

        private static readonly Dictionary<RuneTypeStat, int> maxSubStatRollValues = new Dictionary<RuneTypeStat, int>
        {
            { (RuneTypeStat.HPPercentage), 8 },
            { (RuneTypeStat.HPFlat), 375 },
            { (RuneTypeStat.ATKPercentage), 8 },
            { (RuneTypeStat.ATKFlat), 20 },
            { (RuneTypeStat.DEFPercentage), 8 },
            { (RuneTypeStat.DEFFlat), 20 },
            { (RuneTypeStat.SPD), 6 },
            { (RuneTypeStat.CRIRate), 6 },
            { (RuneTypeStat.CRIDMG), 7 },
            { (RuneTypeStat.Resistance), 8 },
            { (RuneTypeStat.Accuracy), 8 },
        };

        public static int GetMaxSubStatRollValue(RuneTypeStat stat)
        {
            return maxSubStatRollValues.TryGetValue(stat, out var value) ? value : 0;
        }

        public static int GetScoreRollValue(RuneTypeStat stat, int value)
        {
            double totalrolls = Math.Round((double)value / GetMaxSubStatRollValue(stat), 2);
            if (new List<RuneTypeStat> { RuneTypeStat.ATKFlat, RuneTypeStat.HPFlat, RuneTypeStat.DEFFlat }.Contains(stat))
                totalrolls = totalrolls * 0.35;
            // https://www.reddit.com/r/summonerswar/comments/1gfsixy/this_is_how_runeartifact_score_works_compared_to/
            // One min flat stat roll = 2.52 score
            // One min not-flat stat roll = 10 score
            // One Max roll = 20 score
            return (int)Math.Round(totalrolls * 20);
        }
    }
}
