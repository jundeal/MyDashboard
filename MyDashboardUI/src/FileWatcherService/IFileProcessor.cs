using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    interface IFileProcessor
    {
        void ProcessFile(string filePath);
    }
}
