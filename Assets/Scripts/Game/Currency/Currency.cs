using UnityEngine;

namespace Game.Currency
{
    [CreateAssetMenu(fileName = "Currency_", menuName = "Game/Economy/Currency", order = 0)]
    public class Currency : ScriptableObject, ICurrency
    {
        [SerializeField] private string key;
        [SerializeField] private Sprite icon;
        [SerializeField] private int defaultAmount;
        [SerializeField] private bool isPurchasable = false;

        public string Key => key;
        public Sprite Icon => icon;
        public int DefaultAmount => defaultAmount;
        public bool IsPurchasable => isPurchasable;
    }
}