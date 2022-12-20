
var dataLines = File.ReadAllLines("input.txt");

var count = 0;
var overlap = 0;
foreach (var line in dataLines)
{
    var ass = new Assignment(line);
    Console.WriteLine($"{line}");
    if (ass.IsInefficient()) count++;
    if (ass.Overlap()) overlap++;
}

Console.WriteLine($"{count}, {dataLines.Length}");
Console.WriteLine($"{count}, {overlap}");

public class Assignment
{
    public Elf Elf1 { get; set; }
    public Elf Elf2 { get; set; }
    public Assignment(string data)
    {
        var ranges = data.Split(',');
        Elf1 = new Elf(ranges[0]);
        Elf2 = new Elf(ranges[1]);
    }

    public bool IsInefficient()
    {
        if (Elf1.Contains(Elf2) || Elf2.Contains(Elf1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Overlap()
    {
        if (Elf1.Overlap(Elf2) || Elf2.Overlap(Elf1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Elf
{
    public int Start;
    public int End;

    public Elf(string range)
    {
        var points = range.Split('-');
        Start = int.Parse(points[0]);
        End = int.Parse(points[1]);

    }

    public bool Contains(Elf elf)
    {
        if (this.Start <= elf.Start && this.End >= elf.End)
        {
            return true;
        }
        return false;
    }

    public bool Overlap(Elf elf)
    {
        if (this.Start <= elf.Start && this.End >= elf.Start)
        {
            return true;
        }
        if (this.Start <= elf.End && this.End >= elf.End)
        {
            return true;
        }

        return false;
    }
}