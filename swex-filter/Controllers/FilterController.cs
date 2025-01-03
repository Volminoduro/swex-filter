using SwexFilter.Data;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Controllers
{
    public class FilterController
    {
        private readonly IDataContext _dataContext;

        public FilterController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

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

        public IList<SWEXRune> ApplyFilters(IList<SWEXRune> runes)
        {
            var activeFilters = _dataContext.Filters.Where(f => f.IsActive).ToList();
            if (!activeFilters.Any())
            {
                return runes;
            }

            var filteredRunes = runes.Where(rune => activeFilters.All(filter =>
                CheckSet(filter.Set, rune) &&
                CheckSlot(filter.Slot, rune) &&
                CheckRelativeScore(filter.RelativeScore, new List<RuneTypeStat?> { filter.InnateStat, filter.SubStat1, filter.SubStat2, filter.SubStat3, filter.SubStat4 }, rune) &&
                CheckStars(filter.Stars, rune) &&
                CheckRarity(filter.Rarity, rune) &&
                CheckMainStat(filter.MainStat, filter.MinMainStatValue, filter.MaxMainStatValue, rune) &&
                CheckSubStat(filter.SubStat1, filter.MinSubStat1Value, filter.MaxSubStat1Value, rune) &&
                CheckSubStat(filter.SubStat2, filter.MinSubStat2Value, filter.MaxSubStat2Value, rune) &&
                CheckSubStat(filter.SubStat3, filter.MinSubStat3Value, filter.MaxSubStat3Value, rune) &&
                CheckSubStat(filter.SubStat4, filter.MinSubStat4Value, filter.MaxSubStat4Value, rune) &&
                CheckInnateStat(filter.InnateStat, filter.MinInnateStatValue, filter.MaxInnateStatValue, rune)
            )).ToList();

            return filteredRunes;
        }

        private bool CheckRelativeScore(int? relativeScore, List<RuneTypeStat?> filterTypeStats, SWEXRune rune)
        {
            if (relativeScore == null)
            {
                return true;
            }
            int runeRelativeScore = 0;
            if (rune.InnateStat.HasValue && rune.InnateStatValue.HasValue && filterTypeStats.Contains(rune.InnateStat))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.InnateStat.Value, rune.InnateStatValue.Value);
            if (rune.SubStat1.HasValue && rune.SubStat1Value.HasValue && filterTypeStats.Contains(rune.SubStat1))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat1.Value, rune.SubStat1Value.Value);
            if (rune.SubStat2.HasValue && rune.SubStat2Value.HasValue && filterTypeStats.Contains(rune.SubStat2))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat2.Value, rune.SubStat2Value.Value);
            if (rune.SubStat3.HasValue && rune.SubStat3Value.HasValue && filterTypeStats.Contains(rune.SubStat3))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat3.Value, rune.SubStat3Value.Value);
            if (rune.SubStat4.HasValue && rune.SubStat4Value.HasValue && filterTypeStats.Contains(rune.SubStat4))
                runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat4.Value, rune.SubStat4Value.Value);

            return runeRelativeScore >= relativeScore;
        }

        private bool CheckStars(RuneStars? stars, SWEXRune rune)
        {
            return stars == null || stars.ToString() == "" || rune.Stars.ToString() == stars.ToString();
        }

        private bool CheckSet(RuneSet? set, SWEXRune rune)
        {
            return set == null || set.ToString() == "" || rune.Set.ToString() == set.ToString();
        }

        private bool CheckSlot(RuneSlot? slot, SWEXRune rune)
        {
            return slot == null || slot.ToString() == "" || rune.Slot.ToString() == slot.ToString();
        }

        private bool CheckRarity(RuneRarity? rarity, SWEXRune rune)
        {
            return rarity == null || rarity.ToString() == "" || rune.Rarity.ToString() == rarity.ToString();
        }

        private bool CheckMainStat(RuneTypeStat? mainStat, int? minMainStatValue, int? maxMainStatValue, SWEXRune rune)
        {
            if (mainStat == null)
            {
                return true;
            }

            return rune.MainStat == mainStat &&
                   (!minMainStatValue.HasValue || rune.MainStatValue >= minMainStatValue) &&
                   (!maxMainStatValue.HasValue || rune.MainStatValue <= maxMainStatValue);
        }

        private bool CheckSubStat(RuneTypeStat? subStat, int? minSubStatValue, int? maxSubStatValue, SWEXRune rune)
        {
            if (subStat == null)
            {
                return true;
            }

            bool subStatMatches = rune.SubStat1 == subStat || rune.SubStat2 == subStat || rune.SubStat3 == subStat || rune.SubStat4 == subStat;
            if (!subStatMatches)
            {
                return false;
            }

            bool valueMatches =
                (rune.SubStat1 == subStat && (!minSubStatValue.HasValue || rune.SubStat1Value >= minSubStatValue) && (!maxSubStatValue.HasValue || rune.SubStat1Value <= maxSubStatValue)) ||
                (rune.SubStat2 == subStat && (!minSubStatValue.HasValue || rune.SubStat2Value >= minSubStatValue) && (!maxSubStatValue.HasValue || rune.SubStat2Value <= maxSubStatValue)) ||
                (rune.SubStat3 == subStat && (!minSubStatValue.HasValue || rune.SubStat3Value >= minSubStatValue) && (!maxSubStatValue.HasValue || rune.SubStat3Value <= maxSubStatValue)) ||
                (rune.SubStat4 == subStat && (!minSubStatValue.HasValue || rune.SubStat4Value >= minSubStatValue) && (!maxSubStatValue.HasValue || rune.SubStat4Value <= maxSubStatValue));

            return valueMatches;
        }

        private bool CheckInnateStat(RuneTypeStat? innateStat, int? minInnateStatValue, int? maxInnateStatValue, SWEXRune rune)
        {
            if (innateStat == null)
            {
                return true;
            }

            return rune.InnateStat == innateStat &&
                   (!minInnateStatValue.HasValue || rune.InnateStatValue >= minInnateStatValue) &&
                   (!maxInnateStatValue.HasValue || rune.InnateStatValue <= maxInnateStatValue);
        }
    }
}
