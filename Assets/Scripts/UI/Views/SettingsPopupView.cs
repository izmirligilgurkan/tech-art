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
        }

        protected override void OnCloseClicked()
        {
            OnClosed?.Invoke();
        }

        public void OpenLocalizationSettings()
        {
        }
    }
}