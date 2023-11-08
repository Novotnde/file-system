

namespace FileSystem
{
    public class InMemoryFileSystem : IFileSystem
    {
        private readonly Directory _root = new Directory { Name = "root" };
        
        public void CreateFile(string directoryPath, string fileName, string content)
        {
            var directory = GetDirectoryByPath(directoryPath);
            if (directory != null)
            {
                var file = new File { Name = fileName, Content = content };
                directory.AddItem(file); 
            }
            else
            {
                throw new DirectoryNotFoundException($"The directory '{directoryPath}' does not exist.");
            }
        }


        public void CreateDirectory(string parentDirectoryPath, string directoryName)
        {
            var parentDirectory = GetDirectoryByPath(parentDirectoryPath);
            if (parentDirectory == null)
            {
                throw new DirectoryNotFoundException($"The directory '{parentDirectoryPath}' does not exist.");
            }

            if (parentDirectory.Items.Any(i => i.Name.Equals(directoryName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"A directory with the name '{directoryName}' already exists.");
            }

            var newDirectory = new Directory { Name = directoryName };
            parentDirectory.AddItem(newDirectory);
        }        
        
        private Directory? GetDirectoryByPath(string path)
        {
            var currentDirectory = _root;
            if (path == "/")
            {
                return _root;
            }

            var parts = path.Trim('/').Split('/');

            foreach (var part in parts)
            {
                currentDirectory = currentDirectory.Items?
                    .OfType<Directory>()
                    .FirstOrDefault(d => d.Name.Equals(part, StringComparison.OrdinalIgnoreCase));

                if (currentDirectory == null)
                {
                    return null;
                }
            }

            return currentDirectory;
        }

    }

}

