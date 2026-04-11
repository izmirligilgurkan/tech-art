using System;

namespace Core.Observable
{
    public interface IObservable<T>
    {
        T Value { get; }
        void Subscribe(Action<T> onValueChanged);
        void Unsubscribe(Action<T> onValueChanged);
    }
}