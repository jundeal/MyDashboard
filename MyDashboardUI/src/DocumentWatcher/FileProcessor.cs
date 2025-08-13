using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentWatcher
{
    internal class FileProcessor
    {
        

        public static void ProcessFile(string filePath)
        {
            var documentProcessor = new DocumentProcessor();

            var data = documentProcessor.ProcessDocument(filePath);

            var fileName = File. (filePath);

            string backupFilePath = System.IO.Path.Combine(DataBackup, fileName);
            System.IO.File.Move(filePath, backupFilePath);
        }
    }
}
