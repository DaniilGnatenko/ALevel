using HomeworkModule2Lesson5.Config;
using HomeworkModule2Lesson5.Services.Abstractions;
using HomeworkModule2Lesson5;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HomeworkModule2Lesson5.Services;



void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

    serviceCollection.AddTransient<IFileService, FileService>()
        .AddTransient<ILoggerService, LoggerService>()
        .AddTransient<IActions, Actions>()
        .AddTransient<App>();
        
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("E:\\Education\\ALevel\\ALevel\\HomeworkModule2Lesson5\\HomeworkModule2Lesson5\\config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
app!.Run();
