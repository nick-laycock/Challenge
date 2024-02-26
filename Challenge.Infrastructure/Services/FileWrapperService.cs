
using Challenge.Services.Interfaces;

public class FileWrapperService : IFileWrapper
{
    public string[] ReadAllLines(string path)
    {
        return File.ReadAllLines(path);
    }
}