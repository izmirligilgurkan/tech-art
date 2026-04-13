using Core.Provider;
using Game.Currency;
using TMPro;
using UI.Buttons;
using UI.Models;
using UI.Particles;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class CurrencyBarView : AView
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private CurrencyPurchaseButton purchaseButton;
        
        private ICurrencyBarData _data;
        private Core.Observable.IObservable<int> _currencyObservable;
        private int _currentAmount;
        
        public void Bind(ICurrencyBarData data)
        {
            _data = data;
            icon.sprite = _data.Currency.Icon;
            
            _currencyObservable?.Unsubscribe(OnCurrencyChanged);
            _currencyObservable = CurrencyService.GetCurrencyObservable(data.Currency);
            _currencyObservable.Subscribe(OnCurrencyChanged);
            
            amountText.text = _currencyObservable.Value.ToString();
            _currentAmount = _currencyObservable.Value;
            
            purchaseButton.Bind(_data.Currency);
            purchaseButton.gameObject.SetActive(data.Currency.IsPurchasable);
        }

        private void OnDestroy()
        {
            _currencyObservable?.Unsubscribe(OnCurrencyChanged);
        }

        private void OnCurrencyChanged(int newAmount)
        {
            var diff = newAmount - _currentAmount;
            if (diff <= 0)
            {
                OnCurrencySpend(newAmount, diff);
            }
            else
            {
                OnCurrencyAdd(newAmount, diff);
            }
            
            _currentAmount = newAmount;
        }
        
        private void OnCurrencyAdd(int newAmount, int diff)
        {
            if (!IsVisible || !_data.ParticleOnAdd)
            {
                amountText.text = newAmount.ToString();
                return;
            }
            
            var provider = ProviderService.Get<CurrencyParticleProvider>();
            var particleData = new UIParticleData(_data.Currency.Icon, diff, CurrencyService.GetCurrencyAddPosition(_data.Currency), icon.transform.position);
            provider.SpawnCurrencyParticles(particleData, () => amountText.text = newAmount.ToString());
        }

        private void OnCurrencySpend(int newAmount, int diff)
        {
            if (!IsVisible || !_data.ParticleOnSpend)
            {
                amountText.text = newAmount.ToString();
                return;
            }
            
            var provider = ProviderService.Get<CurrencyParticleProvider>();
            var particleData = new UIParticleData(_data.Currency.Icon, Mathf.Abs(diff), icon.transform.position, CurrencyService.GetCurrencySpendPosition(_data.Currency));
            provider.SpawnCurrencyParticles(particleData);
            amountText.text = newAmount.ToString();
        }
    }
}