using FileSystem.Queries.Contracts;

namespace FileSystem.Queries;

public class GetSubDirectoriesQuery : IQuery<IEnumerable<Directory>>
{
    public string DirectoryPath { get; }
    public GetSubDirectoriesQuery(string directoryPath)
    {
        DirectoryPath = directoryPath; 
    }
}
