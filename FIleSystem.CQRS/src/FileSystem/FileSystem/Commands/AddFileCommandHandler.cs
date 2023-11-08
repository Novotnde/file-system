namespace FileSystem.Commands;

public class AddFileCommandHandler : ICommandHandler<AddFileCommand>
{
    private readonly IFileSystem _fileSystem;

    public AddFileCommandHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Handle(AddFileCommand command)
    {
        _fileSystem.CreateFile(command.DirectoryPath, command.FileName, command.Content);
    }
}