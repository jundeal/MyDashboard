using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentAIProcessor;
using OpenAI.RealtimeConversation;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace FileWatcherService
{
    public class FileProcessor : IFileProcessor
    {
        private string _dataBackup = "";   //
        private string _dataProcessed = ""; //
        private string _dataArchive = ""; //

        private readonly AISettings _aiSettings;

        public FileProcessor(IOptions<DataFolders> folderSettings, IOptions<AISettings> aiSettings)
        {
            if (folderSettings.Value == null)
            {
                throw new ArgumentNullException(nameof(folderSettings.Value));
            }

            _dataBackup = folderSettings.Value.DataBackupFolder;
            _dataProcessed = folderSettings.Value.DataProcessedFolder;
            _dataArchive = folderSettings.Value.DataArchiveFolder;

            _aiSettings = aiSettings.Value;
        }

        public void ProcessFile(string filePath)
        {
            //TODO: Currently this process is for COL Financial statement. Need to dd more processors for different file types.

            Document document = new(_aiSettings);

            string content = document.ProcessDocumentAsync(filePath, "COL Finanancial Statement").Result;

            var processedFileName = string.Concat(_dataProcessed, @"COL\", Path.GetFileNameWithoutExtension(filePath), ".json");

            File.WriteAllText(processedFileName, content);

            File.Move(filePath, Path.Combine(_dataArchive, Path.GetFileName(filePath)), true);

        }
    }
}

