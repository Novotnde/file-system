using FileSystem.Commands.Contracts;

namespace FileSystem.Commands;

public class AddDirectoryCommandHandler : ICommandHandler<AddDirectoryCommand>
{
    private readonly IFileSystem _fileSystem;

    public AddDirectoryCommandHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }
    public void Handle(AddDirectoryCommand command)
    {
        _fileSystem.CreateDirectory(command.ParentDirectoryPath, command.DirectoryName);
    }
}