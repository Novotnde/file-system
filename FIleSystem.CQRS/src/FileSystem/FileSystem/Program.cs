using FileSystem.Commands;
using FileSystem.Queries.Contracts;

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
        var createFileCommand = new AddFileCommand("text.json", "hello", "/root");
        createFileHandler.Handle(createFileCommand);


    }
}

