namespace FileSystem.Infrastructure.Utilities.Contracts;

/// <summary>
/// Interface for building file system paths.
/// </summary>
public interface IPathBuilder
{
    /// <summary>
    /// Adds a directory to the path.
    /// </summary>
    /// <param name="directory">The name of the directory to add.</param>
    /// <returns>The updated path builder instance.</returns>
    IPathBuilder AddDirectory(string directory);
    
    /// <summary>
    /// Adds directories to the path.
    /// </summary>
    /// <param name="directories">An array of directory names to add.</param>
    /// <returns>The updated path builder instance.</returns>
    IPathBuilder AddDirectory(string[] directories);
    
    /// <summary>
    /// Adds a file to the path.
    /// </summary>
    /// <param name="file">The name of the file to add.</param>
    /// <returns>The updated path builder instance.</returns>
    IPathBuilder AddFile(string file); 
    
    /// <summary>
    /// Builds and returns the constructed file system path.
    /// </summary>
    /// <returns>The built file system path as a string.</returns>
    string Build();
}