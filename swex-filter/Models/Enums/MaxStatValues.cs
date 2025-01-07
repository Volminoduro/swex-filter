namespace SwexFilter.Models.Enums;

public static class MaxStatValues
{
    private static readonly Dictionary<RuneTypeStat, int> SubStatMaxRoll = new()
    {
        { RuneTypeStat.HpPercentage, 8 },
        { RuneTypeStat.HpFlat, 375 },
        { RuneTypeStat.AtkPercentage, 8 },
        { RuneTypeStat.AtkFlat, 20 },
        { RuneTypeStat.DefPercentage, 8 },
        { RuneTypeStat.DefFlat, 20 },
        { RuneTypeStat.Spd, 6 },
        { RuneTypeStat.CriRate, 6 },
        { RuneTypeStat.CriDmg, 7 },
        { RuneTypeStat.Resistance, 8 },
        { RuneTypeStat.Accuracy, 8 }
    };

    private static int GetSubStatMaxRoll(RuneTypeStat stat)
    {
        return SubStatMaxRoll.GetValueOrDefault(stat, 0);
    }

    public static double GetScoreRollValue(RuneTypeStat stat, int value)
    {
        var totalrolls = (double)value / GetSubStatMaxRoll(stat);
        if (new List<RuneTypeStat> { RuneTypeStat.AtkFlat, RuneTypeStat.HpFlat, RuneTypeStat.DefFlat }.Contains(stat))
            totalrolls = totalrolls * 0.35;
        // https://www.reddit.com/r/summonerswar/comments/1gfsixy/this_is_how_runeartifact_score_works_compared_to/
        // One min flat stat roll = 2.52 score
        // One min not-flat stat roll = 10 score
        // One Max roll = 20 score
        return totalrolls * 20;
    }
}