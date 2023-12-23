
using HomeworkModule2Lesson5.Config;
using HomeworkModule2Lesson5.Services;
using HomeworkModule2Lesson5.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace HomeworkModule2Lesson5
{
    internal class App
    {
        private readonly IActions _action;
        private readonly ILoggerService _logger;
        private readonly LoggerOption _loggerOption;
        private readonly IFileService _fileService;


        public App(IActions action, ILoggerService logger, IOptions<LoggerOption> loggerOptions, IFileService fileService)
        {
            _action = action;
            _logger = logger;
            _loggerOption = loggerOptions.Value;
            _fileService = fileService;
        }

        public void Run()
        {
            string path = @"C:\SomeDir";
            string subpath = @"program\avalon";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var dirInfo = Directory.CreateDirectory($"{path}\\{subpath}");

            for (int i = 0; i < 100; i++)
            {
                int randomMethod = new Random().Next(1, 4);
                switch (randomMethod)
                {
                    case 1:
                        _action.StartMethod();
                        break;
                    case 2:
                        try
                        {
                            _action.Exception();
                        }
                        catch (Exception ex)
                        {
                            _loggerOption.Path = Path.Combine(dirInfo.FullName, $"{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}.txt");
                            _fileService.WriteLogToFile(_loggerOption.Path, dirInfo.FullName, _logger.CreateLog($"Action failed by reason : {ex.Message}", Common.LogType.Error));
                        }
                        break;
                    case 3:
                        try
                        {
                            _action.BusinessException();
                        }
                        catch (BusinessException ex)
                        {
                            _loggerOption.Path = Path.Combine(dirInfo.FullName, $"{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}.txt");
                            _fileService.WriteLogToFile(_loggerOption.Path, dirInfo.FullName, _logger.CreateLog($"Action got this custom Exception : {ex.Message}", Common.LogType.Warning));
                        }
                        break;
                }
                
            }
        }
    }
}
