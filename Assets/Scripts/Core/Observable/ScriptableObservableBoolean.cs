using System;
using UnityEngine;

namespace Core.Observable
{
    [CreateAssetMenu(menuName = "Game/Core/ScriptableObservable/Boolean", fileName = "Bool_", order = 0)]
    public class ScriptableObservableBoolean : ScriptableObject, IObservable<bool>
    {
        [SerializeField] private bool initialValue;
        [NonSerialized] private bool _value;
        
        private event Action<bool> OnValueChanged;

        public bool Value => _value;
        
        private void OnEnable()
        {
            _value = initialValue;
        }

        public void Subscribe(Action<bool> onValueChanged)
        {
            OnValueChanged += onValueChanged;
        }

        public void Unsubscribe(Action<bool> onValueChanged)
        {
            OnValueChanged -= onValueChanged;
        }

        public void Set(bool newValue, bool forceNotify = false)
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
        
        private void NotifySubscribers()
        {
            OnValueChanged?.Invoke(_value);
        }
    }
}