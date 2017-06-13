using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ContactManager.iOS;
using ContactManager.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperIos))]
namespace ContactManager.iOS
{
    public class FileHelperIos : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}