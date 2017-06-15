using System;
using System.IO;
using ContactManagerPCL.iOS;
using ContactManagerPCL.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileLocatorIos))]
namespace ContactManagerPCL.iOS
{
    public class FileLocatorIos : IFileLocator
    {
        public string GetFilePath(string fileName)
        {
            string docFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);

        }
    }
}