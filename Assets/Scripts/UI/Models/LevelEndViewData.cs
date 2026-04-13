using System.Collections.Generic;
using Game.Currency;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "LevelEndView_", menuName = "Game/UI/LevelEndView")]
    public class LevelEndViewData : ScriptableObject, ILevelEndViewData
    {
        [SerializeField] private CurrencyReward bigReward;
        [SerializeField] private List<CurrencyReward> smallRewards;
        [SerializeField] private CurrencyReward rewardedBonus;

        public CurrencyReward BigReward => bigReward;
        public IReadOnlyList<CurrencyReward> SmallRewards => smallRewards;
        public CurrencyReward RewardedBonus => rewardedBonus;
    }
}