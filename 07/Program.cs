// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var instructions = File.ReadAllLines("input.txt");

var root = new Directory(null, "/");
Directory pwd = null;

List<Directory> dirTable = new List<Directory>();

foreach (var instruction in instructions)
{
    //Console.WriteLine($"=> {instruction}");
    var parts = instruction.Split(' ');
    if (parts[0] == "$")
    {
        if (parts[1] == "cd")
        {
            if (parts[2] == "/") pwd = root;
            else if (parts[2] == "..") pwd = pwd.Parent;
            else
            {
                pwd = pwd.NewDir(parts[2]);
                AddToDirTable(pwd);
            }

      //      Console.WriteLine(pwd.Path);
        }
    }
    else if (parts[0] == "dir")
    {
        pwd.NewDir(parts[1]);
    }
    else
    {
        pwd.NewFile(parts[1], int.Parse(parts[0]));
    }
}

long sum = 0;
foreach(var dir in dirTable)
{
    if (dir.Size < 100000)
    {
        sum += dir.Size;
    }
}

long total = 70000000;
long needed = 30000000;

long remaining = total - root.Size;

long minimal = needed - remaining;

var toDelete = dirTable.Where(d => d.Size > minimal).Select(d => d.Size).Min();

Console.WriteLine($"{minimal}");

foreach(var dir in dirTable.OrderBy(d => d.Size))
{
    Console.WriteLine($"{dir.Size} {dir.Path}");    
}

//PrintDirTree(root);
Console.WriteLine($"SUM: {sum}");
Console.WriteLine($"ToDelete: {toDelete}");



void AddToDirTable(Directory dir)
{
    if (dirTable.SingleOrDefault(d => d.Path == dir.Path) == null)
    {
        dirTable.Add(dir);
    }
}

void PrintDirTree(Directory currentDir, string padding = "")
{
    Console.WriteLine($"{padding}[{currentDir.Name}] ({currentDir.Size})");
    foreach (var dir in currentDir.dirs)
    {
        PrintDirTree(dir, padding + " ");
    }
    foreach (var file in currentDir.files)
    {
        Console.WriteLine($"{padding} {file.Name}");
    }
}