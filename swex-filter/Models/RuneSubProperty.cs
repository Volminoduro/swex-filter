using SwexFilter.Models.Enums;

namespace SwexFilter.Models;

public class RuneSubProperty : IEquatable<RuneSubProperty>
{
    public RuneTypeStat? RuneTypeStat { get; set; }
    public int? Value { get; set; }
    public bool IsEnchanted { get; set; }
    public int GrindAmount { get; set; }

    public bool Equals(RuneSubProperty? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return RuneTypeStat == other.RuneTypeStat && Value == other.Value && IsEnchanted == other.IsEnchanted &&
               GrindAmount == other.GrindAmount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((RuneSubProperty)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RuneTypeStat, Value, IsEnchanted, GrindAmount);
    }
}