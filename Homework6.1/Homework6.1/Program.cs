namespace Homework6._1;

public class Program
{

    public static void Main()
    {
        Starter starter = new Starter();
        Logger logger = new Logger();

        starter.Run();
        Console.ReadLine();

        File.WriteAllLines("logger.txt", logger.logs);
    }
}