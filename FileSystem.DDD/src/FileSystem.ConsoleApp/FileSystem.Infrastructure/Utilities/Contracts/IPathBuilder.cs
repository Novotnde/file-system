namespace FileSystem.Infrastructure.Utilities.Contracts;

/// <summary>
/// 
/// </summary>
public interface IPathBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="directories"></param>
    /// <returns></returns>
    IPathBuilder AddDirectory(string[] directories);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    IPathBuilder AddFile(string file); 
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    string Build();
}