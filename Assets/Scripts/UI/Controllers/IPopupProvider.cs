using Core.Provider;
using UI.Models;

namespace UI.Controllers
{
    public interface IPopupProvider : IProvider
    {
        void ShowPopup(APopupData aPopupData);
    }
}