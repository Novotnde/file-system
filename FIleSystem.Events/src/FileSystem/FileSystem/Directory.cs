namespace FileSystem;

public class Directory
{
    public string Name { get; }
    public Dictionary<string, string> Files { get; } = new Dictionary<string, string>();
    public Dictionary<string, Directory> Subdirectories { get; } = new Dictionary<string, Directory>();

    public Directory(string name)
    {
        Name = name;
    }
}