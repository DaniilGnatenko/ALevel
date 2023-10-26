namespace Homework6._1;

internal class Logger
{

    string[] logType = new string[] { "Info", "Warning", "Error" };
    public string[] logs = new string[100];
    private int logsIndex = 0;

    public void CreateLog(int logTypeIndex, string message)
    {
        string log = $"{DateTime.Now}: {logType[logTypeIndex]}: {message}";
        logs[logsIndex] = log;
        Console.WriteLine(logs[logsIndex]);
        logsIndex++;
    }

}
