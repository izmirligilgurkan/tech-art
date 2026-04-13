using Game.Currency;
using UnityEngine;

namespace UI.Models
{
    public interface ICurrencyBarData
    { 
        ICurrency Currency { get; }
        bool ParticleOnAdd { get; }
        bool ParticleOnSpend { get; }
    }
}