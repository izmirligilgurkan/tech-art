using TMPro;
using UI.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public abstract class ASettingsOptionView : AView
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text title;
        
        protected ISettingsOptionData Data;
        protected SettingsPopupView Popup;
        
        public virtual void Bind(ISettingsOptionData data, SettingsPopupView settingsPopupView)
        {
            Data = data;
            Popup = settingsPopupView;
            icon.sprite = Data.Icon;
            title.text = Data.Title;
        }
    }
}