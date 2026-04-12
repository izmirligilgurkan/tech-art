using Core.Provider;
using UI.Controllers;
using UI.Models;
using UnityEngine;

namespace UI.Buttons
{
    public class PopupButton : AButton
    {
        [SerializeField] private APopupData popupToOpen;
        
        protected override void OnButtonClicked()
        {
            ProviderService.Get<IPopupProvider>().ShowPopup(popupToOpen);
        }
    }
}