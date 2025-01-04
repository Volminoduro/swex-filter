namespace SwexFilter.Models.Enums
{
    public static class MaxStatValues
    {

        private static readonly Dictionary<RuneTypeStat, int> SubStatMaxRoll = new Dictionary<RuneTypeStat, int>
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

        private static int GetSubStatMaxRoll(RuneTypeStat stat)
        {
            return SubStatMaxRoll.TryGetValue(stat, out var value) ? value : 0;
        }

        public static double GetScoreRollValue(RuneTypeStat stat, int value)
        {
            double totalrolls = (double)value / GetSubStatMaxRoll(stat);
            if (new List<RuneTypeStat> { RuneTypeStat.ATKFlat, RuneTypeStat.HPFlat, RuneTypeStat.DEFFlat }.Contains(stat))
                totalrolls = totalrolls * 0.35;
            // https://www.reddit.com/r/summonerswar/comments/1gfsixy/this_is_how_runeartifact_score_works_compared_to/
            // One min flat stat roll = 2.52 score
            // One min not-flat stat roll = 10 score
            // One Max roll = 20 score
            return totalrolls * 20;
        }
    }
}
