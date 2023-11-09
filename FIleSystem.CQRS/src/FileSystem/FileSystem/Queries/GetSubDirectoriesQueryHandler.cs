using FileSystem.Queries.Contracts;

namespace FileSystem.Queries;

public class GetSubDirectoriesQueryHandler : IQueryHandler<GetSubDirectoriesQuery, IEnumerable<Directory>>
{
    private readonly IFileSystem _fileSystem;

    public GetSubDirectoriesQueryHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IEnumerable<Directory> Handle(GetSubDirectoriesQuery query)
    {
        return _fileSystem.GetSubDirectories(query.DirectoryPath);
    }
}
