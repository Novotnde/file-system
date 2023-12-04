using FileSystem.Application.Contracts;
using FileSystem.Domain.Entities;
using FileSystem.Infrastructure.Utilities.Contracts;
using File = FileSystem.Domain.Entities.File;
using Directory = FileSystem.Domain.Entities.Directory;
using Path = FileSystem.Domain.ValueObjects.Path;

namespace FileSystem.Application.Services;

/// <summary>
/// inherits from <see cref="IFileSystemService"/>
/// </summary>
public class FileSystemService : IFileSystemService
{
    IPathBuilder pathBuilder;

    public FileSystemService(IPathBuilder pathBuilder)
    {
        this.pathBuilder = pathBuilder;
    }
    
    /// <inheritdoc/>
    public void AddFile(string name, string content, string[] subDirectories, string root)
    {
        ValidateInput(name, "Name");
        ValidateInput(content, "Content");
        ValidateObject(subDirectories, "SubDirectories");
        ValidateInput(root, "Root");

        var path = pathBuilder
            .AddDirectory(root)
            .AddDirectory(subDirectories)
            .AddFile(name)
            .Build();
        
        var address = new Path { Address = path };
        var directory = new Directory(root);
        
        if (subDirectories.Length > 0)
        {
            foreach (var dir in subDirectories)
            {  
                var parentDirectory = new Directory(dir);
                parentDirectory.AddSubDirectory(directory);
            }
        }
        
        var file = new File(name, content, address);
        directory.AddFile(file);
        
    }
    
    /// <inheritdoc/>
    public Entry GetEntry(string name)
    {
        var path = new Path { Address = name };
        var entry = RetrieveEntryByPath(path);

        return entry;
    }

    private Entry RetrieveEntryByPath(Path path)
    {
        return new File("DummyFile", "DummyContent", path);
    }

    private void ValidateInput(string input, string paramName)
    {
        if(string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(paramName, $"{paramName} cannot be null");
        }
    }
    
    private void ValidateObject(object input, string paramName)
    {
        if(input is null)
        {
            throw new ArgumentNullException(paramName, $"{paramName} cannot be null");
        }
    }
}