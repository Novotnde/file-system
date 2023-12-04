using FileSystem.Infrastructure.Utilities;

namespace FileSystem.Test;

public class PathBuilderTests
{
    [Test]
    public void AddDirectory_ShouldAppendDirectoriesWithSlash()
    {
        var pathBuilder = new PathBuilder();
        string[] directories = { "dir1", "dir2", "dir3" };

        pathBuilder.AddDirectory(directories);
        var result = pathBuilder.Build();
        
        Assert.That(result, Is.EqualTo("dir1/dir2/dir3/"));
    }

    [Test]
    public void AddFile_ShouldAppendFileName()
    {
        var pathBuilder = new PathBuilder();

        pathBuilder.AddFile("test.txt");
        var result = pathBuilder.Build();
        
        Assert.That(result, Is.EqualTo("test.txt"));
    }

    [Test]
    public void Build_ShouldReturnEmptyStringForEmptyPathBuilder()
    {
        var pathBuilder = new PathBuilder();

        var result = pathBuilder.Build();

        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Build_ShouldReturnCorrectPathForMixedOperations()
    {
        var pathBuilder = new PathBuilder();

        pathBuilder.AddDirectory(new[] { "dir1", "dir2" }).AddFile("test.txt");
        var result = pathBuilder.Build();

        Assert.That(result, Is.EqualTo("dir1/dir2/test.txt"));
    }
}