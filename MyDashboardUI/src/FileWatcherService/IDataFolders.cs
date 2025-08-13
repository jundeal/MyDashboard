using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    public interface IDataFolders
    {
        string DataInFolder { get; set; }
        string DataBackupFolder { get; set; }
        string DataProcessedFolder { get; set; }
        string DataArchiveFolder { get; set; }
    }
}
