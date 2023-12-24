namespace HomeworkModule3Lesson6;

    internal sealed class MessageBox
    {
        public event Action<State> WindowClosed;
        public async void Open()
        {
            Console.WriteLine("window is open!");

            await Task.Delay(3000);

            Console.WriteLine("window was closed by the user!");

            State state = RandomState();

            WindowClosed?.Invoke(state);
        }

        private State RandomState()
        {
            Random random = new Random();
            int randomState = random.Next(0, 2);
            if (randomState == 0)
            {
                return State.Ok;
            }
            else
            {
                return State.Cancel;
            }
        }
    }

