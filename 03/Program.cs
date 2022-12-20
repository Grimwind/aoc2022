// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var rucksacks = File.ReadAllLines("input.txt");
var sum = 0;
foreach(var rucksack in rucksacks)
{
    var size = rucksack.Length /2;
    
    var comp1 = rucksack.Substring(0, size);
    var comp2 = rucksack.Substring(size, size);
    var comp1Chars = comp1.ToList<char>();
    var comp2Chars = comp2.ToList<char>();

    var common = comp1Chars.Intersect(comp2Chars).ToList();
    
    Console.WriteLine($"{common.Count()} {common[0]} {GetPriority(common[0])}");
    sum += GetPriority(common[0]);
}
Console.WriteLine($"{sum}" );

var sum2 = 0;
for (int i=0 ; i<= rucksacks.Length-3 ; i+=3)
{
    var comp1Chars = rucksacks[i].ToList<char>();
    var comp2Chars = rucksacks[i+1].ToList<char>();
    var comp3Chars = rucksacks[i+2].ToList<char>();

    var badge = comp1Chars.Intersect(comp2Chars).Intersect(comp3Chars).ToList();

    Console.WriteLine($"{badge.Count()} {badge[0]} {GetPriority(badge[0])}");
    sum2 += GetPriority(badge[0]);
}

Console.WriteLine($"{sum2}");



int GetPriority(char item)
{
    int priority;
    if (item > 90) 
    {
        priority = item - 96;
    }
    else
    {
        priority = item - 38;
    }

    return priority;
}
    