
using FileSystem.Contracts;

namespace FileSystem.Models
{
    public class FileSystemDirectory : IFileSystemDirectory
    {
        public string Content { get; set; }

        public long Size => GetSize();

        public string Name { get; set; }

        public DateTime CreationDate { get; private set; }

        public DateTime ModificationDate { get; set; }

        public IDictionary<string, IFileSystemItem> Items {get; }

        public FileSystemDirectory(string name)
        {
            Name = name;
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
            Items = new Dictionary<string, IFileSystemItem>();
        }

        public IFileSystemDirectory AddDirectory(string name)
        {
            var directory = new FileSystemDirectory(name);
            Items.Add(name, directory);
            return directory;
        }

        public IFileSystemFile AddFile(string name, string content)
        {
            var file = new FileSystemFile(name, content);
            Items.Add(name, file);
            return file;
        }

        public IEnumerable<IFileSystemItem> GetAllItemsRecursive()
        {
            var allItems = new List<IFileSystemItem>();
            foreach(var item in Items.Values)
            {
                allItems.Add(item);
                if(item is FileSystemDirectory fileSystemDirectory)
                {
                    allItems.AddRange(fileSystemDirectory.GetAllItemsRecursive());
                }
            }
            return allItems;
        }

        private long GetSize()
        {
            return Items.Values.OfType<IFileSystemFile>().Sum(file => file.Size);
        }

        public IFileSystemItem Rename(string newName)
        {
            Name = newName;
            ModificationDate = DateTime.UtcNow;
            return this;
        }

        public IFileSystemFile RenameFile(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(newName));
            }
            if (Items.TryGetValue(oldName, out IFileSystemItem item) && item is FileSystemFile file)
            {
                Items.Remove(oldName);
                file.Rename(newName);
                Items[newName] = file;
                this.ModificationDate = DateTime.UtcNow;
                return file;
            }
            else
            {
                throw new FileNotFoundException("File not found in directory.");
            }
        }


    }
}

