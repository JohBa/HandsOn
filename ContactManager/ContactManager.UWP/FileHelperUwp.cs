using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using ContactManager.Services;
using ContactManager.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelperUwp))]
namespace ContactManager.UWP
{
    public class FileHelperUwp : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
