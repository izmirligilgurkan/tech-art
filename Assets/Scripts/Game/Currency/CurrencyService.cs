using System.Collections.Generic;
using Core.Observable;
using UnityEngine;

namespace Game.Currency
{
    //Better do non-static and use a service locator with proper initialization, but for simplicity and since it's not the main focus, keeping it static.
    public static class CurrencyService 
    {
        private static Dictionary<ICurrency, Observable<int>> Currencies { get; } = new();
        private static Dictionary<ICurrency, Vector2> CurrencyAddPositions { get; } = new();
        private static Dictionary<ICurrency, Vector2> CurrencySpendPositions { get; } = new();
        
        public static IObservable<int> GetCurrencyObservable(ICurrency currency)
        {
            LoadCurrency(currency);
            return Currencies[currency];
        }
        
        public static Vector2 GetCurrencyAddPosition(ICurrency currency)
        {
            if (CurrencyAddPositions.TryGetValue(currency, out var position))
            {
                return position;
            }
            
            return new Vector2(Screen.width / 2f, Screen.height / 2f); // Default to center if no position recorded
        }
        
        public static Vector2 GetCurrencySpendPosition(ICurrency dataCurrency)
        {
            if (CurrencySpendPositions.TryGetValue(dataCurrency, out var position))
            {
                return position;
            }
            
            return new Vector2(Screen.width / 2f, Screen.height / 2f); // Default to center if no position recorded
        }

        private static int GetPersistentCurrencyValue(ICurrency currency)
        {
            var amount = PlayerPrefs.GetInt(currency.Key, currency.DefaultAmount);
            return amount;
        }
        
        public static void AddCurrency(ICurrency currency, int amount, Vector2 position = default)
        {
            LoadCurrency(currency);

            if (position == default)
            {
                position = new Vector2(Screen.width / 2f, Screen.height / 2f); // Default to center if no position provided
            }
            
            CurrencyAddPositions[currency] = position;
            var currentAmount = Currencies[currency].Value;
            var newAmount = currentAmount + amount;
            Currencies[currency].Set(newAmount);
            PlayerPrefs.SetInt(currency.Key, newAmount);
        }

        public static bool TrySpendCurrency(ICurrency currency, int amount, Vector2 position = default)
        {
            LoadCurrency(currency);

            var currentAmount = Currencies[currency].Value;
            if (currentAmount < amount)
            {
                return false; // Not enough currency
            }
            
            if (position == default)
            {
                position = new Vector2(Screen.width / 2f, Screen.height / 2f); // Default to center if no position provided
            }
            
            CurrencySpendPositions[currency] = position;

            var newAmount = currentAmount - amount;
            Currencies[currency].Set(newAmount);
            PlayerPrefs.SetInt(currency.Key, newAmount);
            return true;
        }

        private static void LoadCurrency(ICurrency currency)
        {
            if (!Currencies.ContainsKey(currency))
            {
                Currencies[currency] = new Observable<int>(GetPersistentCurrencyValue(currency));
            }
        }
    }
}