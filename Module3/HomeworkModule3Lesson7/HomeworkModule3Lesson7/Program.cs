using System.Text.Json;

namespace HomeworkModule3Lesson7;

public sealed class Program
{
    internal static async Task Main()
    {
        string configString = File.ReadAllText("config.json");
        Config config = JsonSerializer.Deserialize<Config>(configString);
        Logger logger = new Logger(config);
        App app = new App(logger);

        await app.Run();
    }
}

public sealed class Config
{
    public int ConfigurableNumber { get; set; }
}