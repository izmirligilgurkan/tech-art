using System;
using System.Collections.Generic;
using DG.Tweening;
using UI.Buttons;
using UI.Extensions;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class BottomBarView : AView
    {
        private const float HideOffset = -500f;

        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private BottomButton buttonPrefab;
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private BottomButtonSelectedView selectedView;
        
        private readonly List<BottomButton> _buttons = new();

        private IBottomBarData _data;
        private BottomButton _selectedButton;
        private Tween _hideTween;
        private Tween _showTween;
        
        public event Action<Content> ContentActivated;
        public event Action Closed;

        public void Bind(IBottomBarData data)
        {
            _data = data;
            ClearButtons();
            InstantiateButtons(data.Buttons);
            selectedView.SetUnselected();
        }
        
        public override void Hide()
        {
            _showTween?.Complete();
            _hideTween?.Complete();
            
            Close();
            
            _hideTween = rectTransform.DOAnchorPosY(HideOffset, 0.3f).OnComplete(() =>
            {
                base.Hide();
            });
        }
        
        public override void Show()
        {
            _hideTween?.Complete();
            _showTween?.Complete();
            
            base.Show();

            rectTransform.DOAnchorPosY(0, 0.3f);
        }
        
        private void Close()
        {
            UnselectCurrentButton();
            selectedView.SetUnselected();
            Closed?.Invoke();
        }
        
        private void InstantiateButtons(IReadOnlyList<IBottomButtonData> dataButtons)
        {
            foreach (var buttonData in dataButtons)
            { 
                var button = Instantiate(buttonPrefab, buttonContainer);
                button.Bind(buttonData, this);
                _buttons.Add(button);
            }
        }

        private void ClearButtons()
        {
            foreach (var button in _buttons)
            {
                Destroy(button.gameObject);
            }
            
            _buttons.Clear();
        }
        
        public void OnButtonClicked(IBottomButtonData buttonData, BottomButton clickedButton)
        {
            if (_selectedButton == clickedButton || !buttonData.TargetContent.IsUnlocked)
            {
                Close();
                return;
            }
            
            UnselectCurrentButton();
         
            ContentActivated?.Invoke(buttonData.TargetContent);

            SelectButton(buttonData, clickedButton);
        }

        private void SelectButton(IBottomButtonData buttonData, BottomButton clickedButton)
        {
            _selectedButton = clickedButton;
            _selectedButton.SetSelected(true, selectedView.Width);
            selectedView.SetButtonSelected(buttonData, _selectedButton.transform.RectTransform());
        }
        
        private void UnselectCurrentButton()
        {
            _selectedButton?.SetSelected(false);
            _selectedButton = null;
        }
    }
}