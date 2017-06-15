using System.IO;
using Windows.Storage;
using ContactManagerPCL.Services;
using ContactManagerPCL.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(FileLocatorUwp))]
namespace ContactManagerPCL.UWP
{
    public class FileLocatorUwp : IFileLocator
    {
        public string GetFilePath(string fileName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
        }
    }
}
