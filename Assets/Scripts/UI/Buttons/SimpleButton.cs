using System;

namespace UI.Buttons
{
    public class SimpleButton : AButton
    {
        public event Action OnClicked;
        
        protected override void OnButtonClicked()
        {
            OnClicked?.Invoke();
        }
    }
}