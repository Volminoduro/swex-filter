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
        if (rune.InnateStat is { RuneTypeStat: not null, Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.InnateStat.RuneTypeStat.Value))
            runeRelativeScore +=
                MaxStatValues.GetScoreRollValue(rune.InnateStat.RuneTypeStat.Value, rune.InnateStat.Value.Value);
        if (rune.SubStat1 is { RuneTypeStat: not null, Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat1.RuneTypeStat.Value))
            runeRelativeScore +=
                MaxStatValues.GetScoreRollValue(rune.SubStat1.RuneTypeStat.Value, rune.SubStat1.Value.Value);
        if (rune.SubStat2 is { RuneTypeStat: not null, Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat2.RuneTypeStat.Value))
            runeRelativeScore +=
                MaxStatValues.GetScoreRollValue(rune.SubStat2.RuneTypeStat.Value, rune.SubStat2.Value.Value);
        if (rune.SubStat3 is { RuneTypeStat: not null, Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat3.RuneTypeStat.Value))
            runeRelativeScore +=
                MaxStatValues.GetScoreRollValue(rune.SubStat3.RuneTypeStat.Value, rune.SubStat3.Value.Value);
        if (rune.SubStat4 is { RuneTypeStat: not null, Value: not null } &&
            filter.SubPropertiesWanted.Contains(rune.SubStat4.RuneTypeStat.Value))
            runeRelativeScore +=
                MaxStatValues.GetScoreRollValue(rune.SubStat4.RuneTypeStat.Value, rune.SubStat4.Value.Value);

        return runeRelativeScore >= filter.RelativeScore;
    }
}