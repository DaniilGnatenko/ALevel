namespace HomeworkModule3Lesson7;

internal sealed class App
{
    private Logger _logger;
    
    public App(Logger logger)
    {
        _logger = logger;
        logger.BackUpEvent += BackUp;
    }

    public async Task Run()
    {
        var tasks = new List<Task>()
        {
            LogEntries(),
            LogEntries()
        };

        await Task.WhenAll(tasks);
    }
   
    public async Task LogEntries()
    {
        for (int i = 0; i < 50; i++)
        {
           await _logger.LogToFile();
        }
    }  

    public void BackUp()
    {
        string fileName = $"{DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss_fff")}.txt";
        Directory.CreateDirectory("Backup");
        File.Copy("logs.txt", $"Backup\\{fileName}");
        Console.WriteLine("Backup created");
    }

}
