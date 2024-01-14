using HomeworkModule4Lesson6.Data;
using HomeworkModule4Lesson6.Services.Abstractions;

namespace HomeworkModule4Lesson6;

public class App
{
    private readonly IPetService _petService;
    private readonly ILocationService _locationService;
    private readonly IBreedService _breedService;
    private readonly ICategoryService _categoryService;

    public App(
        IPetService petService,
        ILocationService locationService,
        IBreedService breedService,
        ICategoryService categoryService)
    {
        _petService = petService;
        _locationService = locationService;
        _breedService = breedService;
        _categoryService = categoryService;
    }

    public async Task Start()
    {
        var category1 = await _categoryService.AddCategoryAsync("Cat");
        var category2 = await _categoryService.AddCategoryAsync("Dog");
        var category3 = await _categoryService.AddCategoryAsync("Parrot");
        var category4 = await _categoryService.AddCategoryAsync("Hamster");

        var catBreed1 = await _breedService.AddBreedAsync("American Shorthair", category1);
        var catBreed2 = await _breedService.AddBreedAsync("Bengal", category1);
        var catBreed3 = await _breedService.AddBreedAsync("Maine Coon", category1);
        var catBreed4 = await _breedService.AddBreedAsync("Norwegian Forest Cat", category1);

        var dogBreed1 = await _breedService.AddBreedAsync("Bulldog", category2);
        var dogBreed2 = await _breedService.AddBreedAsync("Beagle", category2);
        var dogBreed3 = await _breedService.AddBreedAsync("Bull Terrier", category2);
        var dogBreed4 = await _breedService.AddBreedAsync("American Eskimo", category2);

        var parrotBreed1 = await _breedService.AddBreedAsync("African Grey", category3);
        var parrotBreed2 = await _breedService.AddBreedAsync("Eclectus", category3);
        var parrotBreed3 = await _breedService.AddBreedAsync("Macaws", category3);

        var hamsterBreed1 = await _breedService.AddBreedAsync("Chinese hamster", category4);
        var hamsterBreed2 = await _breedService.AddBreedAsync("Russian dwarf hamster", category4);

        var location1 = await _locationService.AddLocationAsync("Ukraine");
        var location2 = await _locationService.AddLocationAsync("Poland");
        var location3 = await _locationService.AddLocationAsync("USA");
        var location4 = await _locationService.AddLocationAsync("Germany");

        var rnd = new Random();

        var pet1 = await _petService.AddPetAsync("grisha", rnd.Next(0, 10), catBreed1, location1, category1);
        var pet2 = await _petService.AddPetAsync("andruha", rnd.Next(0, 10), catBreed2, location1, category1);
        var pet3 = await _petService.AddPetAsync("adolf", rnd.Next(0, 10), catBreed3, location4, category1);
        var pet4 = await _petService.AddPetAsync("arnold", rnd.Next(0, 10), catBreed4, location3, category1);
        var pet5 = await _petService.AddPetAsync("arkadii", rnd.Next(0, 10), dogBreed1, location3, category2);
        var pet6 = await _petService.AddPetAsync("armen", rnd.Next(0, 10), dogBreed3, location2, category2);
        var pet7 = await _petService.AddPetAsync("artur", rnd.Next(0, 10), dogBreed2, location3, category2);
        var pet8 = await _petService.AddPetAsync("lapa", rnd.Next(0, 10), dogBreed4, location1, category2);
        var pet9 = await _petService.AddPetAsync("misha", rnd.Next(0, 10), dogBreed1, location1, category2);
        var pet10 = await _petService.AddPetAsync("katya", rnd.Next(0, 10), catBreed1, location2, category1);
        var pet11 = await _petService.AddPetAsync("lena", rnd.Next(0, 10), catBreed2, location4, category1);
        var pet12 = await _petService.AddPetAsync("alina", rnd.Next(0, 10), dogBreed1, location4, category2);
        var pet13 = await _petService.AddPetAsync("lobzik", rnd.Next(0, 10), dogBreed4, location4, category2);
        var pet14 = await _petService.AddPetAsync("topor", rnd.Next(0, 10), parrotBreed1, location3, category3);
        var pet15 = await _petService.AddPetAsync("lalala", rnd.Next(0, 10), parrotBreed2, location2, category3);
        var pet16 = await _petService.AddPetAsync("pupupu", rnd.Next(0, 10), parrotBreed3, location1, category3);
        var pet17 = await _petService.AddPetAsync("lololo", rnd.Next(0, 10), parrotBreed1, location2, category3);
        var pet18 = await _petService.AddPetAsync("keklol", rnd.Next(0, 10), parrotBreed3, location3, category3);
        var pet19 = await _petService.AddPetAsync("cheburek", rnd.Next(0, 10), hamsterBreed2, location4, category4);
        var pet20 = await _petService.AddPetAsync("prosto", rnd.Next(0, 10), hamsterBreed1, location1, category4);

        var groupByResult = _petService.GetGroupedPetsAsync(3, "Ukraine");
        foreach (var group in groupByResult.Result)
        {
            Console.WriteLine($"{group.CategoryName} - {group.BreedCount}");
        }
    }
}
