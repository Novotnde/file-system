namespace FileSystem.Commands;

public class AddDirectoryCommand : ICommand
{
    public string ParentDirectoryPath { get; }
    public string DirectoryName { get; }
    public AddDirectoryCommand(string parentDirectoryPath, string directoryName)
    {
        ParentDirectoryPath = parentDirectoryPath;
        DirectoryName = directoryName;
    }
    
 
}
