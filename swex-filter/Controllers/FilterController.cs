using SwexFilter.Data;
using SwexFilter.Models;
using SwexFilter.Models.Enums;

namespace SwexFilter.Controllers;

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

    public SwexRune ApplyFiltersToRune(SwexRune rune)
    {
        rune.FiltersPassed = _dataContext.Filters.Where(filter => CheckRune(filter, rune)).ToList();
        return rune;
    }

    private static bool CheckRune(Filter filter, SwexRune rune)
    {
        return CheckRelativeScore(filter, rune);
    }

    private static bool CheckRelativeScore(Filter filter, SwexRune rune)
    {
        if (filter.RelativeScore == null) return true;
        double runeRelativeScore = 0;
        if (rune is { InnateStat: not null, InnateStatValue: not null } &&
            filter.SubPropertiesWanted.Contains(rune.InnateStat.Value))
            runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.InnateStat.Value, rune.InnateStatValue.Value);
        if (rune is { SubStat1: not null, SubStat1Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat1.Value))
            runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat1.Value, rune.SubStat1Value.Value);
        if (rune is { SubStat2: not null, SubStat2Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat2.Value))
            runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat2.Value, rune.SubStat2Value.Value);
        if (rune is { SubStat3: not null, SubStat3Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat3.Value))
            runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat3.Value, rune.SubStat3Value.Value);
        if (rune is { SubStat4: not null, SubStat4Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat4.Value))
            runeRelativeScore += MaxStatValues.GetScoreRollValue(rune.SubStat4.Value, rune.SubStat4Value.Value);

        return runeRelativeScore >= filter.RelativeScore;
    }
}