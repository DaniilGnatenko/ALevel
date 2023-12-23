using HomeworkModule3Lesson1;

class Program
{
    static void Main()
    {
        CustomCollection<string> customCollection = ["One", "Two", "Three", "abc" , "dbc", "acdc"];

        Console.WriteLine("Original collection:");
        foreach (var item in customCollection)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Count: {customCollection.Count()}");

        customCollection.Sort();

        Console.WriteLine("Sorted collection:");
        foreach (var item in customCollection)
        {
            Console.WriteLine(item);
        }

        customCollection.SetDefaultAt(1);

        Console.WriteLine("After setting default at index 1:");
        foreach (var item in customCollection)
        {
            
            if (item == null) 
            {
                Console.WriteLine("Defult");
            }
            else 
            { 
                Console.WriteLine(item); 
            }
        }
        Console.ReadKey();
    }
}
