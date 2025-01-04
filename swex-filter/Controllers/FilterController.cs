using SwexFilter.Data;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Controllers
{
    public class FilterController(DataContext dataContext)
    {
        private readonly DataContext _dataContext = dataContext;

        public IList<Filter> GetFilters()
        {
            return _dataContext.Filters;
        }

        public void AddFilter(Filter filter)
        {
            _dataContext.AddFilter(filter);
        }

        public void UpdateFilter(Filter filter)
        {
            _dataContext.UpdateFilter(filter);
        }

        public void DeleteFilter(string name)
        {
            _dataContext.DeleteFilter(name);
        }

        public SWEXRune ApplyFiltersToRune(SWEXRune rune)
        {
            rune.FiltersPassed = _dataContext.Filters.Where(filter => CheckRune(filter, rune)).ToList();
            return rune;
        }

        private static bool CheckRune(Filter filter, SWEXRune rune)
        {
            return CheckRelativeScore(filter, rune);
        }

        private static bool CheckRelativeScore(Filter filter, SWEXRune rune)
        {
            if (filter.RelativeScore == null)
            {
                return true;
            }
            double runeRelativeScore = 0;
            if (rune.InnateStat.HasValue && rune.InnateStatValue.HasValue && filter.SubPropertiesWanted.Contains(rune.InnateStat.Value))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.InnateStat.Value, rune.InnateStatValue.Value);
            if (rune.SubStat1.HasValue && rune.SubStat1Value.HasValue && filter.SubPropertiesWanted.Contains(rune.SubStat1.Value))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat1.Value, rune.SubStat1Value.Value);
            if (rune.SubStat2.HasValue && rune.SubStat2Value.HasValue && filter.SubPropertiesWanted.Contains(rune.SubStat2.Value))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat2.Value, rune.SubStat2Value.Value);
            if (rune.SubStat3.HasValue && rune.SubStat3Value.HasValue && filter.SubPropertiesWanted.Contains(rune.SubStat3.Value))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat3.Value, rune.SubStat3Value.Value);
            if (rune.SubStat4.HasValue && rune.SubStat4Value.HasValue && filter.SubPropertiesWanted.Contains(rune.SubStat4.Value))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat4.Value, rune.SubStat4Value.Value);

            return runeRelativeScore >= filter.RelativeScore;
        }

    }
}
