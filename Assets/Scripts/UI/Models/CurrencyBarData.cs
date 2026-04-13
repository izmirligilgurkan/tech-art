using Game.Currency;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "CurrencyBar_", menuName = "Game/UI/CurrencyBar", order = 0)]
    public class CurrencyBarData : ScriptableObject, ICurrencyBarData
    {
        [SerializeField] private Currency currency;
        [SerializeField] private Sprite icon;
        [SerializeField] private bool particleOnAdd;
        [SerializeField] private bool particleOnSpend;
        
        public ICurrency Currency => currency;
        public bool ParticleOnAdd => particleOnAdd;
        public bool ParticleOnSpend => particleOnSpend;
    }
}