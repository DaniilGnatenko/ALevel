namespace Homework6._1;

public class Program
{

    public static void Main()
    {
        Starter starter = new Starter();
        Logger logger = Logger.GetInstance;

        starter.Run();
        File.WriteAllLines("logs.txt", logger.GetLogs());
        Console.ReadLine();

    }
}