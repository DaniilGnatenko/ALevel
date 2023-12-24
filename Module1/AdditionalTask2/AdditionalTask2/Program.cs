using System.Globalization;

namespace AdditionalTask2;

public class PositivOrNegative
{
    public static void Main()
    {
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        Console.WriteLine("Hello! I'll try to recognize if the number is positive, negative or 0."
            + "\nUse symbol \".\" to make your number float!");
        Console.WriteLine("Please, enter your number:");
        string? userInput = Console.ReadLine();
        int checkTheSymbol = userInput.IndexOf(",");
        double userNumber;
        while (!double.TryParse(userInput, out userNumber) || checkTheSymbol != -1)
        {
            Console.WriteLine("This is not a floating point number or you used the wrong symbol for floating point number!");
            Console.WriteLine("Please, use symbol \".\" to make your number float!");
            userInput = Console.ReadLine();
            checkTheSymbol = userInput.IndexOf(",");
        }
        Console.WriteLine($"This is your number - {userNumber}");

        int positiveOrNegative;
        if (double.IsPositive(userNumber))
        {
            positiveOrNegative = 1;
        }
        else if (double.IsNegative(userNumber))
        {
            positiveOrNegative = -1;
        }
        else
        {
            positiveOrNegative = 0; 
        }

        
        switch (positiveOrNegative)
        {
            case 0:
                Console.WriteLine("Your number is 0!");
                break;
            case 1:
                Console.WriteLine("Your number is positive!");
                break;
            case -1:
                Console.WriteLine("Your number is negative!");
                break;
        }
        Console.ReadLine();
        


    }
}