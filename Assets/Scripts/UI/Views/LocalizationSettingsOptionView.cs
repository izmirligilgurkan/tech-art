using UI.Buttons;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class LocalizationSettingsOptionView : ASettingsOptionView
    {
        [SerializeField] private SimpleButton button;
        
        public override void Bind(ISettingsOptionData data, SettingsPopupView settingsPopupView)
        {
            base.Bind(data, settingsPopupView);
            button.OnClicked += Popup.OpenLocalizationSettings;
        }
        
        private void OnDestroy()
        {
            button.OnClicked -= Popup.OpenLocalizationSettings;
        }
    }
}