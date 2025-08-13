using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    internal class FileWatcher : IFileWatcher
    {
        private const string DataIn = @"C:\Users\geron\Local\MyDashboard\Data\In\";
        static FileSystemWatcher? _watcher;

        private readonly IFileProcessor _fileProcessor;

        public FileWatcher(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor ?? throw new ArgumentNullException(nameof(fileProcessor));
        }

        public void StartWatching()
        {
            
            _watcher = new FileSystemWatcher(DataIn);
            _watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            _watcher.Filter = "*.*"; // Adjust filter as needed
            
            _watcher.Created += OnFileCreated;
            _watcher.EnableRaisingEvents = true;
        }

        public void StopWatching()
        {
            
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
            }
        }

        void OnFileCreated(object sender, FileSystemEventArgs e)
        {

            _fileProcessor.ProcessFile(e.FullPath);
        }

        public void ProcessFiles(ILogger logger)
        {
            var files = Directory.GetFiles(DataIn);

            foreach (var file in files)
            {
                logger.LogInformation($"PROCESSING {file}...", DateTime.Now);

               // FileProcessor fileProcessor = new FileProcessor();
                _fileProcessor.ProcessFile(file);

                logger.LogInformation($"COMPLETED PROCESSING {file}.", DateTime.Now);
            }
        }

    }
}
