namespace FileSystem.Commands
{
    public class AddFileCommand : ICommand
    {
        public string DirectoryPath { get; }
        public string FileName { get; }
        public string Content { get; }

        public AddFileCommand(string fileName, string content, string directoryPath)
        {
            FileName = fileName;
            Content = content;
            DirectoryPath = directoryPath;
        }
    }
}

