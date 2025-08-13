using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentWatcher
{
    internal class FileMonitoring 
    {
        private const string DataIn = @"C:\Users\geron\Local\MyDashboard\Data\In\";

        FileSystemWatcher _fileSystemWatcher;

        public static void StartMonitoring()
        {
            if (!Directory.Exists(DataIn))
            {
                throw new DirectoryNotFoundException($"The directory {DataIn} does not exist.");
            }
            FileMonitoring fileMonitoring = new FileMonitoring();
            fileMonitoring._fileSystemWatcher = new FileSystemWatcher(DataIn)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size,
                Filter = "*.*" // Adjust the filter as needed
            };
            fileMonitoring._fileSystemWatcher.Created += fileMonitoring.OnChanged;
            fileMonitoring._fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            
        }
    }
}
