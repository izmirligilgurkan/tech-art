using UnityEngine;

namespace Game.Currency
{
    [CreateAssetMenu(fileName = "Currency_", menuName = "Game/Economy/Currency", order = 0)]
    public class Currency : ScriptableObject, ICurrency
    {
        [SerializeField] private string key;
        [SerializeField] private int defaultAmount;
        [SerializeField] private bool isPurchasable = false;

        public string Key => key;
        public int DefaultAmount => defaultAmount;
        public bool IsPurchasable => isPurchasable;
    }
}