using System;
using System.IO;
using ContactManager.Droid;
using ContactManager.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperDroid))]
namespace ContactManager.Droid
{
    public class FileHelperDroid : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}