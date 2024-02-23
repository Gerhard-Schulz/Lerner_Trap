using Lerner_Trap;

var dict = new Dictionary<int, List<Trapezoid>>();
var search = new Stack<Trapezoid>();
var result = new Stack<Trapezoid>();

var lines = File.ReadAllLines("9.txt");
int count = int.Parse(lines[0]);
int i = 1;
for (; i <= count; i++)
{
    var trapezoid = Trapezoid.Parse(i, lines[i]);
    if (dict.TryGetValue(trapezoid.LeftAngle, out var list))
    {
        list.Add(trapezoid);
    }
    else
    {
        dict.Add(trapezoid.LeftAngle, new List<Trapezoid>() { trapezoid });
    }
}

var res = FindPartialCycles(0);

if (!res)
{
    File.WriteAllText("OUTPUT.txt", "0");
    return;
}

var array = new Trapezoid[count];
i = 0;
while (result.Count != 0)
{
    array[i++] = result.Pop();
}
File.WriteAllText("OUTPUT.txt", string.Join(' ', (object?[])array));


bool FindPartialCycles(int start)
{
    int temp = start;
    while (true)
    {
        if (!dict!.TryGetValue(temp, out var list))
        {
            return false;
        }
        var edge = list.FirstOrDefault(x => !x.Visited);
        if (edge == null)
        {
            if (temp != start)
            {
                return false;
            }
            if (search.Count == 0)
            {
                return result.Count == count;
            }
            var last = search!.Pop();
            result!.Push(last);
            return FindPartialCycles(last.LeftAngle);
        }
        search!.Push(edge);
        temp = edge.RightAngle;
        edge.Visited = true;
    }
}
