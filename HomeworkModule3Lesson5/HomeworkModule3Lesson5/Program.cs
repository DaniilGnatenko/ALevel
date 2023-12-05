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

    public static async Task<String> HelloMethod(string fileName)
    {
        return await File.ReadAllTextAsync(fileName);
    }
    
    public static async Task<String> WorldMethod(string fileName)
    {
        return await File.ReadAllTextAsync(fileName);
    }

    public static async Task<String> ConcatenationMethod(string firstFile, string secondFile)
    {
        var firstWord = await HelloMethod(firstFile);
        var secondWord = await WorldMethod(secondFile);
        return firstWord + ' ' + secondWord;
    }
}