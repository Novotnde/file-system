namespace FileSystem.Domain.Entities;

/// <summary>
/// Directory entity
/// </summary>
public class Directory : Entry
{
    /// <summary>
    /// Collection of files
    /// </summary>
    private List<File> files { get; } = new();

    /// <summary>
    /// Collection of subdirectories
    /// </summary>
    private List<Directory> subDirectories { get; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Directory"/> class.
    /// </summary>
    /// <param name="name">The name of the directory.</param>
    public Directory(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Adds a file to the directory.
    /// </summary>
    /// <param name="file">The file to add.</param>
    /// <exception cref="Exception">Thrown if the directory already exists.</exception>
    public void AddFile(File file)
    {
        if (Exists(file.Name))
        {
            throw new Exception("Directory already exists");
        }
        files.Add(file);
    }

    /// <summary>
    /// Adds a subdirectory to the directory.
    /// </summary>
    /// <param name="directory">The subdirectory to add.</param>
    /// <exception cref="Exception">Thrown if the subdirectory already exists.</exception>
    public void AddSubDirectory(Directory directory)
    {
        if (Exists(directory.Name))
        {
            throw new Exception("Directory already exists");
        }
        subDirectories.Add(directory);
    }

    /// <summary>
    /// Checks if a file or subdirectory with the given name already exists.
    /// </summary>
    /// <param name="name">The name to check.</param>
    /// <returns>True if the file or subdirectory exists, otherwise false.</returns>
    private bool Exists(string name)
    {
        return files.Any(f => f.Name == name) || subDirectories.Any(d => d.Name == name);
    }
}