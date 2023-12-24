using System.Runtime.CompilerServices;
using NewYearGift.Repositories;
using NewYearGift.Services;

namespace NewYearGift;

public class NewYearGift
{
    

    public static void Main()
    {
       UserAction userAction = new UserAction();
        userAction.Start();

        Console.ReadKey();
    }
}