using System;

namespace Game.Currency
{
    [Serializable]
    public struct CurrencyReward
    {
        public Currency currency;
        public int amount;
        
        public CurrencyReward(Currency currency, int amount)
        {
            this.currency = currency;
            this.amount = amount;
        }
        
        public void ProcessReward()
        {
            CurrencyService.AddCurrency(currency, amount);
        }
    }
}