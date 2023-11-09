using FileSystem.Commands;
using FileSystem.Commands.Contracts;
using FileSystem.Queries;
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
        var createFileCommand = new AddFileCommand("myFile.txt", "hello", "/root");
        createFileHandler.Handle(createFileCommand);

        IQueryHandler<GetFileContentQuery, string> contentQueryHandler = new GetFileContentQueryHandler(fileSystem);      
        var contentQuery = new GetFileContentQuery("/root/myFile.txt");
        string content = contentQueryHandler.Handle(contentQuery);
        Console.WriteLine(content); 

    }
}

