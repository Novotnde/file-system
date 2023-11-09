using FileSystem.Queries.Contracts;

namespace FileSystem.Queries;

public class GetFileContentQueryHandler : IQueryHandler<GetFileContentQuery, string>
{
    private readonly IFileSystem _fileSystem;

    public GetFileContentQueryHandler(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public string Handle(GetFileContentQuery query)
    {
        var file = _fileSystem.FindItem(query.FilePath) as File;
        if (file != null)
        {
            return file.Content;
        }
        else
        {
            throw new FileNotFoundException($"File at path '{query.FilePath}' was not found.");
        }
    }
}
