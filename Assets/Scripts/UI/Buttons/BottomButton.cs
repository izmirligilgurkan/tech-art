using System.Collections.Generic;
using DG.Tweening;
using UI.Extensions;
using UI.Models;
using UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class BottomButton : AButton
    {
        [SerializeField] private LayoutElement layoutElement;
        [SerializeField] private Image icon;
        [SerializeField] private Image lockedIcon;
        [SerializeField] private List<DOTweenAnimation> selectedAnimations;
        
        private BottomBarView _bottomBar;
        private IBottomButtonData _data;
        
        public void Bind(IBottomButtonData data, BottomBarView view)
        {
            _data = data;
            _bottomBar = view;
            icon.sprite = _data.Icon;
            RefreshLockState(_data);
        }

        public void SetSelected(bool isSelected, float selectedViewWidth = 0f)
        {
            layoutElement.minWidth = isSelected ? selectedViewWidth / 2f : 0f;
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.RectTransform());
            
            if (isSelected)
            {
                foreach (var anim in selectedAnimations)
                {
                    anim?.DORestart();
                }
            }
            else
            {
                foreach (var anim in selectedAnimations)
                {
                    anim?.DOPlayBackwards();
                }
            }
        }
        
        private void RefreshLockState(IBottomButtonData data)
        {
            lockedIcon.enabled = !data.TargetContent.IsUnlocked;
            icon.enabled = data.TargetContent.IsUnlocked;
        }

        protected override void OnButtonClicked()
        {
            if (_bottomBar == null)
            {
                Debug.LogError("BottomButton: BottomBarView is not assigned.");
                return;
            }
            
            _bottomBar.OnButtonClicked(_data, this);
        }
    }
}