using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    public class DataFolders 
    {
        public string DataInFolder { get; set; } = string.Empty;
        public string DataBackupFolder { get; set; } = string.Empty;
        public string DataProcessedFolder { get; set; } = string.Empty;
        public string DataArchiveFolder { get; set; } = string.Empty;
    }
}
