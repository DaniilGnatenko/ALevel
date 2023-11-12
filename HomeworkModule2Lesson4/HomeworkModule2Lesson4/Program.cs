using HomeworkModule2Lesson4;
using HomeworkModule2Lesson4.Repositories;
using HomeworkModule2Lesson4.Repositories.Abstractions;
using HomeworkModule2Lesson4.Services;
using HomeworkModule2Lesson4.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddTransient<ISaladService, SaladService>()
    .AddScoped<ISalad, Salad>()
    .AddTransient<App>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var app = serviceProvider.GetService<App>();
app!.Start();
Console.ReadLine();

