using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "TopBar_", menuName = "Game/UI/TopBar", order = 0)]
    public class TopBarData : ScriptableObject, ITopBarData
    {
        [SerializeField] private List<CurrencyBarData> currencyBars;
        
        public IReadOnlyList<ICurrencyBarData> CurrencyBars => currencyBars;
    }
}