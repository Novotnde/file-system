using Path = FileSystem.Domain.ValueObjects.Path;

/// <summary>
/// Abstract class representing a file system entry.
/// </summary>
public abstract class Entry
{
    /// <summary>
    /// Gets or sets the name of the entry.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the creation timestamp.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the last modification timestamp.
    /// </summary>
    public DateTime ModifiedAt { get; set; }

    /// <summary>
    /// Gets or sets the path of the entry.
    /// </summary>
    public Path Path { get; set; }
}