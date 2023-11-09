using FileSystem.Queries.Contracts;

namespace FileSystem.Queries
{
	public class GetFileContentQuery : IQuery<string>
	{
		public string FilePath { get; }

		public GetFileContentQuery(string filePath)
		{
			FilePath = filePath;
		}
	}
}

