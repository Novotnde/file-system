namespace FileSystem.Contracts
{
    // Contract for file
	public interface IFileSystemFile : IFileSystemItem
    {
        string Content { get; set; }

        long Size { get; }
    }
}

