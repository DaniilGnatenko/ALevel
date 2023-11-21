using HomeworkModule2Lesson5.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson5.Services
{
    internal class FileService : IFileService
    {

        public void DeleteOldestFile(string directoryPath)
        {
            string[] logFiles = Directory.GetFiles(directoryPath);
            if (logFiles.Length > 3)
            {
                Array.Sort(logFiles);
                File.Delete(logFiles[0]);
            }
        }
        public void WriteLogToFile(string filePath, string directoryPath, string log)
        {
            
            if (File.Exists(filePath))
            {
                string newFilePath = Path.Combine(directoryPath, $"{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}.txt");
                File.WriteAllText(newFilePath, log + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(filePath, log + Environment.NewLine);
            }
            DeleteOldestFile(directoryPath);
        }
    }
}
