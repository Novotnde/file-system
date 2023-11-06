using FileSystem.Models;

namespace FileSystem;

class Program
{
    static void Main(string[] args)
    {
        var fileSystem = new FileSys();
        var directory = fileSystem.Root.AddDirectory("dir1");
        var file = directory.AddFile("file.txt", "Hello, World!");

        var foundFile = fileSystem.FindEntry("/dir1/file.txt") as FileSystemFile;
        if (foundFile != null)
        {
            Console.WriteLine(foundFile.Content);
        }
        Console.WriteLine(fileSystem.RenameDirectory("dir1", "dir2").Name);
        Console.WriteLine(directory.RenameFile("file.txt", "file2.txt").Name);
    }
}

