using UI.Buttons;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class ToggleableSettingsOptionView : ASettingsOptionView
    {
        [SerializeField] private ObservableToggleButton toggleButton;

        public override void Bind(ISettingsOptionData data, SettingsPopupView settingsPopupView)
        {
            base.Bind(data, settingsPopupView);
            if (data is ToggleableSettingsOptionData toggleData)
            {
                toggleButton.Bind(toggleData.IsOn);   
            }
        }
        
        private void OnDestroy()
        {
            toggleButton?.Dispose();
        }
    }
}