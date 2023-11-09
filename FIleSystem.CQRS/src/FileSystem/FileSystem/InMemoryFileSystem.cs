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

        public IEnumerable<Directory> GetSubDirectories(string directoryPath)
        {
            var directory = GetDirectoryByPath(directoryPath);
            if (directory == null)
            {
                throw new DirectoryNotFoundException($"The directory '{directoryPath}' does not exist.");
            }

            return GetSubDirectoriesRecursive(directory);
        }

        private IEnumerable<Directory> GetSubDirectoriesRecursive(Directory directory)
        {
            var allSubDirectories = new List<Directory>();
            foreach (var subDir in directory.Items.OfType<Directory>())
            {
                allSubDirectories.Add(subDir);
                allSubDirectories.AddRange(GetSubDirectoriesRecursive(subDir));
            }
            return allSubDirectories;
        }

        
        private Directory? GetDirectoryByPath(string path)
        {
            // If the path is "/", return the root directory.
            if (path == "/")
            {
                return _root;
            }

            // Split the path into parts.
            var parts = path.Trim('/').Split('/');
            var currentDirectory = _root;

            // Traverse the path parts to find the target directory.
            foreach (var part in parts)
            {
                // Search for the directory within the current directory's items.
                var nextDirectory = currentDirectory?.Items
                    .OfType<Directory>()
                    .FirstOrDefault(d => d.Name.Equals(part, StringComparison.OrdinalIgnoreCase));

                // If the directory is not found, return null.
                if (nextDirectory == null)
                {
                    return null;
                }

                // Set the found directory as the current directory.
                currentDirectory = nextDirectory;
            }

            // Return the found directory.
            return currentDirectory;
        }

    }
}

