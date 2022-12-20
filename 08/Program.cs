// See https://aka.ms/new-console-template for more information


var map = File.ReadAllLines("input.txt");

var TreeMap = new List<Tree>();

int y = 0;
foreach(var line in map)
{
    int x = 0;
    foreach(var point in line.ToArray())
    {
        var h = int.Parse(point.ToString());
        TreeMap.Add(new Tree(x, y, h));
        x++;
    }
    y++;
}

int max_x = TreeMap.Max(t => t.X);
int max_y = TreeMap.Max(t => t.Y);

foreach(var tree in TreeMap)
{
    if (tree.X == 0 || tree.X == max_x) {
        tree.Visible = true;
        continue;
    }
    if (tree.Y == 0 || tree.Y == max_y) {
        tree.Visible = true;
        continue;
    }

    // trees to left
    var treesToLeft = TreeMap.Where(t => t.Y == tree.Y && t.X < tree.X);
    if (treesToLeft.Where(t => t.H >= tree.H).Count() == 0) {
        tree.Visible = true;
        
    }

    // trees to right
    var treesToRight = TreeMap.Where(t => t.Y == tree.Y && t.X > tree.X);
    if (treesToRight.Where(t => t.H >= tree.H).Count() == 0) {
        tree.Visible = true;
        
    }

    // trees above
    var treesAbove = TreeMap.Where(t => t.X == tree.X && t.Y < tree.Y);
    if (treesAbove.Where(t => t.H >= tree.H).Count() == 0) {
        tree.Visible = true;
        
    }

    // trees below
    var treesBelow = TreeMap.Where(t => t.X == tree.X && t.Y > tree.Y);
    if (treesBelow.Where(t => t.H >= tree.H).Count() == 0) {
        tree.Visible = true;
        
    }

    var leftTree = treesToLeft.Where(t=> t.H >= tree.H).MaxBy(t => t.X);
    var leftScore = leftTree == null ? tree.X : tree.X - leftTree.X;

    var rightTree = treesToRight.Where(t=> t.H >= tree.H).MinBy(t => t.X);
    var rightScore = rightTree == null ? max_x - tree.X : rightTree.X - tree.X;
    
    var aboveTree = treesAbove.Where(t => t.H>= tree.H).MaxBy(t => t.Y);
    var aboveScore = aboveTree == null ? tree.Y : tree.Y - aboveTree.Y;

    var belowTree = treesBelow.Where(t => t.H>= tree.H).MinBy(t => t.Y);
    var belowScore = belowTree == null ? max_y - tree.Y : belowTree.Y - tree.Y;

    tree.ScenicScore = leftScore * rightScore * aboveScore * belowScore;
}

for (int iy = 0; iy <= max_y ; iy++)
{
    for( int ix = 0 ; ix <= max_x ; ix ++)
    {
        //var vis = TreeMap.Where(t => t.X == ix && t.Y == iy).Single().Visible.Value ? "1" : "0";
        var vis = TreeMap.Where(t => t.X == ix && t.Y == iy).Single().ScenicScore;
        Console.Write($"{vis}");
    }
    Console.WriteLine("");
}

Console.WriteLine($"{TreeMap.Where(t => t.Visible == true).Count()}");
Console.WriteLine($"{TreeMap.Max(t => t.ScenicScore)}");
