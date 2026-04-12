using UI.Views;
using UnityEngine;

namespace UI.Models
{
    public abstract class APopupData : ScriptableObject, IPopupData
    {
        protected const string FilePrefix = "Popup_";
        protected const string MenuPath = "Game/UI/Popup/";
        
        [SerializeField] private APopupView popupPrefab;

        public APopupView PopupPrefab => popupPrefab;
    }
}