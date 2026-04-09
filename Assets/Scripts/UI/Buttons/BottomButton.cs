using UI.Models;
using UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class BottomButton : AButton
    {
        [SerializeField] private Image icon;
        
        private BottomBarView _bottomBar;
        private IBottomButtonData _data;

        public void Bind(IBottomButtonData data, BottomBarView view)
        {
            _data = data;
            _bottomBar = view;
            icon.sprite = _data.Icon;
        }

        protected override void OnButtonClicked()
        {
            if (_bottomBar == null)
            {
                Debug.LogError("BottomButton: BottomBarView is not assigned.");
                return;
            }
            
            _bottomBar.OnButtonClicked(_data);
        }
    }
}