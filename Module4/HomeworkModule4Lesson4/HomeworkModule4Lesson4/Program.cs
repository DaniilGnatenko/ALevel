using HomeworkModule4Lesson4.Data;
using HomeworkModule4Lesson4.Data.Entities;

namespace HomeworkModule4Lesson4;

public sealed class Program
{
    public static void Main(string[] args)
    {
        using (var context = new ApplicationDbContextFactory().CreateDbContext())
        {
            AddEntitiesExample(context);
            context.Database.EnsureCreated();
        }
        Console.WriteLine("Hello World!");
    }
    public static void AddEntitiesExample(ApplicationDbContext context)
    {
        var pet = new PetEntity
        {
            Id = 101,
            Name = "Adolf",
            CategoryId = 1,
            BreedId = 2,
            Age = 5,
            LocationId = 142,
            ImageUrl = "",
            Description = "Good pet"

        };

        context
            .Pets
            .Add(pet);

        var category = new CategoryEntity
        {
            Id = 1,
            CategoryName = "Cat"
        };

        context
            .Categories
            .Add(category);

        var breed = new BreedEntity
        {
            Id = 2,
            BreedName = "Turkish angora",
            CategoryID = 1
        };

        context
            .Breeds
            .Add(breed);

        var location = new LocationEntity
        {
            Id = 142,
            LocationName = "Ukraine"
        };

        context
            .Locations
            .Add(location);
    }
}