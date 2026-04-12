using UnityEngine;

namespace UI.Models
{
    [CreateAssetMenu(fileName = "SettingsOption_", menuName = "Game/UI/Settings/Option")]
    public class SettingsOptionData : ScriptableObject, ISettingsOptionData
    {
        [SerializeField] private string title;
        [SerializeField] private Sprite icon;

        public string Title => title;
        public Sprite Icon => icon;
    }
}