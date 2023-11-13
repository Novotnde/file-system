using FileSystem.Contracts;
using FileSystem.Events;

namespace FileSystem.EventHandlers;

public interface IFileSystemEventHandler
{
    IFileSystemItem? Handle(FileSystemEvent fileSystemEvent);
}
