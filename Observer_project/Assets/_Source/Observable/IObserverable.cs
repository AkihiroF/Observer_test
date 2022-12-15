using _Source.Observer;

namespace _Source.Observable
{
    public interface IObservable
    {
        public void RegisterObserver(IObserver obj);
        public void RemoveObserver(IObserver obj);
        public void Notify();
    }
}