namespace FileSystem.Events;

public class FileModifyEvent : FileSystemEvent
{
    public string OldName { get; set; }
    
    public string NewName { get; set; }

    public FileModifyEvent(string oldName, string newName)
    {
        OldName = oldName;
        NewName = newName;
    }

}