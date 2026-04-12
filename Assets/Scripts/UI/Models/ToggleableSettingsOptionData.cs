using Core.Observable;
using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "SettingsOption_", menuName = "Game/UI/Settings/ToggleableOption")]
    public class ToggleableSettingsOptionData : SettingsOptionData
    {
        [SerializeField] private ScriptableObservableBoolean isOn;
        
        public ScriptableObservableBoolean IsOn => isOn;
    }
}