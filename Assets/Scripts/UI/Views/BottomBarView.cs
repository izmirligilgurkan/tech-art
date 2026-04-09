using System;
using System.Collections.Generic;
using UI.Buttons;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public class BottomBarView : AView
    {
        [SerializeField] private BottomButton buttonPrefab;
        [SerializeField] private Transform buttonContainer;
        
        private readonly List<BottomButton> _buttons = new();

        public event Action<Content> ContentActivated;
        
        public void Bind(IBottomBarData data)
        {
            ClearButtons();
            InstantiateButtons(data.Buttons);
        }
        
        public void OnButtonClicked(IBottomButtonData buttonData)
        {
            ContentActivated?.Invoke(buttonData.TargetContent);
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