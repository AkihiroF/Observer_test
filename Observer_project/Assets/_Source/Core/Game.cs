using _Source.Observable;

namespace _Source.Core
{
    public class Game
    {
        private IObservable _timer;
        public Game(IObservable timer)
        {
            _timer = timer;
        }

        public void StartGame()
        {
            _timer.Notify();
        }
    }
}