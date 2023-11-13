namespace FileSystem.Events;

public class DirectoryCreatedEvent : FileSystemEvent
{
    public string Name { get; }
    public DirectoryCreatedEvent(string name)
    {
        Name = name;
    }
}