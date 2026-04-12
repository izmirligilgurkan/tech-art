using DG.Tweening;
using TMPro;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class SettingsPopupView : APopupView<SettingsPopupData>
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private ToggleableSettingsOptionView toggleableOptionPrefab;
        [SerializeField] private LocalizationSettingsOptionView localizationOptionPrefab;
        [SerializeField] private Transform optionsContainer;
        [SerializeField] private TMP_Text versionText;
        
        private Tween _openAnimationTween;
        
        protected override void Bind(SettingsPopupData popupData)
        {
            titleText.SetText(popupData.Title);
            
            foreach (var optionData in popupData.ToggleableOptions)
            {
                var optionView = Instantiate(toggleableOptionPrefab, optionsContainer);
                optionView.Bind(optionData, this);
            }
            
            var localizationOptionView = Instantiate(localizationOptionPrefab, optionsContainer);
            localizationOptionView.Bind(popupData.LocalizationOptionData, this);
            
            versionText.SetText($"Ver. {Application.version}");
            
            PlayOpenAnimation();
        }

        private void PlayOpenAnimation()
        {
            if (_openAnimationTween != null && _openAnimationTween.IsActive())
            {
                _openAnimationTween.Complete();
            }
            
            var scale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(scale, 0.2f).SetEase(Ease.OutBack);
        }
        
        private void PlayCloseAnimation()
        {
            if (_openAnimationTween != null && _openAnimationTween.IsActive())
            {
                _openAnimationTween.Complete();
            }
            
            _openAnimationTween = transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack).OnComplete(() =>
            {
                OnClosed?.Invoke();
            });
        }

        protected override void OnCloseClicked()
        {
            PlayCloseAnimation();
        }

        public void OpenLocalizationSettings()
        {
        }
    }
}