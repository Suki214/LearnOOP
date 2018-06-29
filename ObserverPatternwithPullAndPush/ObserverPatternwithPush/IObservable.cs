namespace ObserverPatternwithPush
{
    interface IObservable
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);

    }
}
