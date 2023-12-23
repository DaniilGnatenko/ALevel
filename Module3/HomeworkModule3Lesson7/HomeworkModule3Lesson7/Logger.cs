namespace HomeworkModule3Lesson7;

internal sealed class Logger
{
    public event IsTimeToBackUp BackUpEvent;
    public int _backUpCount = 1;
    private Config _config;

    public Logger(Config config)
    {
        _config = config;
    }

    public async Task LogToFile()
    {
        LogType logType = RandomLogType();
        var log = $"{DateTime.UtcNow:MM/dd/yyyy hh:mm:ss.fff}: {logType}: {RandomMessage(logType)}";
        File.AppendAllTextAsync("logs.txt", log + '\n');
        Console.WriteLine(log);
        BackUpCount();
    }

    public void BackUpCount()
    {
        if ((_backUpCount % _config.ConfigurableNumber) == 0)
        {
            Console.WriteLine("Time To BackUP!");
            BackUpEvent.Invoke();
        }
        _backUpCount++;
    }

    private LogType RandomLogType()
    {
        Random random = new Random();
        return (LogType)random.Next(0, 3);
    }

    private string RandomMessage(LogType logType)
    {
        string message = String.Empty;
        switch (logType)
        {
            case LogType.Error:
                message = "I broke a logic!";
                break;
            case LogType.Info:
                message = "Info log!";
                break;
            case LogType.Warning:
                message = "Skipped logic in method!";
                break;
        }
        return message;
    }
}

