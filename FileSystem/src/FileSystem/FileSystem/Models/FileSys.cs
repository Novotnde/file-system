using FileSystem.Contracts;

namespace FileSystem.Models
{
    public class FileSys : IFileSystem
	{
        public IFileSystemDirectory Root { get ; private set; }

        public FileSys()
        {
            Root = new FileSystemDirectory("Root");
        }

        public IFileSystemItem? FindEntry(string path)
        {
            if (path == "/") return Root;

            var parts = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return FindEntryRecursive(Root, parts, 0);
        }

        private IFileSystemItem? FindEntryRecursive(IFileSystemDirectory directory, string[] parts, int index)
        {
            if (index >= parts.Length) return null;

            string currentPart = parts[index];

            if (!directory.Items.TryGetValue(currentPart, out var item))
            {
                return null;
            }

            if (index == parts.Length - 1) return item;

            if (item is IFileSystemDirectory subdirectory)
            {
                return FindEntryRecursive(subdirectory, parts, index + 1);
            }

            return null;
        }


        public IFileSystemDirectory RenameDirectory(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(newName));
            }
            if (Root.Items.TryGetValue(oldName, out IFileSystemItem item) && item is FileSystemDirectory directory)
            { 
                Root.Items.Remove(oldName);
                directory.Rename(newName);
                Root.Items[newName] = directory;
                Root.ModificationDate = DateTime.UtcNow;
                return directory;
            }
            else
            {
                throw new FileNotFoundException("Directory not found.");
            }
        }
    }
}

