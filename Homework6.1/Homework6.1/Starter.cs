namespace Homework6._1;

internal class Starter
{
    Action action = new Action();
    internal void Run()
    {

        for (int i = 0; i < 100; i++)
        {
            int randomMethod = new Random().Next(1, 4);
            switch (randomMethod)
            {
                case 1:
                    action.InfoLog();
                    break;
                case 2:
                    action.WarningLog();
                    break;
                case 3:
                    action.ErrorLog();
                    break;
            }

        }
    }
}

