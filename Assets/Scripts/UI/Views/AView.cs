using UI.Extensions;
using UnityEngine;

namespace UI.Views
{
    public abstract class AView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        
        private bool _isVisible = true;
        public bool IsVisible => _isVisible;
        
        public virtual void Show()
        {
            canvasGroup.Show();
            _isVisible = true;
        }
        
        public virtual void Hide()
        {
            canvasGroup.Hide();
            _isVisible = false;
        }
    }
}