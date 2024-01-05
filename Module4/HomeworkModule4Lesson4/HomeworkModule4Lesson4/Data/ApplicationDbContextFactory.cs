﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HomeworkModule4Lesson4.Data;

internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private static string _connectionString;

    public ApplicationDbContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        if (string.IsNullOrEmpty(_connectionString))
        {
            LoadConnectionString();
        }

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder
             .UseLazyLoadingProxies()
             .UseSqlServer(_connectionString);

        return new ApplicationDbContext(builder.Options);
    }

    private static void LoadConnectionString()
    {
        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json", optional: false);

        var configuration = builder.Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
}