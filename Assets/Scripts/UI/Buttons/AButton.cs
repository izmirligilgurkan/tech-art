using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public abstract class AButton : MonoBehaviour
    {
        [SerializeField] protected Button button;
        
        private void Awake()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        protected abstract void OnButtonClicked();
    }
}