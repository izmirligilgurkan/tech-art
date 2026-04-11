using System;

namespace Core.Observable
{
    public class Observable<T> : IObservable<T>
    {
        private T _value;

        public Observable(T value)
        {
            _value = value;
        }

        public T Value => _value;

        private event Action<T> OnValueChanged;
        
        public void Set(T newValue, bool forceNotify = false)
        {
            if (!Equals(_value, newValue))
            {
                _value = newValue;
                NotifySubscribers();
            }
            else if (forceNotify)
            {
                NotifySubscribers();
            }
        }

        public void Subscribe(Action<T> onValueChanged)
        {
            OnValueChanged += onValueChanged;
        }

        public void Unsubscribe(Action<T> onValueChanged)
        {
            OnValueChanged -= onValueChanged;
        }

        private void NotifySubscribers()
        {
            OnValueChanged?.Invoke(_value);
        }
    }
}