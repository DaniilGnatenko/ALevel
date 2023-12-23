namespace Homework;

public static class ReverseText
{
    static void Main()
    {
        Console.WriteLine("Hello! I will find the longest and the shortest strings!");
        Console.WriteLine("Please, write your text:");
        string text = Console.ReadLine();
        while (string.IsNullOrEmpty(text)) 
        {
            Console.WriteLine("Write text, please");
            text = Console.ReadLine();
        }
        

        char[] separators = { ',', '.', '!', '?' };
        string[] strings = text.Split(separators);

       /* foreach (string s in strings)
         {
             Console.WriteLine($"{s} + {s.Length}");
         } */

        int indexShortest = strings.Min(s => s.Length);
        string shortest = "";
        string Reverse(string shortest)
        {
            char[] charArray = strings[indexShortest].ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        int charsInString = 0;
        int indexLongest = 0; 
        int FindingIndexLongest()
        {
           for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].Length > charsInString)
                {
                    charsInString = strings[i].Length;
                    indexLongest = i;
                }
            }
           return indexLongest;
        }
        
        Console.WriteLine("The longest string is:");
        Console.WriteLine($"{strings[FindingIndexLongest()]}");
        Console.WriteLine($"Count of chars in string - {strings[FindingIndexLongest()].Length}");
        Console.WriteLine("Reversed the shortest string:");
        Console.WriteLine($"{Reverse(strings[indexShortest])}");
        Console.ReadLine();

       

        

    }
}