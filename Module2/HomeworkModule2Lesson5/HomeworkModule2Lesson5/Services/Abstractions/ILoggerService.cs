using HomeworkModule2Lesson5.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModule2Lesson5.Services.Abstractions
{
    internal interface ILoggerService
    {
        string CreateLog(string message, LogType logType);
    }
}
