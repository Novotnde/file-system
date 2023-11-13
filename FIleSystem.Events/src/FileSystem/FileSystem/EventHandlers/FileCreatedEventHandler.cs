using FileSystem.Contracts;
using FileSystem.Events;
using FileSystem.Models;

namespace FileSystem.EventHandlers;

public class FileCreatedEventHandler : IFileSystemEventHandler
{
    private readonly FileSystemDirectory _rootDirectory;
    public FileCreatedEventHandler(FileSystemDirectory rootDirectory)
    {
        _rootDirectory = rootDirectory;
    }

    public IFileSystemItem? Handle(FileSystemEvent fileSystemEvent)
    {
        if (fileSystemEvent is not FileCreatedEvent createdEvent) return null;
        var directory = NavigateToDirectory(createdEvent.Path);
        return directory.AddFile(createdEvent.Name,createdEvent.Content);
    }
    
    private FileSystemDirectory NavigateToDirectory(List<string> pathSegments)
    {
        var current = _rootDirectory;
        foreach (var segment in pathSegments.Take(pathSegments.Count - 1))
        {
            if (current.Items.TryGetValue(segment, out var item) && item is FileSystemDirectory subdir)
            {
                current = subdir;
            }
            else
            {
                return null;  // Directory path not found
            }
        }
        return current;
    }

}

