internal class FirstClass
{
    public delegate void ShowDelegate(bool result);
    public static int Multiply(int first, int second)
    {
        return first * second;
    }
}


internal class SecondClass
{
    public delegate bool ResultDelegate(int result);

    public delegate int MultiplyDelegate(int first, int second);

    int multiplyResult = 0;

    public ResultDelegate Calc(MultiplyDelegate multiplyDelegate, int first, int second)
    {
        multiplyResult = multiplyDelegate.Invoke(first, second);

        ResultDelegate newDelegate = Result;

        return newDelegate;
    }

    public bool Result(int value)
    {
        if (multiplyResult % value == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

public class Program
{
    public static void Show(bool result)
    {
        Console.WriteLine(result);
    }

    public static void Main()
    {
        SecondClass second = new SecondClass();

        FirstClass.ShowDelegate show = Show;

        SecondClass.MultiplyDelegate multiply = FirstClass.Multiply;

        SecondClass.ResultDelegate result = second.Calc(multiply, 15, 32);

        show(result(6));

        show(result(7));

        Console.ReadLine();
    }
}

