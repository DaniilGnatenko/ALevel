using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Repositories.Abstractions;
using HomeworkModule4Lesson6.Repositories;
using HomeworkModule4Lesson6.Services.Abstractions;
using HomeworkModule4Lesson6.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HomeworkModule4Lesson6;
using Microsoft.Extensions.Logging;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<PetDBContext>(opts
        => opts.UseSqlServer(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<PetDBContext>, DbContextWrapper<PetDBContext>>();

    serviceCollection
        .AddTransient<IPetService, PetService>()
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<IPetRepository, PetRepository>()
        .AddTransient<IBreedRepository, BreedRepository>()
        .AddTransient<ILocationRepository, LocationRepository>()
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<IBreedService, BreedService>()
        .AddTransient<ILocationService, LocationService>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

// It could be possible variant for production code
// BUT need to be careful and don't run extra migration
if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<PetDBContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();