public sealed class Program
{
    internal static void Main()
    {
        File.WriteAllText("Hello.txt", "Hello");
        File.WriteAllText("World.txt", "World!");

        var task = Task.Run(() =>  ConcatenationMethod("Hello.txt", "World.txt"));
        var phrase = task.Result;
        Console.WriteLine(phrase);
        Console.ReadLine();
    }

    public static async Task<string> HelloMethod(string fileName)
    {
        return await File.ReadAllTextAsync(fileName);
    }
    
    public static async Task<string> WorldMethod(string fileName)
    {
        return await File.ReadAllTextAsync(fileName);
    }

    public static async Task<string> ConcatenationMethod(string firstFile, string secondFile)
    {
        Task<string> task1 = HelloMethod(firstFile);
        Task<string> task2 = WorldMethod(secondFile);

        await Task.WhenAll(task1, task2);

        return task1.Result + ' ' + task2.Result;
    }
}