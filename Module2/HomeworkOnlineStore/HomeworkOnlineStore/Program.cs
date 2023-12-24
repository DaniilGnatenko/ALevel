using HomeworkOnlineStore.Repositories;
using HomeworkOnlineStore.Services;

namespace HomeworkOnlineStore;

public class Store
{
    public static void Main()
    {
        UserActions userActions = new UserActions();
        userActions.Start();
        Console.WriteLine("Thank you for visiting our store!");
        Console.ReadKey();
    }
}