
using HomeworkModule2Lesson5.Services.Abstractions;

namespace HomeworkModule2Lesson5.Services
{
    internal class Actions : IActions
    {
        private readonly ILoggerService _logger;
        public Actions(ILoggerService logger)
        {
            _logger = logger;
        }
        public void StartMethod() 
        {
            _logger.CreateLog("Start method: StartMethod()", Common.LogType.Info);
        }

        public void BusinessException() 
        {
            throw new BusinessException("Skipped logic in method!");
        }

        public void Exception()
        {
            throw new Exception("I broke a logic!");
        }
    }
}
