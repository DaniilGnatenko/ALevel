using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson5.Services.Abstractions
{
    internal interface IFileService
    {
        public void WriteLogToFile(string filePath, string directoryPath, string log);
        public void DeleteOldestFile(string directoryPath);

    }
}
