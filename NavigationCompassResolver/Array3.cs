using System.Numerics;
using System.Runtime.CompilerServices;

namespace NavigationCompassResolver;

[InlineArray(3)]
public struct Array3<T> : IEquatable<Array3<T>>, IEqualityOperators<Array3<T>, Array3<T>, bool> where T : struct, IEquatable<T>
{
    private T _;

    public Array3(T _1, T _2, T _3)
    {
        this[0] = _1;
        this[1] = _2;
        this[2] = _3;
    }

    public readonly bool Equals(Array3<T> arr)
        => ((ReadOnlySpan<T>)this).SequenceEqual(arr);
    public override readonly bool Equals(object? obj)
        => obj is Array3<T> a && Equals(a);
    public override readonly int GetHashCode()
        => HashCode.Combine(this[0], this[1], this[2]);

    public static bool operator ==(Array3<T> left, Array3<T> right)
        => left.Equals(right);
    public static bool operator !=(Array3<T> left, Array3<T> right)
        => !left.Equals(right);
}

public static class Array3Extension
{
    public static Array3<T> Add<T>(this Array3<T> array, Array3<T> array2) where T : struct, IEquatable<T>, IAdditionOperators<T, T, T>
        => new(array[0] + array2[0], array[1] + array2[1], array[2] + array2[2]);
    public static Array3<T> Modulus<T>(this Array3<T> array, T value) where T : struct, IEquatable<T>, IModulusOperators<T, T, T>
        => new(array[0] % value, array[1] % value, array[2] % value);
}
