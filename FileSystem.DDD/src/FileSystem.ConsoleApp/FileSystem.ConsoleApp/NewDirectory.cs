namespace FileSystem.ConsoleApp;

/// <summary>
/// Directory creation model
/// </summary>
public class NewDirectory
{
    /// <summary>
    /// Collection of subdirectories
    /// </summary>
    public string[] SubDirectories { get; set; }
    
    /// <summary>
    /// Root directory
    /// </summary>
    public string Root { get; set; }
}