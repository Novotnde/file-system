using Path = FileSystem.Domain.ValueObjects.Path;

namespace FileSystem.Domain.Entities;

/// <summary>
/// Class representing a file in the file system.
/// </summary>
public class File : Entry
{
    /// <summary>
    /// Gets or sets the content of the file.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="File"/> class.
    /// </summary>
    /// <param name="name">The name of the file.</param>
    /// <param name="content">The content of the file.</param>
    /// <param name="path">The path of the file.</param>
    public File(string name, string content, Path path)
    {
        Name = name;
        Content = content;
        CreatedAt = DateTime.Now;
        ModifiedAt = DateTime.Now;
        Path = path;
    }
}