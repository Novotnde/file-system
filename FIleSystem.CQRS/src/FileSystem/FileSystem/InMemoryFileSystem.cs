namespace FileSystem 
{
    public class InMemoryFileSystem : IFileSystem
    {
        private readonly Directory? _root = new Directory { Name = "root" };
        
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

            var newDirectory = new Directory { Name = directoryName, ModificationDate = DateTime.Now};
            parentDirectory.AddItem(newDirectory);
        }

        public IFileSystemItem? FindItem(string path)
        {
            if (path == "/")
            {
                return _root;
            }

            var parts = path.TrimStart('/').Split('/');
            var current = _root as IFileSystemItem; 

            foreach (var part in parts)
            {
                if (current is Directory directory)
                {
                    if (part == parts.Last())
                    {
                        var fileOrDirectory = directory.Items
                            .FirstOrDefault(i => i.Name.Equals(part, StringComparison.OrdinalIgnoreCase));
                
                        if (fileOrDirectory != null)
                        {
                            return fileOrDirectory;
                        }
                    }
                    else
                    {
                        current = directory.Items
                            .OfType<Directory>()
                            .FirstOrDefault(d => d.Name.Equals(part, StringComparison.OrdinalIgnoreCase));

                        if (current == null)
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }

            return current;
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
                currentDirectory = currentDirectory?.Items?
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

