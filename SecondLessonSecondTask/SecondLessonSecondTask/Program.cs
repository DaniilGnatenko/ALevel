using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello! This is sorting app for array values!" + "\nThis is random values in First Array:");
int[] arrayA = new int[20];
int[] arrayB = new int[20];
for (int i = 0; i < arrayA.Length; i++)
{
    int number = i + 1;
    arrayA[i] = new Random().Next(-5000, 5000);
    Console.WriteLine(number + ": " + arrayA[i]);
    if (arrayA[i] <= 888)
    {
        arrayB[i] = arrayA[i];
    }
    else
    {
        arrayB[i] = new Random().Next(-5000, 5000);
    }
}

Console.WriteLine("Press enter to continue...");
Console.ReadKey();

Console.WriteLine("This is values in Second array, they include values <=888 from First Array");
for (int i = 0;i < arrayB.Length;i++)
{
    int number = i + 1;
    Console.WriteLine(number + ": " + arrayB[i]);
}

Console.WriteLine("Now i will sort Second Array in descending order");
Console.WriteLine("Press enter to continue...");
Console.ReadKey();
Array.Sort(arrayA);
Array.Sort(arrayB);
Array.Reverse(arrayB);
Console.WriteLine("This is First Array:");
Console.WriteLine("({0})", string.Join(",", arrayA));
Console.WriteLine("This is Second Array:");
Console.WriteLine("({0})", string.Join(",", arrayB));
Console.ReadKey();

