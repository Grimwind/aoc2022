using System.Text.RegularExpressions;

List<Stack<char>> stacks = new List<Stack<char>>() {
    new Stack<char>(new char[] {'B', 'W', 'N'}),
    new Stack<char>(new char[] {'L', 'Z', 'S', 'P', 'T', 'D', 'M', 'B'}),
    new Stack<char>(new char[] {'Q', 'H', 'Z', 'W', 'R'}),
    new Stack<char>(new char[] {'W', 'D', 'V', 'J', 'Z', 'R'}),
    new Stack<char>(new char[] {'S', 'H', 'M', 'B'}),
    new Stack<char>(new char[] {'L', 'G', 'N', 'J', 'H', 'V', 'P', 'B'}),
    new Stack<char>(new char[] {'J', 'Q', 'Z', 'F', 'H', 'D', 'L', 'S'}),
    new Stack<char>(new char[] {'W', 'S', 'F', 'J', 'G', 'Q', 'B'}),
    new Stack<char>(new char[] {'Z', 'W', 'M', 'S', 'C', 'D', 'J'}),
};

Stack<char> crane = new Stack<char>();

var instructions = File.ReadAllLines("instructions.txt");

Regex rex = new Regex("move ([0-9]+) from ([0-9]) to ([0-9])");
var idx = 0;
PrintStacks(stacks);
foreach(var instruction in instructions)
{
    
    Console.WriteLine($"{++idx} => {instruction}");
    var m = rex.Match(instruction);
    var count  = int.Parse(m.Groups[1].Value);
    var from = int.Parse(m.Groups[2].Value);
    var to = int.Parse(m.Groups[3].Value);

    // Crane CrateMover 9000
    // for(int i=0;i< count; i++)
    // {
    //     stacks[to-1].Push(stacks[from-1].Pop());
    // }

    // Crane CrateMover 9001
    for(int i=0;i< count; i++)
    {
        crane.Push(stacks[from-1].Pop());
    }
    for(int i=0;i< count; i++)
    {
        stacks[to-1].Push(crane.Pop());
    }

    //PrintStacks(stacks);
}
var result = "";
foreach(var stack in stacks) {
    result += stack.Peek().ToString();
}

Console.WriteLine($"{result}");

void PrintStacks(List<Stack<char>> stacks)
{
    var idx = 1;
    foreach(var stack in stacks) {
        var data = new string(stack.ToArray()).PadLeft(20);
        Console.WriteLine($"{idx}: {data}");
        idx ++;
    }
}