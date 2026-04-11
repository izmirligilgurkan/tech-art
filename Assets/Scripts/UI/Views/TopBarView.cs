using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class TopBarView : AView
    {
        [SerializeField] private Transform currencyBarContainer;
        [SerializeField] private CurrencyBarView currencyViewPrefab;

        private ITopBarData _data;
        
        public void Bind(ITopBarData data)
        {
            _data = data;
            InitializeCurrencyBars();
        }

        private void InitializeCurrencyBars()
        {
            foreach (var currencyBarData in _data.CurrencyBars)
            {
                var currencyBarView = Instantiate(currencyViewPrefab, currencyBarContainer);
                currencyBarView.Bind(currencyBarData);
            }
        }
    }
}