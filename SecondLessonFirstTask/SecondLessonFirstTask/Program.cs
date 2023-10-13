

using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello! You can sort there random values in array!");
Console.WriteLine("Enter minimum value in array:");
var minValueAsString = Console.ReadLine();
int minValue;
while (!int.TryParse(minValueAsString, out minValue))
    {
    Console.WriteLine("This is not a number! Enter minimum Value:");
    minValueAsString = Console.ReadLine();
    }



Console.WriteLine("Enter maximum value in array:");
var maxValueAsString = Console.ReadLine();
int maxValue;
while (!int.TryParse(maxValueAsString, out maxValue))
{
    Console.WriteLine("This is not a number! Enter maximum Value:");
    maxValueAsString = Console.ReadLine();
}
while (maxValue == minValue)
{
    Console.WriteLine("Maximum value can't be the same as minimum value!" + "\nPlease, Enter new Maximum Value:");
    maxValueAsString = Console.ReadLine();
    while (!int.TryParse(maxValueAsString, out maxValue))
    {
        Console.WriteLine("This is not a number! Enter maximum Value:");
        maxValueAsString = Console.ReadLine();
    }
}
while (maxValue < minValue)
{
    Console.WriteLine("Maximum value can't be less then minimum value!" + "\nPlease, Enter new Maximum Value:");
    maxValueAsString = Console.ReadLine();
    while (!int.TryParse(maxValueAsString, out maxValue))
    {
        Console.WriteLine("This is not a number! Enter maximum Value:");
        maxValueAsString = Console.ReadLine();
    }
}


Console.WriteLine("Enter length of array:");
var ArrayLenghtAsString = Console.ReadLine();
int ArrayLenght;
while (!int.TryParse(ArrayLenghtAsString, out ArrayLenght))
{
    Console.WriteLine("This is not a number! Enter array lenght:");
    ArrayLenghtAsString = Console.ReadLine();
}


int[] array = new int[ArrayLenght];


        for (int i = 0; i < array.Length; i++)
        {
        int number = i + 1;
        array[i] = new Random().Next(minValue, maxValue);
        Console.WriteLine(number + ": " + array[i]);
        }

Console.WriteLine("To show values between -100 and 100 type Show" +
    "\nIf you want exit - type Exit");
string choise = Console.ReadLine().ToLower();
switch (choise)
{
    case "exit":
        Console.Clear();
        break;
    case "show":
        Console.WriteLine("This values in array between -100 and 100:");
        for (int i = 0;i < array.Length;i++)
        {
            int number = i + 1;
            if (array[i] > -100 && array[i] < 100)
            {
                Console.WriteLine(number + ": " + array[i]);
            }
        }
       break;

}


Console.ReadKey();