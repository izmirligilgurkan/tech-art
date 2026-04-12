using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(menuName = MenuPath + "Settings", fileName = FilePrefix + "Settings", order = 0)]
    public class SettingsPopupData : APopupData
    {
        [SerializeField] private string title;
        [SerializeField] private List<ToggleableSettingsOptionData> toggleableOptions;
        [SerializeField] private SettingsOptionData localizationOptionData;

        public string Title => title;
        public IReadOnlyList<ToggleableSettingsOptionData> ToggleableOptions => toggleableOptions;
        public SettingsOptionData LocalizationOptionData => localizationOptionData;
    }
}