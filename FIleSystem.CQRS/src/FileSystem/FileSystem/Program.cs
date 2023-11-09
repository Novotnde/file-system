using FileSystem.Commands;
using FileSystem.Commands.Contracts;
using FileSystem.Queries;

namespace FileSystem;

class Program
{
    static void Main(string[] args)
    {
        IFileSystem fileSystem = new InMemoryFileSystem();
        ICommandHandler<AddDirectoryCommand> createDirectoryHandler = new AddDirectoryCommandHandler(fileSystem);

        ICommandHandler<AddFileCommand> createFileHandler = new AddFileCommandHandler(fileSystem);
        
        var createDirectoryCommand = new AddDirectoryCommand("/", "root");
        createDirectoryHandler.Handle(createDirectoryCommand);

        createDirectoryHandler.Handle(new AddDirectoryCommand("/root", "documents"));
        createDirectoryHandler.Handle(new AddDirectoryCommand("/root/documents", "projects"));
        createFileHandler.Handle(new AddFileCommand("project1/txt", "Hello project1", "/root/documents/projects"));

        var queryHandler = new GetSubDirectoriesQueryHandler(fileSystem);
        var subDirectories = queryHandler.Handle(new GetSubDirectoriesQuery("/root/documents"));

        foreach (var dir in subDirectories)
        {
            Console.WriteLine($"Directory: {dir.Name}");
            foreach (var item in dir.Items.OfType<File>())
            {
                Console.WriteLine($" - File: {item.Name}");
            }
        }
    }
}

