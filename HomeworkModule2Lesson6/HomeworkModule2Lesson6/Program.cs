using HomeworkModule2Lesson6;
using HomeworkModule2Lesson6.Repositories;
using HomeworkModule2Lesson6.Repositories.Abstractions;
using HomeworkModule2Lesson6.Services;
using HomeworkModule2Lesson6.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection()
    .AddScoped<IElectricalAppliances, ElectricalAppliances>()
    .AddScoped<IHouse, House>()
    .AddTransient<IElectricalAppliancesService, ElectricalAppliancesService>()
    .AddTransient<IHouseService, HouseService>()
    .AddTransient<IUserService, UserService>()
    .AddTransient<App>();

var provider = serviceCollection.BuildServiceProvider();
var app = provider.GetService<App>();
app!.Run();
