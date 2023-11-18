using HomeworkModule2Lesson5.Common;
using HomeworkModule2Lesson5.Config;
using HomeworkModule2Lesson5.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace HomeworkModule2Lesson5.Services
{
    internal class LoggerService : ILoggerService
    {
        private readonly LoggerOption _loggerOptions;

        public LoggerService(IOptions<LoggerOption> loggerOptions)
        {
            _loggerOptions = loggerOptions.Value;
        }

        public string CreateLog(string message, LogType logType)
        {
            var log = $"{DateTime.UtcNow:MM/dd/yyyy hh:mm:ss.fff}: {logType}: {message}";
            Console.WriteLine(log);
            return log;
        }
    }
}
