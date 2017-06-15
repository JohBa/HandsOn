namespace ContactManagerPCL.Services
{
    public interface IFileLocator
    {
        string GetFilePath(string fileName);
    }
}
