using UnityEngine;

namespace Game.Currency
{
    public interface ICurrency
    {
        public string Key { get; }
        public Sprite Icon { get; }
        public int DefaultAmount { get; }
        public bool IsPurchasable { get; }
    }
}