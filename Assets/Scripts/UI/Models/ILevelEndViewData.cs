using System.Collections.Generic;
using Game.Currency;

namespace UI.Models
{
    public interface ILevelEndViewData
    {
        CurrencyReward BigReward { get; }
        IReadOnlyList<CurrencyReward> SmallRewards { get; }
        CurrencyReward RewardedBonus { get; }
    }
}