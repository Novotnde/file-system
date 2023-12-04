using System.Text;
using FileSystem.Infrastructure.Utilities.Contracts;

namespace FileSystem.Infrastructure.Utilities;

/// <summary>
/// inherits from <see cref="IPathBuilder"/>
/// </summary>
public class PathBuilder : IPathBuilder
{
    private StringBuilder path = new StringBuilder();
    
    /// <inheritdoc/>
    public IPathBuilder AddDirectory(string dir)
    {
        path.Append(dir).Append('/');
        return this;
    }
    /// <inheritdoc/>
    public IPathBuilder AddDirectory(string[] directories)
    {
        foreach (var directory in directories)
        {
            path.Append(directory).Append('/');

        } return this;
    }

    /// <inheritdoc/>
    public IPathBuilder AddFile(string file)
    {
        path.Append(file);
        return this;
    }

    /// <inheritdoc/>
    public string Build()
    {
        return path.ToString();
    }
}
