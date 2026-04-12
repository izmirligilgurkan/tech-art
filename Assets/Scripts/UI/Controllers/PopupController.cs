using System.Collections.Generic;
using Core.Provider;
using UI.Models;
using UI.Views;
using UnityEngine;

namespace UI.Controllers
{
    public class PopupController : MonoBehaviour, IPopupProvider
    {
        private readonly Queue<APopupData> _popupQueue = new();

        private APopupView _currentPopupView;
        
        private void Awake()
        {
            ProviderService.Register<IPopupProvider>(this);
        }
        
        private void OnDestroy()
        {
            ProviderService.Unregister<IPopupProvider>();
        }

        public void ShowPopup(APopupData aPopupData)
        {
            _popupQueue.Enqueue(aPopupData);
            TryShowNextPopup();
        }

        private void TryShowNextPopup()
        {
            if (_popupQueue.Count == 0 || _currentPopupView != null)
            {
                return;
            }

            var nextPopupData = _popupQueue.Dequeue();
            _currentPopupView = Instantiate(nextPopupData.PopupPrefab, transform);
            _currentPopupView.Bind(nextPopupData);
            _currentPopupView.OnClosed += OnPopupClosed;
        }
        
        private void OnPopupClosed()
        {
            _currentPopupView.OnClosed -= OnPopupClosed;
            Destroy(_currentPopupView.gameObject);
            _currentPopupView = null;
            
            TryShowNextPopup();
        }
    }
}