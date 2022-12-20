public class Directory
{
    public Directory(Directory parent, string current)
    {
        Parent = parent;
        Name = current;

        if (parent == null)
        {
            Path = Name;
        }
        else
        {
            Path = Parent.Path + "/" + Name;
        }

        dirs = new List<Directory>();
        files = new List<AocFile>();
    }

    public Directory NewDir(string next)
    {
        var dir = dirs.SingleOrDefault(d => d.Name == next);
        if (dir == null)
        {
            dir = new Directory(this, next);
            dirs.Add(dir);
        }
        return dir;
    }
    public void NewFile(string name, int size)
    {
        var file = files.SingleOrDefault(f => f.Name == name);
        if (file == null)
        {
            file = new AocFile(name, size);
            files.Add(file);
        }
    }

    public Directory Parent { get; set; }
    public string Path { get; set; }
    public string Name { get; set; }

    public long Size => files.Sum(f => f.Size) + dirs.Sum(d => d.Size);

    public List<Directory> dirs { get; set; }

    public List<AocFile> files { get; set; }
}