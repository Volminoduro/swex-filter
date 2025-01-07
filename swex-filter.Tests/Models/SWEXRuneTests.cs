using FluentAssertions;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Tests.Models;

public class SwexRuneTests
{
    [Theory]
    [InlineData(null, null, null, null, null, null, null, null, null, null, 0)]
    [InlineData(RuneTypeStat.CriRate, 6, RuneTypeStat.HpPercentage, 8, RuneTypeStat.Accuracy, 19, RuneTypeStat.CriDmg,
        18, RuneTypeStat.Spd, 6, 159)]
    [InlineData(null, null, RuneTypeStat.Accuracy, 7, RuneTypeStat.HpPercentage, 14, RuneTypeStat.CriDmg, 17,
        RuneTypeStat.HpFlat, 145, 104)]
    [InlineData(null, null, RuneTypeStat.Spd, 5, RuneTypeStat.DefPercentage, 23, RuneTypeStat.CriRate, 4,
        RuneTypeStat.HpPercentage, 8, 108)]
    [InlineData(RuneTypeStat.DefFlat, 18, RuneTypeStat.Accuracy, 7, RuneTypeStat.Spd, 15, RuneTypeStat.CriDmg, 11,
        RuneTypeStat.AtkPercentage, 7, 123)]
    [InlineData(RuneTypeStat.Accuracy, 11, RuneTypeStat.AtkFlat, 10, RuneTypeStat.DefPercentage, 22,
        RuneTypeStat.Resistance, 11, RuneTypeStat.CriRate, 4, 127)]
    public void Score(RuneTypeStat? InnateStat, int? InnateStatValue,
        RuneTypeStat? SubStat1, int? SubStatValue1,
        RuneTypeStat? SubStat2, int? SubStatValue2,
        RuneTypeStat? SubStat3, int? SubStatValue3,
        RuneTypeStat? SubStat4, int? SubStatValue4,
        int excepted)
    {
        SwexRune testRune = new()
        {
            InnateStat = InnateStat,
            InnateStatValue = InnateStatValue,

            SubStat1 = SubStat1,
            SubStat1Value = SubStatValue1,

            SubStat2 = SubStat2,
            SubStat2Value = SubStatValue2,

            SubStat3 = SubStat3,
            SubStat3Value = SubStatValue3,

            SubStat4 = SubStat4,
            SubStat4Value = SubStatValue4
        };

        testRune.Score.Should().Be(excepted);
    }
}