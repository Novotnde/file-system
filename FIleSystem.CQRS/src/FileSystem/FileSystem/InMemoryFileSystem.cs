using FileSystem.Commands;
using FileSystem.Queries.Contracts;

namespace FileSystem
{
	public class InMemoryFileSystem
	{
        private Dictionary<string, string> files = new Dictionary<string, string>();

        public void Handle(CreateFileCommandHandler command)
        {
            files[command.Path] = command.Content;
        }

        // Command to write to a file
        public void Handle(WriteToFileCommandHandler command)
        {
            if (files.ContainsKey(command.Path))
            {
                files[command.Path] = command.Content;
            }
            else
            {
                throw new ArgumentNullException("No such file exists");
            }
        }

        public string Handle(GetFileContentQuery query)
        {
            if (files.TryGetValue(query.Path, out var content))
            {
                return content;
            }
            else
            {
                throw new ArgumentNullException("No such file exists");
            }
        }
    }
}

