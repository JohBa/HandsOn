using System;
using System.IO;
using ContactManagerPCL.Droid;
using ContactManagerPCL.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileLocatorAndroid))]
namespace ContactManagerPCL.Droid
{
    public class FileLocatorAndroid : IFileLocator
    {
        
        public string GetFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}