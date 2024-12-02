namespace NavigationCompassResolver;

public struct Matrix3x3(int a, int b, int c,
                        int d, int e, int f,
                        int g, int h, int i)
{
    public int A = a;
    public int B = b;
    public int C = c;
    public int D = d;
    public int E = e;
    public int F = f;
    public int G = g;
    public int H = h;
    public int I = i;

    public readonly int Determinant
        => A * (E * I - F * H)
         - B * (D * I - F * G)
         + C * (D * H - E * G);

    public static Array3<int> operator *(Matrix3x3 m33, Array3<int> m31)
        => new(m33.A * m31[0] + m33.B * m31[1] + m33.C * m31[2],
               m33.D * m31[0] + m33.E * m31[1] + m33.F * m31[2],
               m33.G * m31[0] + m33.H * m31[1] + m33.I * m31[2]);
}
