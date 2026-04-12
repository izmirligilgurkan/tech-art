using System;
using System.Collections.Generic;
using UI.Buttons;
using UI.Models;
using UnityEngine;

namespace UI.Views
{
    public abstract class APopupView<T> : APopupView where T : IPopupData
    {
        public override void Bind(IPopupData popupData)
        {
            if (popupData is T typedData)
            {
                Bind(typedData);
            }
            else
            {
                throw new ArgumentException($"Invalid popup data type. Expected {typeof(T)}, got {popupData.GetType()}");
            }
        }

        protected abstract void Bind(T popupData);
    }

    public abstract class APopupView : AView
    {
        [SerializeField] private List<SimpleButton> closeButtons;
        
        public Action OnClosed;
        public abstract void Bind(IPopupData popupData);

        protected abstract void OnCloseClicked();

        private void Awake()
        {
            foreach (var button in closeButtons)
            {
                button.OnClicked += OnCloseClicked;
            }
        }
    }
}