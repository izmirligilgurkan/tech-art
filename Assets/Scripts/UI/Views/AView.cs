using UI.Extensions;
using UnityEngine;

namespace UI.Views
{
    public abstract class AView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        
        public virtual void Show()
        {
            canvasGroup.Show();
        }
        
        public virtual void Hide()
        {
            canvasGroup.Hide();
        }
    }
}