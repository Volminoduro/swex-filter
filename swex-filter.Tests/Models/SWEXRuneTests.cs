using FluentAssertions;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Tests.Models
{
    public class SWEXRuneTests
    {

        [Theory]
        [InlineData(null, null, null, null, null, null, null, null, null, null, 0)]
        [InlineData(RuneTypeStat.CRIRate, 6, RuneTypeStat.HPPercentage, 8, RuneTypeStat.Accuracy, 19, RuneTypeStat.CRIDMG, 18, RuneTypeStat.SPD, 6, 159)]
        [InlineData(null, null, RuneTypeStat.Accuracy, 7, RuneTypeStat.HPPercentage, 14, RuneTypeStat.CRIDMG, 17, RuneTypeStat.HPFlat, 145, 104)]
        [InlineData(null, null, RuneTypeStat.SPD, 5, RuneTypeStat.DEFPercentage, 23, RuneTypeStat.CRIRate, 4, RuneTypeStat.HPPercentage, 8, 108)]
        [InlineData(RuneTypeStat.DEFFlat, 18, RuneTypeStat.Accuracy, 7, RuneTypeStat.SPD, 15, RuneTypeStat.CRIDMG, 11, RuneTypeStat.ATKPercentage, 7, 123)]
        [InlineData(RuneTypeStat.Accuracy, 11, RuneTypeStat.ATKFlat, 10, RuneTypeStat.DEFPercentage, 22, RuneTypeStat.Resistance, 11, RuneTypeStat.CRIRate, 4, 127)]
        public void Score(RuneTypeStat? InnateStat, int? InnateStatValue,
            RuneTypeStat? SubStat1, int? SubStatValue1,
            RuneTypeStat? SubStat2, int? SubStatValue2,
            RuneTypeStat? SubStat3, int? SubStatValue3,
            RuneTypeStat? SubStat4, int? SubStatValue4,
            int excepted)
        {
            SWEXRune testRune = new()
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
}
