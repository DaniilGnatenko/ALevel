using HomeworkModule3Lesson6;

public sealed class Program
{
    internal static async Task Main()
    {
        var source = new TaskCompletionSource();
        MessageBox messageBox = new MessageBox();
        messageBox.WindowClosed += (state) =>
        {
            Console.WriteLine($"State: {state}");
            HandleWindowClosedResult(state);
            source.SetResult();
        };

        messageBox.Open();
        await source.Task;
    }

    private static void HandleWindowClosedResult(State state)
    {
        switch (state)
        {
            case State.Ok:
                Console.WriteLine("The operation has been confirmed");
                break;

            case State.Cancel:
                Console.WriteLine("the operation was rejected");
                break;
        }
    }
}


