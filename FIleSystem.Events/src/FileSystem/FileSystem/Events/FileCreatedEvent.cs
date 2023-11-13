namespace FileSystem.Events;

public class FileCreatedEvent : FileSystemEvent
{
    public string Name { get; }

    public List<string> Path { get; }
    public string Content { get; }

    public FileCreatedEvent(string name, string content, List<string> path)
    {
        Name = name;
        Content = content;
        Path = path;
    }
}