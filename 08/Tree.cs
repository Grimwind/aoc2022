public class Tree
{
    public int X { get; set; }
    public int Y { get; set; }
    public int H { get; set; }
    public bool Visible { get; set; }

    public int ScenicScore { get; set; } = 0;
    public Tree(int x, int y, int h)
    {
        X = x;
        Y = y;
        H = h;
        Visible = false;
    }
}