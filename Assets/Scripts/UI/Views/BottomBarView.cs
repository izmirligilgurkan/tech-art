using System;
using System.Collections.Generic;
using DG.Tweening;
using UI.Buttons;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class BottomBarView : AView
    {
        [SerializeField] private BottomButton buttonPrefab;
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private BottomButtonSelectedView selectedView;
        [Header("Optional")]
        [SerializeField] private DOTweenAnimation hideAnimation;
        [SerializeField] private DOTweenAnimation showAnimation;
        
        private readonly List<BottomButton> _buttons = new();

        private IBottomBarData _data;
        private BottomButton _selectedButton;
        
        public event Action<Content> ContentActivated;
        public event Action Closed;

        private void Awake()
        {
            hideAnimation.onComplete.AddListener(OnHideAnimationComplete);
        }

        private void OnHideAnimationComplete()
        {
            base.Hide();
        }

        public void Bind(IBottomBarData data)
        {
            _data = data;
            ClearButtons();
            InstantiateButtons(data.Buttons);
            selectedView.SetUnselected();
        }
        
        public void OnButtonClicked(IBottomButtonData buttonData, BottomButton clickedButton)
        {
            _selectedButton?.SetSelected(false);
            
            if (_selectedButton == clickedButton || !buttonData.TargetContent.IsUnlocked)
            {
                Close();
                return;
            }
         
            ContentActivated?.Invoke(buttonData.TargetContent);

            _selectedButton = clickedButton;
            _selectedButton.SetSelected(true);
            selectedView.SetButtonSelected(buttonData, _selectedButton.transform);
        }

        public override void Hide()
        {
            showAnimation?.DOKill();
            
            Close();
            
            if (hideAnimation != null)
            {
                hideAnimation.DORestart();
            }
            else
            {
                base.Hide();
            }
        }
        
        public override void Show()
        {
            hideAnimation?.DOKill();
            base.Show();
            showAnimation?.DORestart();
        }

        private void Close()
        {
            _selectedButton = null;
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
    }
}