namespace Lerner_Trap;

sealed class Trapezoid
{
    public int Index { get; private set; }
    public int LeftAngle { get; private set; }
    public int RightAngle { get; private set; }
    public bool Visited { get; set; }
    public Trapezoid(int index, int xb, int xc, int xd)
    {
        Index = index;
        LeftAngle = xb;
        RightAngle = xc - xd;
        Visited = false;
    }

    public static Trapezoid Parse(int index, string s)
    {
        var split = s.Split(' ');
        var xb = int.Parse(split[0]);
        var xc = int.Parse(split[1]);
        var xd = int.Parse(split[2]);
        return new Trapezoid(index, xb, xc, xd);
    }

    public override string ToString()
        => Index.ToString();
}
