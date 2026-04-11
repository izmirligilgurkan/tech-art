using Game.Currency;

namespace UI.Buttons
{
    public class CurrencyPurchaseButton : AButton
    {
        private ICurrency _currency;
        
        public void Bind(ICurrency currency)
        {
            _currency = currency;
        }
        
        protected override void OnButtonClicked()
        {
            //Direct to shop or a popup via event
        }
    }
}