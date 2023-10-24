namespace HomeworkLessonFour;

public class ArraysWithAlphabet
{
    public static void Main()
    {
        int arrayLength;
        string arrayLengthAsString;
        do
        {
            Console.WriteLine("Please, Enter lenght of array:");
            arrayLengthAsString = Console.ReadLine();
        }
        while (!int.TryParse(arrayLengthAsString, out arrayLength));

        int[] arrayWithRandomValues = new int[arrayLength];
        int evenValuesArrayLength = 0;
        int oddValuesArrayLength = 0;
        int evenArrayIndex = 0;
        int oddArrayIndex = 0;
        char[] evenArray = new char[evenValuesArrayLength];
        char[] oddArray = new char[oddValuesArrayLength];
        int capitalLetterVal = 65;
        int smallLetterVal = 97;
        int countCapitalLetterEven = 0;
        int countCapitalLetterOdd = 0;

        for (int i = 0; i < arrayLength; i++)
        {
            arrayWithRandomValues[i] = new Random().Next(1, 27);

            if (arrayWithRandomValues[i] % 2 == 0)
            {
                evenValuesArrayLength++;
                Array.Resize(ref evenArray, evenValuesArrayLength);
                if (arrayWithRandomValues[i] == 4 || arrayWithRandomValues[i] == 8 || arrayWithRandomValues[i] == 10)
                {
                    evenArray[evenArrayIndex] = Convert.ToChar(arrayWithRandomValues[i] - 1 + capitalLetterVal);
                    evenArrayIndex++;
                    countCapitalLetterEven++;
                }
                else
                {
                    evenArray[evenArrayIndex] = Convert.ToChar(arrayWithRandomValues[i] - 1 + smallLetterVal);
                    evenArrayIndex++;
                }
            }
            else if (arrayWithRandomValues[i] % 2 != 0)
            {
                oddValuesArrayLength++;
                Array.Resize(ref oddArray, oddValuesArrayLength);
                if (arrayWithRandomValues[i] == 1 || arrayWithRandomValues[i] == 5 || arrayWithRandomValues[i] == 9)
                {
                    oddArray[oddArrayIndex] = Convert.ToChar(arrayWithRandomValues[i] - 1 + capitalLetterVal);
                    oddArrayIndex++;
                    countCapitalLetterOdd++;
                }
                else
                {
                    oddArray[oddArrayIndex] = Convert.ToChar(arrayWithRandomValues[i] - 1 + smallLetterVal);
                    oddArrayIndex++;
                }
            }
        }

        if (countCapitalLetterEven > countCapitalLetterOdd)
        {
            Console.WriteLine("First array has more uppercase latters:");
            Console.WriteLine("{0}", string.Join(',', evenArray));
        }
        else if (countCapitalLetterEven < countCapitalLetterOdd)
        {
            Console.WriteLine("Second array has more uppercase latters:");
            Console.WriteLine("{0}", string.Join(',', oddArray));
        }
        else if (countCapitalLetterEven == countCapitalLetterOdd)
        {
            Console.WriteLine("This arrays have same amount of uppercase latters!");
        }

        Console.WriteLine("This is first array with even values:{0}", string.Join(',', evenArray));
        Console.WriteLine("This is second array with odd values:{0}", string.Join(',', oddArray));
        Console.ReadLine();
    }
}