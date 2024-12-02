namespace NavigationCompassResolver;

class Program
{
    static void Main()
    {
        Console.WriteLine("""
                          引航罗盘解析器
                          =======提示=======
                          *输入顺序说明：
                            请按从内至外的顺序输入罗盘信息
                          *天轴朝向说明：
                              1   2
                               \ /
                            0 --*-- 3
                               / \
                              5   4
                          *映射关系说明：
                            映射关系见游戏罗盘下方，如可操作的层数不足三层，则剩余层请输入000（或简写为0）
                            例：
                            若显示●○●（亮暗亮），则应输入101
                            若显示○○●（暗暗亮），则应输入001（或简写为1）
                          ==================
                          """);
        Console.WriteLine("---罗盘信息录入---");
        Array3<CompassRing> rings = new();
        for (int i = 0; i < 3; i++)
        {
            CompassRing ring = new();
            Console.WriteLine($"第{i + 1}罗盘");
            Console.WriteLine(" - 明亮的星位数量：");
            ring.BrightAstralMarkCount = ReadByte();
            Console.WriteLine(" - 天轴朝向：");
            ring.CelestialAxisDirection = ReadByte();
            Console.WriteLine(" - 旋转方向 [0=顺时针，1=逆时针]：");
            ring.IsClockwizeRotation = ReadByte() == 0;
            rings[i] = ring;
        }
        Console.WriteLine("------------------");
        Console.WriteLine("---映射关系录入---");
        Array3<Array3<bool>> relationships = new();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"第{i + 1}层");
            byte r = ReadByte();
            relationships[i] = new(
                r / 100 != 0,
                r / 10 % 10 != 0,
                r % 10 != 0);
        }
        Console.WriteLine("------------------");
        Console.WriteLine("正在计算……");
        Array3<int> result = Resolver.Resolve(rings, relationships);
        if (result[0] < 0 || result[1] < 0 || result[2] < 0)
            Console.WriteLine("无法找到解，请检查输入是否正确");
        else
        {
            Console.WriteLine("找到解：");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"第{i + 1}层旋转{result[i]}次");
        }
    }

    static byte ReadByte()
    {
        byte value;
        while (!byte.TryParse(Console.ReadLine(), out value))
            Console.WriteLine("请输入有效数字");
        return value;
    }
}
