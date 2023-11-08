namespace FileSystem.Commands
{
    public class CreateFileCommandHandler 
    {
        public string DirectoryPath { get; }
        public string FileName { get; }
        public string Content { get; }

        public CreateFileCommandHandler(string fileName, string content, string directoryPath)
        {
            FileName = fileName;
            Content = content;
            DirectoryPath = directoryPath;
        }
    }
}

