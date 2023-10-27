namespace Homework6._1;

internal class Logger
{
    private static Logger instance;

    private Logger() { }

    public static Logger GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }

    readonly string[] logType = new string[] { "Info", "Warning", "Error" };
    private string[] logs = new string[100];
    private int logsIndex = 0;

    public void CreateLog(int logTypeIndex, string message)
    {
        string log = $"{DateTime.Now}: {logType[logTypeIndex]}: {message}";
        logs[logsIndex] = log;
        Console.WriteLine(logs[logsIndex]);
        logsIndex++;
    }

    public string[] GetLogs()
    {
        return logs;
    }
}
