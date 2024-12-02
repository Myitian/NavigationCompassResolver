using System.Numerics;

namespace NavigationCompassResolver;

public struct CompassRing : IEquatable<CompassRing>, IEqualityOperators<CompassRing, CompassRing, bool>
{
    /// <summary>天轴朝向</summary>
    public byte CelestialAxisDirection;
    /// <summary>明亮的星位数量</summary>
    public byte BrightAstralMarkCount;
    /// <summary>是否为顺时针旋向</summary>
    public bool IsClockwizeRotation;

    public readonly bool Equals(CompassRing other)
        => CelestialAxisDirection == other.CelestialAxisDirection
        && BrightAstralMarkCount == other.BrightAstralMarkCount
        && IsClockwizeRotation == other.IsClockwizeRotation;
    public override readonly bool Equals(object? obj)
        => obj is CompassRing ring && Equals(ring);
    public override readonly int GetHashCode()
        => HashCode.Combine(CelestialAxisDirection, BrightAstralMarkCount, IsClockwizeRotation);

    public static bool operator ==(CompassRing left, CompassRing right)
        => left.Equals(right);
    public static bool operator !=(CompassRing left, CompassRing right)
        => !left.Equals(right);
}
