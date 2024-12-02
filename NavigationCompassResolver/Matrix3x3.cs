namespace NavigationCompassResolver;

public struct Matrix3x3(int m11, int m12, int m13, int m21, int m22, int m23, int m31, int m32, int m33)
{
    public int M11 = m11;
    public int M12 = m12;
    public int M13 = m13;
    public int M21 = m21;
    public int M22 = m22;
    public int M23 = m23;
    public int M31 = m31;
    public int M32 = m32;
    public int M33 = m33;

    public static Array3<int> operator *(Matrix3x3 mat, Array3<int> vec)
        => new(mat.M11 * vec[0] + mat.M12 * vec[1] + mat.M13 * vec[2],
               mat.M21 * vec[0] + mat.M22 * vec[1] + mat.M23 * vec[2],
               mat.M31 * vec[0] + mat.M32 * vec[1] + mat.M33 * vec[2]);
}
