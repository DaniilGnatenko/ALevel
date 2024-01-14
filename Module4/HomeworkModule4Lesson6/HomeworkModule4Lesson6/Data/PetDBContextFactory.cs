using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HomeworkModule4Lesson6.Data;

public class PetDBContextFactory : IDesignTimeDbContextFactory<PetDBContext>
{
    private static string? _connectionString;

    public PetDBContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public PetDBContext CreateDbContext(string[]? args)
    {
        if (string.IsNullOrEmpty(_connectionString))
        {
            LoadConnectionString();
        }

        var builder = new DbContextOptionsBuilder<PetDBContext>();
        builder
             .UseLazyLoadingProxies()
             .UseSqlServer(_connectionString);

        return new PetDBContext(builder.Options);
    }

    private static void LoadConnectionString()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", optional: false);

        var configuration = builder.Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
}

