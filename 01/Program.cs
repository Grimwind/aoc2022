// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var data = File.ReadAllLines("input.txt");

int sum = 0;
List<int> calories_sums = new List<int>();
for(int i=0; i<data.Length ; i++)
{
    if (string.IsNullOrEmpty(data[i]))
    {
        calories_sums.Add(sum);
        sum = 0;
    }
    else 
    {
        var calory = int.Parse(data[i]);
        sum+= calory;
    }
}

Console.WriteLine($"{calories_sums.Max()}");

List<int> ordered_calories = calories_sums.OrderDescending<int>().ToList();

Console.WriteLine($"{ordered_calories[0]+ordered_calories[1]+ordered_calories[2]}");

void PrintStacks(List<Stack<char>> stacks)
{
    
}