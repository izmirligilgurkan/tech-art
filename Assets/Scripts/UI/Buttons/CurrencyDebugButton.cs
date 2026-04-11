using Game.Currency;
using UnityEngine;

namespace UI.Buttons
{
    public class CurrencyDebugButton : AButton
    {
        [SerializeField] private Currency currency;
        [SerializeField] private int amountToChange;
        
        protected override void OnButtonClicked()
        {
            var add = amountToChange > 0;
            var changeAmount = Mathf.Abs(amountToChange);
            if (add)
            {
                CurrencyService.AddCurrency(currency, changeAmount, transform.position);
            }
            else
            {
                CurrencyService.TrySpendCurrency(currency, changeAmount, transform.position);
            }
        }
    }
}